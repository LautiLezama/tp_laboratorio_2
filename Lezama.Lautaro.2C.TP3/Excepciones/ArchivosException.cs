using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class ArchivosException : Exception
    {
        public ArchivosException(Exception innerException)
        {
            throw innerException;
        }

        public ArchivosException(string message) : base(message)
        {

        }
    }
}
