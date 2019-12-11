using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Entidades.SP
{//Lapiz-> color:ConsoleColor(publico); trazo:ETipoTrazo(enum {Fino, Grueso, Medio}; publico); PreciosCuidados->true; 
 //Reutilizar UtilesToString en ToString() (mostrar todos los valores).
    public class Lapiz : Utiles, ISerializa, IDeserializa
    {
        public ConsoleColor color;
        public ETipoTrazo trazo;

        public ConsoleColor Color
        {
            get
            {
                return this.color;
            }

            set
            {
                this.color = value;
            }
        }

        public ETipoTrazo Trazo
        {
            get
            {
                return this.trazo;
            }

            set
            {
                this.trazo = value;
            }
        }
        public Lapiz() : this(ConsoleColor.Black, ETipoTrazo.Fino, "sinmarca", 0)
        {

        }
        public Lapiz(ConsoleColor color, ETipoTrazo trazo, string marca, double precio) : base(marca, precio)
        {
            this.color = color;
            this.trazo = trazo;
        }
        public override bool PreciosCuidados
        {
            get
            {
                return true;
            }
        }

        public string Path
        {
            get
            {
                return "Morel.Melany.Lucia.Lapiz.xml";
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("|Color: " + this.color);
            sb.Append("|Trazo: " + this.trazo);
            return this.UtilesToString() + sb.ToString();
        }

        public bool Xml()
        {
            bool SeGuardo = true;
            try
            {
                XmlSerializer MiSerializador = new XmlSerializer(typeof(Lapiz));

                using (System.IO.TextWriter MiEscritor = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.Path)) 
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

        bool IDeserializa.Xml(out Lapiz lapiz)
        {
            bool SeLeyo = true;
            lapiz = null;

            try
            {
                XmlSerializer DesSerializador = new XmlSerializer(typeof(Lapiz));

                using (System.IO.TextReader MiLector = new System.IO.StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.Path))
                {
                    lapiz = (Lapiz)DesSerializador.Deserialize(MiLector);
                }

            }
            catch (Exception)
            {
                SeLeyo = false;
            }

            return SeLeyo;
        }
    }
}