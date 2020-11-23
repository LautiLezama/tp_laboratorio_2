using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ErrorArchivoException : Exception
    {
        public ErrorArchivoException() : base()
        {

        }
        public ErrorArchivoException(string msg) : base(msg)
        {

        }
        public ErrorArchivoException(string msg, Exception innerException) : base(msg, innerException)
        {

        }


    }
}
