using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
//Reciba como parámetro un entero (será usado como valor del campo ID)
//Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
//Retorne un booleano que indique: 
//TRUE, si se ha eliminado la fruta. 
//FALSE, si no se elimino.
//Excepción, si se provocó algún error en la base de datos
namespace Entidades.SP
{
    public static class Extensora
    {
        public static bool EliminarFruta(this Cajon<Manzana> cajon, int id)
        {
            bool seElimino = false;
            SqlConnection conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            SqlCommand comando = new SqlCommand();

            try
            {
                conexion.Open();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                comando.CommandText = "SELECT * FROM [sp_lab_II].[dbo].[frutas] WHERE id = " + id;

                SqlDataReader lector = comando.ExecuteReader();

                if (lector.Read() != false)
                {
                    lector.Close();
                    comando.CommandText = "DELETE FROM [sp_lab_II].[dbo].[frutas] WHERE id = " + id;
                    comando.ExecuteNonQuery();
                    seElimino = true;
                }
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                conexion.Close();
            }

            return seElimino;
        }
    }
}
