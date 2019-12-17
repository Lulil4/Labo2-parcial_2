using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ENTIDADES.SP
{        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
         //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true

    public class Manzana : Fruta, ISerializar, IDeserializar
    {
        protected string _provinciaOrigen;

        public string ProvinciaOrigen
        { get { return this._provinciaOrigen; } set { this._provinciaOrigen = value; } }

        public Manzana() : this("vacio", 0, "vacio")
        {
        }


        public string Nombre
        {
            get
            {
                return "Manzana";
            }
        }

        public override bool TieneCarozo
        {
            get
            {
                return true;
            }
        }

        public Manzana(string color, double peso, string provincia) : base(color, peso)
        {
            this._provinciaOrigen = provincia;
        }

        public override string ToString()
        {
            return this.FrutaToString() + "|Provincia de origen: " + this._provinciaOrigen;
        }

        public bool Xml(string s)
        {
            bool seGuardo = true;

            try
            {
                XmlSerializer ser = new XmlSerializer(typeof(Manzana));

                using (System.IO.TextWriter escritor = new System.IO.StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + s))
                {
                    ser.Serialize(escritor, this);
                }
            }
            catch (Exception)
            {
                seGuardo = false;
            }
            return seGuardo;
        }

        bool IDeserializar.Xml(string s, out Fruta f)
        {
            bool seLeyo = true;
            f = null;

            try
            {
                XmlSerializer des = new XmlSerializer(typeof(Manzana));

                using (System.IO.TextReader lector = new System.IO.StreamReader(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + s))
                {
                    f = (Manzana)des.Deserialize(lector);
                }

            }
            catch (Exception)
            {
                seLeyo = false;
            }

            return seLeyo;
        }
    }
}
