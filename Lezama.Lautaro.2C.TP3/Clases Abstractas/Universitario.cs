using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_Abstractas
{
    public abstract class Universitario : Persona
    {
        private int legajo;

        #region Constructores
        public Universitario() : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Indica si el objeto es de tipo Universitario.
        /// </summary>
        /// <param name="obj">Objeto a verificar</param>
        /// <returns>True en caso de ser del mismo tipo, caso contrario false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Universitario;
        }

        /// <summary>
        /// Muestra los datos del Universitario.
        /// </summary>
        /// <returns>Los datos del Universitario</returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($"LEGAJO NUMERO: {this.legajo}");
            return sb.ToString();
        }
        protected abstract string ParticiparEnClase();
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga que compara si 2 universitarios son iguales.
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>True en caso de ser iguales, caso contrario false.</returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.Equals(pg2) && (pg1.legajo == pg2.legajo || pg1.DNI == pg2.DNI))
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga que comapra si 2 universitarios son distintos.
        /// </summary>
        /// <param name="pg1">Primer universitario</param>
        /// <param name="pg2">Segundo universitario</param>
        /// <returns>True en caso de ser distintos, caso contrario false.</returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}
