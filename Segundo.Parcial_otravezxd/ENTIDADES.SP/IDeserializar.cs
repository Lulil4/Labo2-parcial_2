using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTIDADES.SP
{//Xml(string, out Fruta):bool
    public interface IDeserializar
    {
        bool Xml(string s, out Fruta f);
    }
}
