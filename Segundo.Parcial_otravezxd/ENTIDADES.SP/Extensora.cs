using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ENTIDADES.SP
{
    public static class Extensora
    { 
        public static bool EliminarFruta(this Cajon<Manzana> cajon, int id)
        {
            bool seElimino = false;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion);
            SqlCommand com = new SqlCommand();
            SqlDataReader lector;

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandType = CommandType.Text;

                com.CommandText = "select * from [sp_lab_II].[dbo].[frutas] where id =" + id;

                lector = com.ExecuteReader();

                if (lector.Read() != false)
                {
                    lector.Close();
                    com.CommandText = "delete from [sp_lab_II].[dbo].[frutas] WHERE id = " + id;
                    com.ExecuteNonQuery();
                    seElimino = true;
                }
            }
            catch(Exception)
            {
                throw new Exception();
            }

            return seElimino;
        }
    }
}
