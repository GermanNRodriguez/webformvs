using System;
using System.Data.SqlClient;

namespace Access
{
    public class Access
    {
        SqlConnection conexion = new SqlConnection();
        
        public Access()
        {

        }

        public void Conect()
        {
            string source = @"Data Source=GERNIROZ-PC\SQLEXPRESS; Initial Catalog=Taller; Integrated Security=true;";
            try
            {
                conexion = new SqlConnection(source);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al conectar con base de datos.\n" + e.Message);
            }
        }
    }
}
