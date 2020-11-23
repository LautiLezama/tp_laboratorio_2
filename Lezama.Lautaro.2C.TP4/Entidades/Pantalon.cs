using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pantalon : Prenda
    {
        private EPantalon tipoPantalon;
        public enum EPantalon { Short, Skinny, Flare }

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para realizar la serialización.
        /// </summary>
        public Pantalon()
        {

        }

        public Pantalon(int codigo, float precio, EColor color, EPantalon tipoPantalon) : base(precio, color, codigo)
        {
            this.tipoPantalon = tipoPantalon;
        }
        #endregion 

        #region Propiedades
        public EPantalon TipoPantalon
        {
            get
            {
                return this.tipoPantalon;
            }
            set
            {
                this.tipoPantalon = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos necesarios a la hora de concretar una venta de un pantalon.
        /// </summary>
        /// <returns>Informacion del pantalon</returns>
        public override string MostrarInfoVenta()
        {
            return $"Pantalon {this.TipoPantalon} de color {this.Color} a ${this.Precio}";
        }
        /// <summary>
        /// Muestra toda la información del pantalon.
        /// </summary>
        /// <returns>Informacion del pantalon</returns>
        protected override string MostrarPrenda()
        {
            return $"{this.Codigo} - Pantalon - ${this.Precio} - {this.Color} - {this.tipoPantalon}";
        }
        public override string ToString()
        {
            return this.MostrarPrenda();
        }
        #endregion
    }
}
