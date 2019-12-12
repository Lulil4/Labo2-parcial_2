using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Entidades.SP
{



    public class Cartuchera<T> where T : Utiles
    {
        protected int capacidad;
        protected List<T> elementos;
        public EventoPrecio eventoPrecio;
        public delegate void EventoPrecio(object sender, EventArgs e);


        public List<T> Elementos
        {
            get
            {
                return this.elementos;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double precioTotal = 0;

                foreach(T elemento in this.elementos)
                {
                    precioTotal += elemento.precio;
                }

                return precioTotal;
            }
        }

        public Cartuchera()
        {
            this.elementos = new List<T>();
        }

        public Cartuchera(int capacidad) : this()
        {
            this.capacidad = capacidad;
        }

        //Sobrecarga de operador
        //(+) Será el encargado de agregar elementos a la cartuchera siempre y cuando no supere la capacidad máxima de la misma.

        public override string ToString()
        {
            StringBuilder cartuchera = new StringBuilder();

            cartuchera.AppendLine("Capacidad: " + this.capacidad);
            cartuchera.AppendLine("Cantidad total de elementos: " + this.elementos.Count);
            cartuchera.AppendLine("Precio total: " + this.PrecioTotal);

            foreach (T elemento in this.elementos)
            {
                cartuchera.AppendLine();
                cartuchera.AppendLine(elemento.ToString());
            }

            return cartuchera.ToString();
        }

        public static Cartuchera<T> operator +(Cartuchera<T> cartuchera, T elemento)
        {

            if (cartuchera.elementos.Count < cartuchera.capacidad)
            {
                cartuchera.Elementos.Add(elemento);

                if (cartuchera is Cartuchera<Goma> && cartuchera.PrecioTotal > 85)
                {
                    cartuchera.eventoPrecio(cartuchera, new EventArgs());
                }
            }
            else
            {
                throw new CartucheraLlenaException();
            }

            return cartuchera;
        }
    }
}
