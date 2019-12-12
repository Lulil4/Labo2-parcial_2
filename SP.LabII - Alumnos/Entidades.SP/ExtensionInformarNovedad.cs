using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public static class ExtensionInformarNovedad
    {
        public static string InformarNovedad(this CartucheraLlenaException c)
        {
            return "La cartuchera esta llena!!";
        }
    }
}
