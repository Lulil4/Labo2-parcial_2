using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
//IDeserializar -> Xml(string, out Fruta):bool
namespace Entidades.SP
{
    public interface IDeserializar
    {
        bool Xml(string path, out Fruta f);
    }
}
