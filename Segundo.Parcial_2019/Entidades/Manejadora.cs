using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data;

namespace Entidades.SP
{
    public class Manejadora<Fruta>
    {
        public void ManejadorEventoPrecio(double precio, Cajon<Fruta> cajon)
        {
            string msg = DateTime.Now.ToString() + " El total del precio del cajon supera los $55, con un precio de: " + precio;

            MessageBox.Show(msg);

            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\punto5.txt");

            sw.WriteLine(msg);

            sw.Close();
        }

    }
}
