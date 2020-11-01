using Clases_Abstractas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue<Universidad.EClases> clasesDelDia;
        private static Random random;

        #region Constructores
        static Profesor()
        {
            random = new Random();
        }

        public Profesor() : base()
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            :base(id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos del Profesor
        /// </summary>
        /// <returns>Los datos del profesor</returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());
            return sb.ToString();
        }
        /// <summary>
        /// Asigna 2 clases aleatorias(deben estar dentro del enum EClases) al profesor.
        /// </summary>
        private void _randomClases()
        {
            Array values = Enum.GetValues(typeof(Universidad.EClases));
            this.clasesDelDia.Enqueue((Universidad.EClases)values.GetValue(random.Next(values.Length)));
            Thread.Sleep(20);
            this.clasesDelDia.Enqueue((Universidad.EClases)values.GetValue(random.Next(values.Length)));
        }
        /// <summary>
        /// Muestra que clases da el profesor ese día.
        /// </summary>
        /// <returns>Las clases que da el profesor.</returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("CLASES DEL DÍA: ");
            foreach (Universidad.EClases clase in this.clasesDelDia)
            {
                sb.AppendLine($"{clase}");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Hace publicos los datos del Profesor
        /// </summary>
        /// <returns>Los datos del profesor</returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga que compara que un profesor de esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">La clase a comparar</param>
        /// <returns>True en caso de que el profesor de esa clase, caso contrario false.</returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases laClase in i.clasesDelDia)
            {
                if(laClase == clase)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga que compara que un profesor NO de esa clase.
        /// </summary>
        /// <param name="i">Profesor</param>
        /// <param name="clase">La clase a comparar</param>
        /// <returns>True en caso de que el profesor NO de esa clase, caso contrario false.</returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }
        #endregion




    }
}
