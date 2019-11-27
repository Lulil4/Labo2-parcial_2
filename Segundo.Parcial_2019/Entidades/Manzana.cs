using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
//Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

namespace Entidades.SP
{
    public class Manzana: Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string ProvinciaOrigen
        { get { return this._provinciaOrigen; } set { this._provinciaOrigen = value; } }

        public string Nombre
        {
            get
            {
                return "Manzana";
            }
        }
        public Manzana() : this("vacio", 0, "vacio")
        {
        }

        public Manzana (string color, double peso, string provincia) : base(color, peso)
        {
            this._provinciaOrigen = provincia;
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
            return  "Nombre: " + this.Nombre + "\nProvincia de origen: " + this._provinciaOrigen + base.FrutaToString();
        }

        public bool Xml(string path)
        {
            bool SeGuardo = true;

            try
            {
                XmlSerializer MiSerializador = new XmlSerializer(typeof(Manzana));

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

        bool IDeserializar.Xml(string path, out Fruta f)
        {
            bool SeLeyo = true;
            f = null;

            try
            {
                XmlSerializer DesSerializador = new XmlSerializer(typeof(Manzana));

                using (System.IO.TextReader MiLector = new System.IO.StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + path))
                {
                    f = (Manzana)DesSerializador.Deserialize(MiLector);
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
