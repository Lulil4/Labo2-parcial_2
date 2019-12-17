using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{//Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
 //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
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

        public override string ToString()
        {
            return this.FrutaToString() + "|Cantidad de pelusa: " + this._cantPelusa;
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public Durazno(string color, double peso, int cantPelusa) : base(color, peso)
        {
            this._cantPelusa = cantPelusa;
        }
    }
}
