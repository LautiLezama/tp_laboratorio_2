using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace Entidades
{
    public class Xml<T> : IArchivos<T> where T : new()
    {
        /// <summary>
        /// (Aqui se aplica serializacion y Excepciones)Serializa el objeto pasado por parametro a un archivo xml ubicado en el escritorio.
        /// </summary>
        /// <param name="objeto">Objeto a serializar</param>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns>True en caso de guardarlo correctamente, caso contrario una excepcion de tipo ErrorArchivoException.</returns>
        public bool Guardar(T objeto, string nombreArchivo)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;

            try
            {
                writer = new XmlTextWriter(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, objeto);
                return true;
            }
            catch(Exception ex)
            {
                throw new ErrorArchivoException("Error en la serialización a XML: ", ex);
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
            }
        }

        /// <summary>
        /// (Aqui se aplica serializacion y Excepciones)Deserializa un archivo xml ubicado en el escritorio.
        /// </summary>
        /// <param name="nombreArchivo">Nombre del archivo</param>
        /// <returns>El objeto en caso de deserializar correctamente, caso contrario una excepcion de tipo ErrorArchivoException</returns>
        public T Leer(string nombreArchivo)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;
            T objeto;
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + nombreArchivo;

            try
            {
                if(ValidarArchivo(path))
                {
                    reader = new XmlTextReader(path);
                    serializer = new XmlSerializer(typeof(T));
                    objeto = (T)serializer.Deserialize(reader);
                    return objeto;
                }
                else
                {
                    throw new ErrorArchivoException("El archivo no existe.");
                }
            }
            catch (Exception ex)
            {
                throw new ErrorArchivoException("Error al intentar deserializar el archivo xml: ", ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }

        public bool ValidarArchivo(string archivo)
        {
            if (File.Exists(archivo))
            {
                return true;
            }
            return false;
        }
    }
}
