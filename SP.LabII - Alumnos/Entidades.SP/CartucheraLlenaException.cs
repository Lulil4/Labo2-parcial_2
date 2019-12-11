using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades.SP
{
    public class CartucheraLlenaException : Exception
    {
        public CartucheraLlenaException() : base("La cartuchera esta llena")
        {
        }

        public string InformarNovedad()
        {
            return "La cartuchera esta llena!!";
        }
    }
}
