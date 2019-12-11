using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{        //Sacapunta-> deMetal:bool(publico); 
         //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
    public class Sacapunta : Utiles
    {
        public bool deMetal;

        public Sacapunta(bool deMetal, double precio, string marca) : base(marca, precio)
        {
            this.deMetal = deMetal;
        }

        public override string ToString()
        {
            return this.UtilesToString() + "|Es de metal: " + this.deMetal;
        }

        public override bool PreciosCuidados
        {
            get
            {
                return true;
            }
        }
    }
}

