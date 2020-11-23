using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public class Texto : IArchivos<string>
    {
        /// <summary>
        /// (Aqui se aplica archivos de texto y Excepciones)Guarda los datos pasados por parametro en un archivo txt ubicado en el escritorio.
        /// </summary>
        /// <param name="datos">Datos a guardar</param>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns>True en caso de guardar correctamente, caso contrario lanzara una excepción de tipo ErrorArchivoException</returns>
        public bool Guardar(string datos, string nombreArchivo)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo, true);
                streamWriter.WriteLine(datos);
                return true;
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al intentar cargar el archivo txt: ", ex);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        /// <summary>
        /// (Aqui se aplica archivos de texto y Excepciones)Consulta y retorna todos los datos que hayan en el archivo especificado(ubicado en el escritorio).
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns>Datos del archivo en caso de leerlo correctamente, caso contrario una excepcion de tipo ErrorArchivoException</returns>
        public string Leer(string nombreArchivo)
        {
            StreamReader streamReader = null;
            string datos = String.Empty;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;
            try
            {
                if(ValidarArchivo(path))
                {
                    streamReader = new StreamReader(path);
                    datos = streamReader.ReadToEnd();
                    return datos;
                }
                else
                {
                    throw new ErrorArchivoException("El archivo no existe.");
                }
                
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al intentar leer el archivo txt: ", ex);
            }
            finally
            {
                if (streamReader != null)
                    streamReader.Close();
            }
        }

        /// <summary>
        /// Valida que el archivo exista.
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <returns>True en caso de existir, caso contrario false</returns>
        public bool ValidarArchivo(string archivo)
        {
            if(File.Exists(archivo))
            {
                return true;
            }
            return false;
        }
    }
}
