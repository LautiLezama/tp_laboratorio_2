using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;


namespace Entidades
{
    public static class Extension
    {
        /// <summary>
        /// (Aqui se aplica Extension)Calcula las horas que esta abierta la tienda.
        /// </summary>
        /// <param name="horaInicio">Hora en la que abre la tienda.</param>
        /// <param name="horaFin">Hora en la que cierra la tienda</param>
        /// <returns>Las horas que esta abierta la tienda</returns>
        public static int HorasAbierto(this int horaInicio, int horaFin)
        {
            
            int horasAbierto;
            horasAbierto = horaFin - horaInicio;
            return horasAbierto;
        }

        /// <summary>
        /// (Aqui se aplica Extension y Excepciones)En caso de tener solo numeros, parsea una cadena(string) y la retorna en un entero.
        /// </summary>
        /// <param name="cadena">String a parsear</param>
        /// <returns>Entero parseado</returns>
        public static int ValidarParsearInt(this string cadena)
        {
            int numeroFinal;
            foreach (char c in cadena)
            {
                if (!char.IsDigit(c))
                {
                    throw new NoEsNumeroException("El codigo no debe contener algo que no sea numeros.");
                }
            }
            int.TryParse(cadena, out numeroFinal);
            return numeroFinal;
        }

        /// <summary>
        /// (Aqui se aplica Extension y Excepciones)En caso de tener solo numeros(y como máximo una ,)parsea una cadena(string) y lo retorna en float.
        /// </summary>
        /// <param name="cadena">String a parsear</param>
        /// <returns>Float parseado</returns>
        public static float ValidarParsearPrecio(this string cadena)
        {
            float numeroFinal;
            int flagPunto = 0;
            foreach (char c in cadena)
            {

                if(c == ',' && flagPunto == 0)
                {
                    flagPunto = 1;
                    continue;
                }

                if (!char.IsDigit(c))
                {
                    throw new NoEsNumeroException("El precio debe tener numeros y una coma en caso de no ser entero.");
                }
            }
            float.TryParse(cadena, out numeroFinal);
            return numeroFinal;
        }
    }
}
