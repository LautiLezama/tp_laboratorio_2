using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class NoEsNumeroException : Exception
    {
        public NoEsNumeroException() : base()
        {

        }
        public NoEsNumeroException(string msg) : base(msg)
        {

        }
        public NoEsNumeroException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
    }
}
