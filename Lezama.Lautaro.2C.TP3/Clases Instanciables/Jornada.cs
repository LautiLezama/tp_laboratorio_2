using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Archivos;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Instanciables
{
    public class Jornada
    {
        private List<Alumno> alumnos;
        private Universidad.EClases clase;
        private Profesor instructor;

        #region Constructores
        public Jornada()
        {
            this.alumnos = new List<Alumno>();
        }

        public Jornada(Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.clase = clase;
            this.instructor = instructor;
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura de la colección de alumnos.
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
        /// Propiedad de lectura y escritura del atributo clase.
        /// </summary>
        public Universidad.EClases Clase
        {
            get
            {
                return this.clase;
            }
            set
            {
                this.clase = value;
            }
        }

        /// <summary>
        /// Propiedad de lectura y escritura del atributo instructor.
        /// </summary>
        public Profesor Instructor
        {
            get
            {
                return this.instructor;
            }
            set
            {
                this.instructor = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Metodo de clase que lee el archivo .txt que contiene las jornadas guardadas.
        /// </summary>
        /// <returns>En caso de leer correctamente, los datos del archivo, caso contrario una excepcion de tipo ArchivosException</returns>
        public static string Leer()
        {
            try
            {
                Texto txt = new Texto();
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt";
                string datos = string.Empty;
                txt.Leer(archivo, out datos);
                return datos;
            }
            catch(ArchivosException ex)
            {
                throw ex;
            }
            
        }
        /// <summary>
        /// Metodo de clase que guarda en un archivo .txt en el ESCRITORIO la jornada indicada por parametro.
        /// </summary>
        /// <param name="jornada">Jornada a guardar.</param>
        /// <returns>True en caso de guardarlo, caso contrario una excepcion de tipo ArchivosException</returns>
        public static bool Guardar(Jornada jornada)
        {
            try
            {
                Texto txt = new Texto();
                string archivo = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Jornada.txt";
                bool rta;
                rta = txt.Guardar(archivo, jornada.ToString());
                return rta;
            }
            catch(ArchivosException ex)
            {
                throw ex;
            }
            
        }

        /// <summary>
        /// Muestra los datos de la Jornada.
        /// </summary>
        /// <returns>Los datos de la jornada.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"CLASE DE {this.clase} POR {instructor.ToString()}");
            sb.AppendLine("ALUMNOS: ");
            foreach(Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            return sb.ToString();

        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga que compara que un alumno este en dicha jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True en caso de que el alumno pueda cursar esa jornada, caso contrario false.</returns>
        public static bool operator ==(Jornada j, Alumno a)
        {
            if(a == j.clase)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga que compara que un alumno NO este en dicha jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>True en caso de que el alumno NO pueda cursar esa jornada, caso contrario false.</returns>
        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j == a);
        }
        /// <summary>
        /// Sobrecarga que agrega un alumno a una jornada.
        /// </summary>
        /// <param name="j">Jornada</param>
        /// <param name="a">Alumno</param>
        /// <returns>Retorna la jornada.</returns>
        public static Jornada operator +(Jornada j, Alumno a)
        {
            if(j == a)
            {
                j.Alumnos.Add(a);
            }
            return j;
        }
        #endregion
    }
}
