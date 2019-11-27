using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.SP
{
    public class Manejadora<Fruta>
    {
        public static void ManejadorEventoPrecio(double precio, Cajon<Fruta> cajon)
        {
            Console.WriteLine("*******************************");
            Console.WriteLine(DateTime.Now.ToString() + "El total del precio del cajon supera los $55, con un precio de: " + precio);
            Console.WriteLine("*******************************");
        }

    }
}
