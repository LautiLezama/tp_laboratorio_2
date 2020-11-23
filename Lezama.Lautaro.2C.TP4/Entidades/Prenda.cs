using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    [XmlInclude(typeof(Pantalon))]
    [XmlInclude(typeof(Remera))]
    [Serializable]
    public abstract class Prenda
    {
        private int codigo;
        private float precio;
        private EColor color;
        public enum EColor { Rojo, Azul, Amarillo, Violeta, Marron, Negro, Naranja, Blanco, Rosa, Gris, Verde, Celeste}
        public enum ETipoPrenda { Pantalon, Remera}
        #region Constructores
        /// <summary>
        /// Constructor sin parametros para realizar la serialización.
        /// </summary>
        public Prenda()
        {

        }
        public Prenda(float precio, EColor color, int codigo)
        {
            this.codigo = codigo;
            this.color = color;
            this.precio = precio;
        }
        #endregion

        #region Propiedades

        public int Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }
        public EColor Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }
        public float Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                this.precio = value;
            }
        }

        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos necesarios a la hora de concretar una venta de una prenda.
        /// </summary>
        /// <returns>Información de la prenda</returns>
        public virtual string MostrarInfoVenta()
        {
            return $"Prenda de color {this.color} a {this.precio}";
        }
        /// <summary>
        /// Muestra toda la información de la prenda.
        /// </summary>
        /// <returns>Informacion de la prenda</returns>
        protected virtual string MostrarPrenda()
        {
            return $"{this.codigo} - ${this.precio} - {this.color}";
        }

        public override string ToString()
        {
            return this.MostrarPrenda();
        }

        #endregion

        #region Operadores
        /// <summary>
        /// Sobrecarga del operador == que compara si dos prendas son iguales.
        /// </summary>
        /// <param name="p1">Prenda 1</param>
        /// <param name="p2">Prenda 2</param>
        /// <returns>True en caso de ser iguales, caso contrario false.</returns>
        public static bool operator ==(Prenda p1, Prenda p2)
        {
            if(p1.codigo == p2.codigo)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sobrecarga del operador != que compara si dos prendas son distintas.
        /// </summary>
        /// <param name="p1">Prenda 1</param>
        /// <param name="p2">Prenda 2</param>
        /// <returns>True en caso de ser distintas, caso contrario false.</returns>
        public static bool operator !=(Prenda p1, Prenda p2)
        {
            return !(p1 == p2);
        }
        #endregion
    }
}
