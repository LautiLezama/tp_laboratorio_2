using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Metodo que realiza una operacion entre 2 numeros de la clase Numero
        /// </summary>
        /// <param name="num1">Primer numero.</param>
        /// <param name="num2">Segundo numero.</param>
        /// <param name="operador">Tipo de operacion.</param>
        /// <returns>Retorna el resultado entre la operación de ambos números.</returns>
        public static double Operar(Numero num1, Numero num2, string operador)
        {
            char auxOperador;
            char.TryParse(operador, out auxOperador);
            operador = ValidarOperador(auxOperador);
            double resultado=0;
            switch (operador)
            {
                case "+":
                    resultado= num1 + num2;
                    break;
                case "-":
                    resultado = num1 - num2;
                    break;
                case "*":
                    resultado = num1 * num2;
                    break;
                case "/":
                    resultado = num1 / num2;
                    break;
            }
            return resultado;
        }

        /// <summary>
        /// Metodo encargado de validar que el operador sea +,-,/ o *.
        /// </summary>
        /// <param name="operador">Operador a validar.</param>
        /// <returns>En caso de ser un operador valido lo retorna como tal, caso contrario retorna +</returns>
        private static string ValidarOperador(char operador)
        {
            if (operador == '+' || operador == '-' || operador == '/' || operador == '*')
            {
                return Char.ToString(operador);
            }
            else
            {
                operador = '+';
                return Char.ToString(operador); ;
            }
        }
    }
}
