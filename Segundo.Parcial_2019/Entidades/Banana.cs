using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
//Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
namespace Entidades.SP
{
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

        public Banana(string color, double peso, string pais) : base(color, peso)
        {
            this._paisOrigen = pais;
        }

        public override bool TieneCarozo
        {
            get
            {
                return false;
            }
        }

        public override string ToString()
        {
            return "Nombre: " + this.Nombre + "\nPais de origen: " + this._paisOrigen + base.FrutaToString();
        }
    }
}
