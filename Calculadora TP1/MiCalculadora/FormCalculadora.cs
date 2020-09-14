using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo encargado de crear las instancias de la clase Numero y llamar al metodo que opera entre ellas.
        /// </summary>
        /// <param name="numero1">Primer numero ingresado en formato string.</param>
        /// <param name="numero2">Segundo numero ingresado en formato string.</param>
        /// <param name="operador">La operacion que se realizara entre ambos numeros.</param>
        /// <returns>El resultado de la operacion.</returns>
        private static double Operar(string numero1, string numero2, string operador)
        {
            double resultado;
            Numero num1 = new Numero(numero1);
            Numero num2 = new Numero(numero2);
            resultado = Calculadora.Operar(num1, num2, operador);
            return resultado;
        }

        /// <summary>
        /// Metodo que se encarga de limpiar los textbox, el label de resultado y el combobox de los operadores.
        /// </summary>
        public void Limpiar()
        {
            this.lblResultado.Text = "Resultado";
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.cmbOperador.Text = null;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            if (cmbOperador.Text == "")
            {

            }
            else
            {
                double resultado = Operar(this.txtNumero1.Text, this.txtNumero2.Text, cmbOperador.Text);
                lblResultado.Text = resultado.ToString();
            }

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Resultado")
            {
                lblResultado.Text = Numero.DecimalBinario(lblResultado.Text);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "Resultado")
            {
                lblResultado.Text = Numero.BinarioDecimal(lblResultado.Text);
            }
        }

    }
}
