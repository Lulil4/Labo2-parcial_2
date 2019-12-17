using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace ENTIDADES.SP
{
    public class Manejadora<Fruta>
    {
        public void ManejadorEventoPrecio(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter escritor = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\PrecioSuperado.txt", true))
                {
                    escritor.WriteLine(DateTime.Now);
                    escritor.WriteLine("Precio total del cajon: " + ((Cajon<Fruta>)sender).PrecioTotal);
                }
            }
            catch
            {
            }
        }
    }
}
