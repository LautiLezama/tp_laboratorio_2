using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Entidades;

namespace Formularios
{
    public partial class FrmTienda : Form
    {
        delegate void Callback();
        private Tienda tienda;
        private List<Thread> hilos;
        /// <summary>
        /// Al construir el form crea la tienda que se va a manejar durante todo el programa y suscribe el metodo de simulación al evento EventoTiempo.
        /// </summary>
        public FrmTienda()
        {
            InitializeComponent();
            this.tienda = new Tienda("La tienda de Pepito", "Calle Falsa 123", 8, 16);
            this.Text = this.tienda.Nombre + " - " + this.tienda.Direccion + " - " + $"De {this.tienda.HorarioInicio} a {this.tienda.HorarioFin}";
            this.tienda.EventoTiempo += SimulacionDeVentas;
            this.hilos = new List<Thread>();
            PrendaDAO prendaDAO = new PrendaDAO();
            this.tienda.Prendas = prendaDAO.ListarPrendas();
        }
        /// <summary>
        /// Instancia un formulario donde se extraera un dato, en caso de ser la contraseña correcta se instanciara el formulario respectivo al administrador de la tienda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            FrmContraseña contra = new FrmContraseña();
            contra.ShowDialog();
            if (contra.ContraseñaIngresada == "admin")
            {
                FrmAdministracion admin = new FrmAdministracion(this.tienda);
                admin.ShowDialog();
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// (Aqui se aplica hilos)Comienza la simulación de la tienda, iniciando el hilo con el metodo Vendiendo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAbrirNegocio_Click(object sender, EventArgs e)
        {   
            
            if(this.tienda.Prendas.Count == 0)
            {
                MessageBox.Show("No abras la tienda si no hay ningún producto!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                lstVendidos.Items.Clear();
                Thread hilo = new Thread(new ThreadStart(this.tienda.Vendiendo));
                this.hilos.Add(hilo);
                hilo.Start();
                this.picTiendaCerrada.Visible = false;
                this.picTiendaAbierta.Visible = true;
                this.btnAbrirNegocio.Enabled = false;
                this.btnReporteGeneral.Enabled = false;
                this.btnAdministracion.Enabled = false;
            }
        }
        /// <summary>
        /// Usa el callback para invocarse desde el hilo principal y simular las ventas de la tienda.
        /// </summary>
        private void SimulacionDeVentas()
        {
            if (lstVendidos.InvokeRequired)
            {
                Callback del = new Callback(SimulacionDeVentas);
                this.Invoke(del);
            }
            else
            {
                if(this.tienda.HorasAbierto > 0)
                {
                    this.tienda.HorasAbierto -= 1;
                    lstVendidos.Items.Add(this.tienda.VenderPrenda());
                }
                else
                {
                    this.picTiendaCerrada.Visible = true;
                    this.picTiendaAbierta.Visible = false;
                    this.tienda.HorasAbierto = this.tienda.HorarioInicio.HorasAbierto(this.tienda.HorarioFin);
                    this.btnAbrirNegocio.Enabled = true;
                    this.btnReporteGeneral.Enabled = true;
                    this.btnAdministracion.Enabled = true;
                    CerrarHilos();
                }
            }
        }
        /// <summary>
        /// En caso de cerrar el form en un momento inesperado, abortar los hilos activos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTienda_FormClosing(object sender, FormClosingEventArgs e)
        {
            CerrarHilos();
        }
        /// <summary>
        /// En caso de haber un hilo activo, se encarga de abortarlo.
        /// </summary>
        private void CerrarHilos()
        {
            
            foreach (Thread h in this.hilos)
            {
                if(h != null && h.IsAlive)
                {
                    h.Abort();
                }
            }
        }
        /// <summary>
        /// Muestra todas las ventas concretadas y guardadas en el archivo txt.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReporteGeneral_Click(object sender, EventArgs e)
        {
            try
            {
                Texto texto = new Texto();
                MessageBox.Show(texto.Leer("Ventas.txt"), "Ventas", MessageBoxButtons.OK);
            }
            catch(ErrorArchivoException ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }
            
        }
    }
}
