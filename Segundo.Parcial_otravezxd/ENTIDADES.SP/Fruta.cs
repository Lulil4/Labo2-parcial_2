using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
         //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
    public abstract class Fruta
    {
        protected string _color;
        protected double _peso;

        public string Color { get { return this._color; } set { this._color = value; } }
        public double Peso { get { return this._peso; } set { this._peso = value; } }

        public Fruta() : this("vacio", 0)
        {

        }


        public abstract bool TieneCarozo
        {
            get;
        }

        public Fruta(string color, double peso)
        {
            this._color = color;
            this._peso = peso;
        }

        protected virtual string FrutaToString()
        {
            return "Color: " + this._color + "|Peso: " + this._peso;
        }
        
    }
}
