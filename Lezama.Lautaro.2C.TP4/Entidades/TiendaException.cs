using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class TiendaException : Exception
    {
        public TiendaException() : base()
        {

        }
        public TiendaException(string msg) : base(msg)
        {

        }
        public TiendaException(string msg, Exception innerException) : base(msg, innerException)
        {

        }
    }
}
