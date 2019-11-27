using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
//Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
namespace Entidades.SP
{
    public class Durazno : Fruta
    {
        protected int _cantPelusa;

        public string Nombre
        {
            get
            {
                return "Durazno";
            }
        }

        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            this._cantPelusa = cantPelusa;
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public override string ToString()
        {
            return "Nombre: " + this.Nombre + "\nCantidad de pelusa: " + this._cantPelusa + base.FrutaToString();
        }
    }
}
