using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//atributos: _capacidad:int, _elementos:List<T> y _precioUnitario:double (todos protegidos)        
//Propiedades
//Elementos:(sólo lectura) expone al atributo de tipo List<T>.
//PrecioTotal:(sólo lectura) retorna el precio total del cajón (precio * cantidad de elementos).
//Constructor
//Cajon(), Cajon(int), Cajon(double, int); 
//El por default: es el único que se encargará de inicializar la lista.
//Métodos
//ToString: Mostrará en formato de tipo string, la capacidad, la cantidad total de elementos, el precio total 
//y el listado de todos los elementos contenidos en el cajón. Reutilizar código.
//Sobrecarga de operador
//(+) Será el encargado de agregar elementos al cajón, siempre y cuando no supere la capacidad del mismo.
namespace Entidades.SP
{
    [XmlInclude(typeof(Manzana))]

    public class Cajon<T> : ISerializar
    {
        protected int _capacidad;
        protected List<T> _elementos;
        protected double _precioUnitario;
        [XmlIgnore]
        public EventoPrecio _eventoPrecio;
        public delegate void EventoPrecio(double precio, Cajon<T> cajon);

        public List<T> Elementos
        {
            get
            {
                return this._elementos;
            }
        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.

        public double PrecioTotal
        {
            get
            {
                double precio = this._precioUnitario * this._elementos.Count;
                 
                if (precio > 55)
                {
                    this._eventoPrecio(precio, this);
                }

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

        public Cajon(double precio, int capacidad): this(capacidad)
        {
            this._precioUnitario = precio;
        }

        public override string ToString()
        {
            StringBuilder cajon = new StringBuilder();

            cajon.AppendLine("Capacidad: " + this._capacidad);
            cajon.AppendLine("Cantidad total de elementos: " + this._elementos.Count);
            cajon.AppendLine("Precio total: " + this.PrecioTotal);

            foreach(T elemento in this._elementos)
            {
                cajon.AppendLine();
                cajon.AppendLine(elemento.ToString());
            }

            return cajon.ToString();
        }

        public bool Xml(string path)
        {
            bool SeGuardo = true;

            try
            {
                XmlSerializer MiSerializador = new XmlSerializer(typeof(Cajon<T>));

                using (System.IO.TextWriter MiEscritor = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    MiSerializador.Serialize(MiEscritor, this);
                }
            }
            catch (Exception)
            {
                SeGuardo = false;
            }

            return SeGuardo;
        }


        public static Cajon<T> operator +(Cajon<T> cajon, T elemento)
        {
            if (cajon._elementos.Count < cajon._capacidad)
            {
                cajon.Elementos.Add(elemento);
            }
            else
            {
                throw new CajonLlenoException();
            }

            return cajon;
        }
    }
}
