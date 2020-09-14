using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {   
        private double numero;
        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public Numero()
        {
            this.numero = 0;
        }

        /// <summary>
        /// Constructor que recibe el atributo numero.
        /// </summary>
        /// <param name="numero">El numero que recibe.</param>
        public Numero(double numero)
        {
            this.numero = numero;
        }

        /// <summary>
        /// Constructor que recibe un numero en formato string y lo setea en el atributo numero a traves de SetNumero.
        /// </summary>
        /// <param name="strNumero">El numero en formato string.</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Metodo encargado de validar que lo ingresado(en formato string) sea un número.
        /// </summary>
        /// <param name="strNumero">Numero en formato string.</param>
        /// <returns>En caso de ser un número lo retorna como tal, caso contrario retorna 0.</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero = 0;
            if(double.TryParse(strNumero, out numero))
            {
                return numero;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Propiedad encargada de Settear un numero en formato string al atributo numero de la clase.
        /// </summary>
        public string SetNumero
        {
            set
            {
                double numero = ValidarNumero(value);
                this.numero = numero;
            }
        }

        /// <summary>
        /// Metodo encargado de validar si el numero(en formato string) es binario.
        /// </summary>
        /// <param name="binario">Numero en formato string.</param>
        /// <returns>En caso de ser binario retorna true, caso contrario retorna false.</returns>
        private static bool EsBinario(string binario)
        {
            for(int i = 0; i<binario.Length;i++)
            {
                if(binario[i] != '0' && binario[i] != '1')
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Metodo encargado de convertir un numero binario(en formato string) a un numero decimal.
        /// </summary>
        /// <param name="binario">Binario en formato string</param>
        /// <returns>En caso de que el numero sea binario retorna el decimal(en formato string), caso contrario retorna "Valor invalido"</returns>
        public static string BinarioDecimal(string binario)
        {
            if(EsBinario(binario))
            {
                return Convert.ToInt32(binario, 2).ToString();
            }
            return "Valor inválido";
            
        }

        /// <summary>
        /// Metodo encargado de convertir un numero decimal a un numero binario.
        /// </summary>
        /// <param name="numero">Numero decimal.</param>
        /// <returns>Retorna el numero binario en formato string.</returns>
        public static string DecimalBinario(double numero)
        {
            int numInt = (int)numero;
            int remainder;
            string resultado = string.Empty;
            while (numInt > 0)
            {
                remainder = numInt % 2;
                numInt /= 2;
                resultado = remainder.ToString() + resultado;
            }
            return resultado;
        }

        /// <summary>
        /// Metodo encargado de convertir el numero decimal(en formato string) a un numero binario.
        /// </summary>
        /// <param name="numero">Numero decimal en formato string.</param>
        /// <returns>Retorna el numero binario en formato string.</returns>
        public static string DecimalBinario(string numero)
        {
            string resultado = "Valor inválido";
            int numeroInt;
            int.TryParse(numero, out numeroInt);
            if(numeroInt > 0)
            {
                resultado = DecimalBinario(numeroInt);
            }
            return resultado;
        }

        /// <summary>
        /// Operador encargado de sumar 2 numeros de clase Numero.
        /// </summary>
        /// <param name="n1">Primer numero.</param>
        /// <param name="n2">Segundo numero.</param>
        /// <returns>El resultado de la operacion.</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        /// <summary>
        /// Operador encargado de restar 2 numeros de clase Numero.
        /// </summary>
        /// <param name="n1">Primer numero.</param>
        /// <param name="n2">Segundo numero.</param>
        /// <returns>El resultado de la operacion.</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        /// <summary>
        /// Operador encargado de dividir 2 numeros de clase Numero.
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero.</param>
        /// <returns>El resultado de la operacion. En caso de que el segundo numero sea 0 retorna el valor minimo de double.</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero == 0)
            {
                return double.MinValue;
            }
            return n1.numero / n2.numero;
        }

        /// <summary>
        /// Operador encargado de multiplicar 2 numeros de clase Numero.
        /// </summary>
        /// <param name="n1">Primer numero</param>
        /// <param name="n2">Segundo numero.</param>
        /// <returns>El resultado de la operacion.</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }
    }
}
