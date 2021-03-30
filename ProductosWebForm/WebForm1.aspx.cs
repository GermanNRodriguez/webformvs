using DataAccess;
using Logic;
using Producto;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ProductosWebForm
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Product p = new Product();
        Conexion Conexion = new Conexion();
        SqlConnection connection = new SqlConnection();
        LP lp = new LP();

        protected void Page_Load(object sender, EventArgs e)
        {
            Conectar();
            CargarGrid();
        }
        public void Conectar()
        {
            string source = @"Data Source=GERNIROZ-PC\SQLEXPRESS; Initial Catalog=Taller; Integrated Security=true;";
            connection = new SqlConnection(source);
        }
        public void CargarGrid()
        {
            connection.Open();
            DataTable tabla = new DataTable();
            try
            {
                SqlDataAdapter data = new SqlDataAdapter("selectProductos", connection);
                data.Fill(tabla);
                gvProductos.DataSource = tabla;
                gvProductos.DataBind();
            }
            catch
            {
                Response.Write("<script> alert('Hubo un problema al llenar tabla')</script>");
            }
            connection.Close();
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                //Page.Session["IDProducto"]
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvProductos.Rows[rowIndex];
                Page.Session["IDProducto"] = Convert.ToInt32(row.Cells[1].Text);
                //p.idProducto = Convert.ToInt32(row.Cells[1].Text);
                txtNombre.Text = row.Cells[2].Text;
                txtDesc.Text = row.Cells[3].Text;
                txtPrecio.Text = row.Cells[4].Text;
                txtStock.Text = row.Cells[5].Text;
            }
        }
        public void CargarDatosTxt()
        {
            p.nombre = "'"+ txtNombre.Text.ToString() + "'";
            p.descripcion = "'" + txtDesc.Text.ToString() + "'";
            p.precio = int.Parse(txtPrecio.Text.ToString());
            p.stock = int.Parse(txtStock.Text.ToString());
        }
        public void VaciarDatosTxt()
        {
            txtNombre.Text = "";
            txtDesc.Text = "";
            txtPrecio.Text = "";
            txtStock.Text = "";
        }
        protected void botonGuardar_Click(object sender, EventArgs e)
        {
            bool prueba = false;
            p.idProducto = Convert.ToInt32(Page.Session["IDProducto"]);
            try
            {
                CargarDatosTxt();
            }
            catch
            {
                prueba = lp.ValidarTxt(p);
            }
            if (prueba == true)
            {
                
                Response.Write("<script>alert('Llenó mal el formulario')</script>");
                
            } else if (p.idProducto != 0)
            {
                CargarDatosTxt();
                Conexion.Update(p);
                CargarGrid();
            } else
            {
                CargarDatosTxt();
                Conexion.Insert(p);
                CargarGrid();
            }
            VaciarDatosTxt();
        }
        protected void botonBorrar_Click(object sender, EventArgs e)
        {
            p.idProducto = Convert.ToInt32(Page.Session["IDProducto"]);
            Conexion.Delete(p);
            p.idProducto = 0;
            VaciarDatosTxt();
            CargarGrid();
        }
        protected void botonCancelar_Click(object sender, EventArgs e)
        {
            p.idProducto = 0;
            VaciarDatosTxt();
        }

        protected void gvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}