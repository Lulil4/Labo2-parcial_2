using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace ENTIDADES.SP
{  

   //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
   //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
   //Sobrecarga de operador
   //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
    public class Cajon<T> : ISerializar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;

        [XmlIgnore]
        public EventoPrecio _eventoPrecio;

        public delegate void EventoPrecio(object sender, EventArgs e);


        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.


        public List<T> Elementos
        {
            get
            {
                return this._elementos;
            }
        }

        public double PrecioTotal
        {
            get
            {
                double precio = this._precioUnitario * this._elementos.Count;
                return precio;
            }
        }

        public Cajon()
        {
            this._elementos = new List<T>();
        }

        public Cajon(int capacidad) : this()
        {
            this._capacidad = capacidad;
        }

        public Cajon(double precio, int capacidad) : this(capacidad)
        {
            this._precioUnitario = precio;
        }

       //ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total
   //y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Capacidad: " + this._capacidad);
            sb.AppendLine("Cantidad total de elementos: " + this._elementos.Count);
            sb.AppendLine("Precio total: " + this.PrecioTotal);

            foreach (T element in this.Elementos)
            {
                sb.AppendLine(element.ToString());
            }

            return sb.ToString();
        }

        public bool Xml(string s)
        {
            bool seGuardo = true;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Cajon<T>));

                using (System.IO.TextWriter escritor = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + s))
                {
                    ser.Serialize(escritor, this);
                }
            }
            catch(Exception )
            {
                seGuardo = false;
            }
            return seGuardo;
        }

        //(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
        public static Cajon<T> operator +(Cajon<T> c, T elemento)
        {
            if (c._elementos.Count < c._capacidad)
            {
                c._elementos.Add(elemento);
                if (c.PrecioTotal > 55)
                {
                    c._eventoPrecio(c, new EventArgs());
                }

            }
            else
            {
                throw new CajonLlenoException();
            }

            return c;
        }



    }
}
