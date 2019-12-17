using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTIDADES.SP;
using System.Data.SqlClient;

namespace SP
{
    //DESARROLLAR DENTRO DEL NAMESPACE RAIZ ENTIDADES.SP EN UN PROYECTO DE TIPO CLASS LIBRARY

    public partial class SegundoParcial: Form
    {
        private Manzana _manzana;
        private Banana _banana;
        private Durazno _durazno;

        public Cajon<Manzana> c_manzanas;
        public Cajon<Banana> c_bananas;
        public Cajon<Durazno> c_duraznos;

        public SegundoParcial()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Apellido y nombre del alumno...");
        }

        //Crear la siguiente jerarquía de clases:
        //Fruta-> _color:string y _peso:double (protegidos); TieneCarozo:bool (prop. s/l, abstracta);
        //constructor con 2 parametros y FrutaToString():string (protegido y virtual, retorna los valores de la fruta)
        //Manzana-> _provinciaOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Manzana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Banana-> _paisOrigen:string (protegido); Nombre:string (prop. s/l, retornará 'Banana'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->false
        //Durazno-> _cantPelusa:int (protegido); Nombre:string (prop. s/l, retornará 'Durazno'); 
        //Reutilizar FrutaToString en ToString() (mostrar todos los valores). TieneCarozo->true
        //Crear una instancia de cada clase e inicializar los atributos del form _manzana, _banana y _durazno. 
        private void btnPunto1_Click(object sender, EventArgs e)
        {
            this._manzana = new Manzana("verde", 2, "rio negro");
            this._banana = new Banana("amarillo", 5, "ecuador");
            this._durazno = new Durazno("rojo", 2.5, 53);

            MessageBox.Show(this._manzana.ToString());
            MessageBox.Show(this._banana.ToString());
            MessageBox.Show(this._durazno.ToString());

        }

        //Crear la clase Cajon<T>
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
        private void btnPunto2_Click(object sender, EventArgs e)
        {
            this.c_manzanas = new Cajon<Manzana>(1.58, 3);
            this.c_bananas = new Cajon<Banana>(15.96, 4);
            this.c_duraznos = new Cajon<Durazno>(21.5, 1);

            this.c_manzanas += new Manzana("roja", 1, "neuquen");
            this.c_manzanas += this._manzana;
            this.c_manzanas += new Manzana("amarilla", 3, "san juan");

            this.c_bananas += new Banana("verde", 3, "brasil");
            this.c_bananas += this._banana;

            this.c_duraznos += this._durazno;

            MessageBox.Show(this.c_manzanas.ToString());
            MessageBox.Show(this.c_bananas.ToString());
            MessageBox.Show(this.c_duraznos.ToString());

        }

