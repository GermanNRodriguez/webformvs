using System;
using System.Data.SqlClient;
using Producto;

namespace DataAccess
{
    public class Conexion
    {
        SqlConnection conexion = new SqlConnection();
        Product product = new Product();
        SqlCommand comandos = new SqlCommand();
        public Conexion()
        {
            string source = @"Data Source=GERNIROZ-PC\SQLEXPRESS; Initial Catalog=Taller; Integrated Security=true;";
            conexion = new SqlConnection(source);

        }

        public void Insert(Product p)
        {
            conexion.Open();
            try
            {
                comandos = new SqlCommand(string.Format("insertProductos " +
                    $"{p.nombre},{p.descripcion},{p.precio},{p.stock}"), conexion);
                comandos.ExecuteNonQuery();
            }
            catch (Exception e) {   
            }
            conexion.Close();
        }
        public void Update(Product p)
        {
            conexion.Open();
            try
            {
                comandos = new SqlCommand(string.Format("updateProductos " +
                $"{p.idProducto},{p.nombre},{p.descripcion},{p.precio},{p.stock}"), conexion);
                comandos.ExecuteNonQuery();
            }
            catch (Exception e) {
            }
            conexion.Close();
        }
        public void Delete(Product p)
        {
            conexion.Open();
            try
            {
                comandos = new SqlCommand(string.Format($"deleteProductos {p.idProducto}"), conexion);
                comandos.ExecuteNonQuery();
            }
            catch (Exception e) {
                
            }
            conexion.Close();
        }
    }

}
