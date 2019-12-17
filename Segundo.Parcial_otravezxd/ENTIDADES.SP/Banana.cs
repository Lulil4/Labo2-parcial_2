using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{ //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
  //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false

    public class Banana : Fruta
    {
        protected string _paisOrigen;

        public string Nombre
        {
            get
            {
                return "Banana";
            }
        }

        public override string ToString()
        {
            return this.FrutaToString() + "|Provincia de origen: " + this._paisOrigen;
        }

        public override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }

        public Banana(string color, double peso, string pais) : base(color, peso)
        {
            this._paisOrigen = pais;
        }
    }
}