        //Crear las interfaces: 
        //ISerializar -> Xml(string):bool
        //IDeserializar -> Xml(string, out Fruta):bool
        //Implementar (implicitamente) ISerializar en Cajon y manzana
        //Implementar (explicitamente) IDeserializar en manzana
        //Los archivos .xml guardarlos en el escritorio del cliente
        private void btnPunto3_Click(object sender, EventArgs e)
        {
            Fruta aux = null;

            if (this._manzana.Xml("manzana.xml"))
            {
                MessageBox.Show("Manzana serializada OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

            if (((IDeserializar)this._manzana).Xml("manzana.xml", out aux))
            {
                MessageBox.Show("Manzana deserializada OK");
                MessageBox.Show(((Manzana)aux).ToString());
            }
            else
            {
                MessageBox.Show("NO Deserializado");
            }

            if (this.c_manzanas.Xml("manzanas.xml"))
            {
                MessageBox.Show("Cajon de Manzanas serializado OK");
            }
            else
            {
                MessageBox.Show("NO Serializado");
            }

        }

        //Si se intenta agregar frutas al cajón y se supera la cantidad máxima, se lanzará un CajonLlenoException, 
        //cuyo mensaje explicará lo sucedido.
        private void btnPunto4_Click(object sender, EventArgs e)
        {
            //implementar estructura de manejo de excepciones
            try
            {
                this.c_duraznos += this._durazno;
            }
            catch(CajonLlenoException errorCajon)
            {
                MessageBox.Show(errorCajon.Message);
            }

        }

        //Si el precio total del cajon supera los 55 pesos, se disparará el evento EventoPrecio. 
        //Diseñarlo (de acuerdo a las convenciones vistas) en la clase cajon. 
        //Crear el manejador necesario para que se imprima en un archivo de texto: 
        //la fecha (con hora, minutos y segundos) y el total del precio del cajón en un nuevo renglón.
        private void btnPunto5_Click(object sender, EventArgs e)
        {
            Manejadora<Banana> m = new Manejadora<Banana>();
            //Asociar manejador de eventos y crearlo en la clase Manejadora (de instancia).

            //this.c_bananas._eventoPrecio += new Cajon<Banana>.EventoPrecio(m.ManejadorEventoPrecio);
            this.c_bananas._eventoPrecio += m.ManejadorEventoPrecio;

            this.c_bananas += new Banana("verde", 2, "argentina");
            this.c_bananas += new Banana("amarilla", 4, "ecuador");
        }

        //Obtener de la base de datos (sp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        //Invocar al método ObtenerListadoFrutas.
        private void btnPunto6_Click(object sender, EventArgs e)
        {
            MessageBox.Show(SegundoParcial.ObtenerListadoFrutas());
        }

        //Agregar en la base de datos las frutas del formulario (_manzana, _banana y _durazno).
        //Invocar al metodo AgregarFrutas():bool
        private void btnPunto7_Click(object sender, EventArgs e)
        {
            if (SegundoParcial.AgregarFrutas(this))
            {
                MessageBox.Show("Se agregaron las frutas a la Base de Datos");
            }
            else
            {
                MessageBox.Show("NO se agregaron las frutas a la Base de Datos");
            }
        }

        //Agregar un método de extensión a la clase Cajon que:
        //Reciba como parámetro un entero (será usado como valor del campo ID)
        //Elimine de la base de datos la fruta cuyo ID coincida con el parámetro recibido
        //Retorne un booleano que indique: 
        //TRUE, si se ha eliminado la fruta. 
        //FALSE, si no se elimino.
        //Excepción, si se probocó algún error en la base de datos
        private void btnPunto8_Click(object sender, EventArgs e)
        {
            //implementar manejo de excepciones
            try
            {
                if (this.c_manzanas.EliminarFruta(1))
                {
                    MessageBox.Show("Se ha eliminado la fruta de la base de datos");
                }
                else
                {
                    MessageBox.Show("No se ha eliminado la fruta de la base de datos");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
            //implementar manejo de excepciones
            try
            {
                if (this.c_manzanas.EliminarFruta(1))
                {
                    MessageBox.Show("Se ha eliminado la fruta de la base de datos");
                }
                else
                {
                    MessageBox.Show("No se ha eliminado la fruta de la base de datos");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
        //Obtener de la base de datos (sp_lab_II) el listado de frutas:
        //frutas { id(autoincremental - numérico) - nombre(cadena) - peso(numérico) - precio(numérico) }. 
        private static string ObtenerListadoFrutas()
        {
            StringBuilder datosEnDB = new StringBuilder();
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion);
            SqlCommand com = new SqlCommand();
            SqlDataReader lector;

            try
            {
                com.Connection = con;
                con.Open();

                com.CommandType = CommandType.Text;
                com.CommandText = "select * FROM [sp_lab_II].[dbo].[frutas]";

                lector = com.ExecuteReader();

                while (lector.Read() != false)
                {
                    datosEnDB.AppendLine("Id: " + lector[0].ToString() + "| Nombre: " + lector[1].ToString() + "| Peso:" + lector[2] + "| Precio: " + lector[3]);
                }

                lector.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                con.Close();
            }
            return datosEnDB.ToString();
        }

        private static bool AgregarFrutas(SegundoParcial frm)
        {
            bool seAgregaron = true;
            SqlConnection con = new SqlConnection(Properties.Settings.Default.conexion);
            SqlCommand com = new SqlCommand();

            try
            {
                con.Open();
                com.Connection = con;
                com.CommandType = CommandType.Text;

                StringBuilder unosComandos = new StringBuilder();
                unosComandos.AppendLine("insert into [sp_lab_II].[dbo].[frutas] values ('" + frm._manzana.Nombre + "', " + 12.9 + ", " + frm._manzana.Peso + ")");
                unosComandos.AppendLine("insert into [sp_lab_II].[dbo].[frutas] values ('" + frm._banana.Nombre + "', " + 13.6 + ", " + frm._banana.Peso + ")");
                unosComandos.AppendLine("insert into [sp_lab_II].[dbo].[frutas]  values ('" + frm._durazno.Nombre + "', " + 14.8 + ", " + frm._durazno.Peso + ")");

                com.CommandText = unosComandos.ToString();

                com.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                seAgregaron = false;
                MessageBox.Show(e.Message);
            }
            return seAgregaron;
        }

    }
}
