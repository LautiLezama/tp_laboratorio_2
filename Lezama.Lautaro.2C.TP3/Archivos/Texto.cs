using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        /// <summary>
        /// Metodo que guarda en un archivo de texto los datos pasados por parametro
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>True en caso de guardar exitosamente, caso contrario una excepcion de tipo ArchivosException</returns>
        public bool Guardar(string archivo, string datos)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(archivo);
                streamWriter.WriteLine(datos);
                return true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        /// <summary>
        /// Metodo que lee los datos guardados en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos del archivo</param>
        /// <returns>True en caso de leer exitosamente, caso contrario una excepcion de tipo ArchivosException</returns>
        public bool Leer(string archivo, out string datos)
        {
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(archivo);
                datos = streamReader.ReadToEnd();
                return true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }
    }
}
