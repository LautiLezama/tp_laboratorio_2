using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Archivos;
using Excepciones;

namespace Clases_Instanciables
{
    public class Universidad
    {
        private List<Alumno> alumnos;
        private List<Jornada> jornada;
        private List<Profesor> profesores;
        public enum EClases { Programacion, Laboratorio, Legislacion, SPD }
        #region Constructor
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornada = new List<Jornada>();
            profesores = new List<Profesor>();
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de la lista de alumnos.
        /// </summary>
        public List<Alumno> Alumnos
        {
            get
            {
                return this.alumnos;
            }
            set
            {
                this.alumnos = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de la lista de profesores.
        /// </summary>
        public List<Profesor> Instructores
        {
            get
            {
                return this.profesores;
            }
            set
            {
                this.profesores = value;
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura de la lista de Jornadas.
        /// </summary>
        public List<Jornada> Jornadas
        {
            get
            {
                return this.jornada;
            }
            set
            {
                this.jornada = value;
            }
        }
        /// <summary>
        /// Indexador de lectura y escritura de un indice de la lista de Jornadas.
        /// </summary>
        /// <param name="i">Indice</param>
        /// <returns>La jornada indicada según el indice.</returns>
        public Jornada this[int i]
        {
            get
            {
                return this.jornada[i];
            }
            set
            {
                this.jornada[i] = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo que se encargar de serializar los datos de la universidad en un archivo .xml ubicado en el ESCRITORIO.
        /// </summary>
        /// <param name="uni">Universidad a serializar</param>
        /// <returns>True en caso de que no hubo error, caso contrario excepcion de tipo ArchivosException</returns>
        public static bool Guardar(Universidad uni)
        {
            try
            {
                Xml<Universidad> elxml = new Xml<Universidad>();
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml";
                bool rta = elxml.Guardar(archivo, uni);
                return rta;
            }
            catch (ArchivosException ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Metodo que se encarga de deserializar el archivo xml con los datos de la universidad.
        /// </summary>
        /// <returns>En caso de deserializar correctamente, retorna la universidad, caso contrario una excepcion de tipo ArchivosException</returns>
        public static Universidad Leer()
        {
            try
            {
                Xml<Universidad> xml = new Xml<Universidad>();
                Universidad uni = new Universidad();
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Universidad.xml";
                xml.Leer(String.Format("{0}\\Universidad.xml", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)), out uni);
                return uni;
            }
            catch(ArchivosException ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Muestra los datos de la universidad.
        /// </summary>
        /// <returns>Datos de la universidad</returns>
        private string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("JORNADA: ");
            foreach(Jornada j in this.Jornadas)
            {
                sb.AppendLine(j.ToString());
                sb.AppendLine("<---------------------------------------------->");
            }

            return sb.ToString();
        }
        /// <summary>
        /// Hace publicos los datos de la universidad.
        /// </summary>
        /// <returns>Datos de la universidad.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga que compara que un alumno NO este en dicha universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True en caso de que el alumno NO este en la universidad, caso contrario false</returns>
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }
        /// <summary>
        /// Sobrecarga que compara que un profesor NO este en dicha universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True en caso de que el profesor NO este en la universidad, caso contrario false</returns>
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);
        }
        /// <summary>
        /// Sobrecarga que devuelve el primer profesor que NO pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>El primer profesor que no puede dar la clase, caso de no haber ninguno una excepcion de tipo SinProfesorException</returns>
        public static Profesor operator !=(Universidad u, EClases clase)
        {
            foreach (Profesor profe in u.Instructores)
            {
                if (profe != clase)
                {
                    return profe;
                }
            }
            throw new SinProfesorException("Todos los profesores dan esa clase");
        }
        /// <summary>
        /// Sobrecarga que compara que un alumno este en dicha universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>True en caso de que el alumno este en la universidad, caso contrario false</returns>
        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (alumno == a)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga que compara que un profesor este en dicha universidad
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>True en caso de que el profesor este en la universidad, caso contrario false</returns>
        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profe in g.Instructores)
            {
                if (profe == i)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga que busca al primer profesor que pueda dar la clase.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="clase">Clase</param>
        /// <returns>El primer profesor que pueda dar la clase, caso de no haber ninguno una excepcion de tipo SinProfesorException</returns>
        public static Profesor operator ==(Universidad u, EClases clase)
        {
            foreach (Profesor profe in u.Instructores)
            {
                if (profe == clase)
                {
                    return profe;
                }
            }
            throw new SinProfesorException("No hay profesor para la clase.");
        }
        /// <summary>
        /// Sobrecarga que se encarga de añadir una jornada a la universidad.
        /// </summary>
        /// <param name="g">Universidad</param>
        /// <param name="clase">Clase de la jornada.</param>
        /// <returns>La misma universidad a la que se agrego la clase, en caso de que no haya profesor para dicha clase una excepcion de tipo SinProfesorException</returns>
        public static Universidad operator +(Universidad g, EClases clase)
        {
            try
            {
                Jornada jornada = new Jornada(clase, g == clase);

                foreach (Alumno alumno in g.Alumnos)
                {
                    if (alumno == clase)
                    {
                        jornada += alumno;
                    }
                }

                g.Jornadas.Add(jornada);
                return g;
            }
            catch(SinProfesorException ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Sobrecargar que se encarga de añadir un alumno a dicha universidad.
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="a">Alumno</param>
        /// <returns>Caso de añadirlo correctamente retornara la universidad, caso de que el alumno ya este en la universidad una excepcion de tipo AlumnoRepetidoException</returns>
        public static Universidad operator +(Universidad u, Alumno a)
        {
            if (u != a)
            {
                u.Alumnos.Add(a);
            }
            else
            {
                throw new AlumnoRepetidoException("Alumno repetido");
            }
            return u;
        }
        /// <summary>
        /// Sobrecarga que se encarga de añadir un profesor a la universidad
        /// </summary>
        /// <param name="u">Universidad</param>
        /// <param name="i">Profesor</param>
        /// <returns>La universidad</returns>
        public static Universidad operator +(Universidad u, Profesor i)
        {
            if (u != i)
            {
                u.Instructores.Add(i);
            }
            return u;
        }
        #endregion
    }
}
