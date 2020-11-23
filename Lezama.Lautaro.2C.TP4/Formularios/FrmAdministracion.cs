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

namespace Formularios
{
    public partial class FrmAdministracion : Form
    {
        Tienda tienda;
        public FrmAdministracion(Tienda tienda)
        {
            InitializeComponent();
            this.tienda = tienda;
            cmbPrenda.DataSource = Enum.GetValues(typeof(Prenda.ETipoPrenda));
            cmbColor.DataSource = Enum.GetValues(typeof(Prenda.EColor));
            ActualizarLista();

        }

        public Tienda TiendaActualizada
        {
            get
            {
                return this.tienda;
            }
        }
        /// <summary>
        /// Al terminar el uso del formulario, la lista actual se serializara con el metodo de Guardar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVolver_Click(object sender, EventArgs e)
        {
            try
            {
                Xml<Tienda> xml = new Xml<Tienda>();
                xml.Guardar(this.tienda, "Tienda.xml");
            }
            catch(ErrorArchivoException ex)
            {
                MessageBox.Show(ex.Message + ex.InnerException.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Close();
            }
        }
        /// <summary>
        /// Se agrega una prenda segun los valores ingresados en los textbox/combobox de entrada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PrendaDAO prendaDAO = new PrendaDAO();
                int codigo = txtCodigo.Text.ValidarParsearInt();
                float precio = txtPrecio.Text.ValidarParsearPrecio();
                Prenda.ETipoPrenda tipoPrenda;
                Enum.TryParse<Prenda.ETipoPrenda>(cmbPrenda.SelectedValue.ToString(), out tipoPrenda);

                switch (tipoPrenda)
                {
                    case Prenda.ETipoPrenda.Pantalon:
                        Pantalon pantalon = new Pantalon(codigo, precio, (Prenda.EColor)cmbColor.SelectedValue, (Pantalon.EPantalon)cmbTipo.SelectedValue);
                        this.tienda += pantalon;
                        prendaDAO.InsertarPrenda(pantalon, tipoPrenda);
                        break;
                    case Prenda.ETipoPrenda.Remera:
                        Remera remera = new Remera(codigo, precio, (Prenda.EColor)cmbColor.SelectedValue, (Remera.EManga)cmbTipo.SelectedValue);
                        this.tienda += remera;
                        prendaDAO.InsertarPrenda(remera, tipoPrenda);
                        break;
                }
                ActualizarLista();
            }
            catch (NoEsNumeroException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (TiendaException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        /// <summary>
        /// Se elimina el producto seleccionado en la lista de prendas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            PrendaDAO prendaDAO = new PrendaDAO();
            int codigo = ObtenerCodigo();
            if(codigo != -1)
            {
                prendaDAO.EliminarPrenda(ObtenerCodigo());
                bool rta = this.tienda - ObtenerCodigo();
                ActualizarLista();
            }
        }

        private void cmbPrenda_SelectedIndexChanged(object sender, EventArgs e)
        {
            Prenda.ETipoPrenda tipoPrenda;
            Enum.TryParse<Prenda.ETipoPrenda>(cmbPrenda.SelectedValue.ToString(), out tipoPrenda);
            switch (tipoPrenda)
            {
                case Prenda.ETipoPrenda.Pantalon:
                    cmbTipo.DataSource = Enum.GetValues(typeof(Pantalon.EPantalon));
                    break;
                case Prenda.ETipoPrenda.Remera:
                    cmbTipo.DataSource = Enum.GetValues(typeof(Remera.EManga));
                    break;
            }
        }
        /// <summary>
        /// Refresca la lista cada vez que se hace alguna acción, a fin de dejar la lista siempre actualizada.
        /// </summary>
        private void ActualizarLista()
        {
            lstPrendas.Items.Clear();
            PrendaDAO prendaDAO = new PrendaDAO();
            this.tienda.Prendas = prendaDAO.ListarPrendas();
            foreach(Prenda p in this.tienda.Prendas)
            {
               lstPrendas.Items.Add(p.ToString());
            }
        }

        private int ObtenerCodigo()
        {
            string idString = String.Empty;
            if (lstPrendas.SelectedItem != null)
            {
                for (int i = 0; i < lstPrendas.SelectedItem.ToString().Length; i++)
                {
                    if (char.IsDigit(lstPrendas.SelectedItem.ToString()[i]))
                    {
                        idString += lstPrendas.SelectedItem.ToString()[i];
                    }
                    else
                    {
                        break;
                    }
                }
                int.TryParse(idString, out int id);
                return id;
            }
            else
            {
                MessageBox.Show("No se ha seleccionado ninguna prenda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }
    }
}
