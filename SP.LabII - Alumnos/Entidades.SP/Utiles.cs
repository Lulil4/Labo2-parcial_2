using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{ //Utiles-> marca:string y precio:double (publicos); PreciosCuidados:bool (prop. s/l, abstracta);
  //constructor con 2 parametros y UtilesToString():string (protegido y virtual, retorna los valores del útil)
  //ToString():string (polimorfismo; reutilizar código)
    public abstract class Utiles
    {
        public string marca;
        public double precio;

        public abstract bool PreciosCuidados
        {
            get;
        }

        public Utiles(string marca, double precio)
        {
            this.marca = marca;
            this.precio = precio;
        }

        protected virtual string UtilesToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Marca: " + this.marca);
            sb.Append("|Precio: " + this.precio);
            return sb.ToString();
        }

        public override string ToString()
        {
            return this.UtilesToString();
        }
    }
}
