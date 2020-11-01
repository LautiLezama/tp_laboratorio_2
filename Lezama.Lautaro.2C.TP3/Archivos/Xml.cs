using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using Excepciones;

namespace Archivos
{
    public class Xml <T> : IArchivo<T>
    {
        /// <summary>
        /// Metodo encargado de Serializar a .xml los datos pasados por parametro
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Datos del archivo</param>
        /// <returns>True en caso de serializar correctamente, caso contrario una excepcion de tipo ArchivosException</returns>
        public bool Guardar(string archivo, T datos)
        {
            XmlTextWriter writer = null;
            XmlSerializer serializer = null;

            try
            {
                writer = new XmlTextWriter(archivo, Encoding.UTF8);
                writer.Formatting = Formatting.Indented;
                serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(writer, datos);
                return true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
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
        /// Metodo que deserializa los datos que hayan en el archivo ubicado en la ruta pasada por parametro
        /// </summary>
        /// <param name="archivo">Ruta del archivo</param>
        /// <param name="datos">Donde se almacenan los datos</param>
        /// <returns>True en caso de deserializar correctamente, caso contrario una excepcion de tipo ArchivosException</returns>
        public bool Leer(string archivo, out T datos)
        {
            XmlTextReader reader = null;
            XmlSerializer serializer = null;

            try
            {
                reader = new XmlTextReader(archivo);
                serializer = new XmlSerializer(typeof(T));
                datos = (T)serializer.Deserialize(reader);
                return true;
            }
            catch(Exception ex)
            {
                throw new ArchivosException(ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

        }
    }
}
