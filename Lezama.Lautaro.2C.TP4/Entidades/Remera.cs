using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Remera : Prenda
    {
        private EManga tipoManga;
        public enum EManga { Manga_corta, Manga_larga, Musculosa }

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para poder serializar.
        /// </summary>
        public Remera()
        {

        }

        public Remera(int codigo, float precio, EColor color, EManga tipoManga) : base(precio, color, codigo)
        {
            this.tipoManga = tipoManga;
        }
        #endregion

        #region Propiedades
        public EManga TipoManga
        {
            get
            {
                return this.tipoManga;
            }
            set
            {
                this.tipoManga = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos necesarios a la hora de concretar una venta de una remera.
        /// </summary>
        /// <returns>Informacion de la remera</returns>
        public override string MostrarInfoVenta()
        {
            return $"Remera {this.tipoManga} de color {this.Color} a ${this.Precio}";
        }
        /// <summary>
        /// Muestra toda la información de la remera.
        /// </summary>
        /// <returns>Informacion de la remera</returns>
        protected override string MostrarPrenda()
        {
            return $"{this.Codigo} - Remera - ${this.Precio} - {this.Color} - {this.tipoManga}";
        }
        public override string ToString()
        {
            return this.MostrarPrenda();
        }
        #endregion
    }
}
