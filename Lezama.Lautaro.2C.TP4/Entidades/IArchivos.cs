using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    interface IArchivos<T>
    {
        bool Guardar(T objeto, string nombreArchivo);
        T Leer(string nombreArchivo);

        bool ValidarArchivo(string ruta);
    }
}
