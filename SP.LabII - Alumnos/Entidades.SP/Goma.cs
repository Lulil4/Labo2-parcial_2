using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public class Goma : Utiles
    {
        
            public bool soloLapiz;

            public override bool PreciosCuidados
            {
                get
                {
                    return true;
                }

            }

            public Goma(bool soloLapiz, string marca, double precio) : base(marca, precio)
            {
                this.soloLapiz = soloLapiz;
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("|Solo lapiz: " + this.soloLapiz);
                return this.UtilesToString() + sb.ToString();
            }

    }
}
