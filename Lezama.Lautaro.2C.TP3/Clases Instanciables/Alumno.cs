using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excepciones;
using Clases_Abstractas;

namespace Clases_Instanciables
{
    public sealed class Alumno : Universitario
    {
        private Universidad.EClases claseQueToma;
        private EEstadoCuenta estadoCuenta;
        public enum EEstadoCuenta { AlDia, Deudor, Becado}

        #region Constructores
        public Alumno() : base()
        {

        }

        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this.claseQueToma = claseQueToma;
        }
        
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this.estadoCuenta = estadoCuenta;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del Alumno
        /// </summary>
        /// <returns>Los datos del Alumno</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine($"ESTADO DE CUENTA: {this.estadoCuenta}");
            sb.AppendLine($"{this.ParticiparEnClase()}");
            return sb.ToString();
        }
        /// <summary>
        /// Muestra las clases en las que participa el Alumno.
        /// </summary>
        /// <returns>Las clases que toma el Alumno.</returns>
        protected override string ParticiparEnClase()
        {
            return $"TOMA CLASE DE {this.claseQueToma}";
        }
        /// <summary>
        /// Hace publicos los datos del Alumno.
        /// </summary>
        /// <returns>Los datos del Alumno.</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga que compara si un alumno puede tomar dicha clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True en caso de poder tomar la clase, caso contrario false.</returns>
        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a.claseQueToma == clase && a.estadoCuenta != EEstadoCuenta.Deudor)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga que compara si un alumno NO toma dicha clase.
        /// </summary>
        /// <param name="a">Alumno</param>
        /// <param name="clase">Clase</param>
        /// <returns>True en caso de no poder tomar la clase, caso contrario false.</returns>
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            return !(a == clase);
        }
        #endregion


    }
}
