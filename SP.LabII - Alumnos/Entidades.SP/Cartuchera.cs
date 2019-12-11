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
        public delegate void EventoPrecio(double precio, Cartuchera<T> cartuchera);

        public static void Manejador(double precio, Cartuchera<T> cartuchera)
       {
            StringBuilder sb = new StringBuilder();

             sb.AppendLine(DateTime.Now.ToString());
               sb.AppendLine("El precio supera los $55, con un precio de: " + precio);

            StreamWriter sw = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\tickets.log", true);

            sw.Close();

        }
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
                    //if (precioTotal > 85)
                    //{
                    //    this.eventoPrecio(precioTotal, this);
                    //}
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
                if (elemento.precio > 85)
                {
                    cartuchera.eventoPrecio(elemento.precio, cartuchera);
                }
                else
                {
                    cartuchera.Elementos.Add(elemento);
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
