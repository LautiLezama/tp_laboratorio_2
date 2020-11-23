using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmContraseña : Form
    {
        private string contraseñaIngresada;
        public FrmContraseña()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {

            this.contraseñaIngresada = txtContraseña.Text;
            this.Close();
        }

        public string ContraseñaIngresada
        {
            get
            {
                return this.contraseñaIngresada;
            }
            set
            {
                this.contraseñaIngresada = value;
            }
        }

    }
}
