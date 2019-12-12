using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Entidades.SP
{
   public  class Ticketadora
    {
        public static bool ImprimirTicket(Cartuchera<Goma> cartuchera)
        {
            bool seEscribio = false;

            try
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine(DateTime.Now.ToString());
                sb.AppendLine("El precio supera los $85, con un precio de: $" + cartuchera.PrecioTotal);

                using (StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log", true))
                {
                    sw.WriteLine(sb);
                }
                seEscribio = true;
            }
            catch
            {

            }

            return seEscribio;
        }

    }
}
