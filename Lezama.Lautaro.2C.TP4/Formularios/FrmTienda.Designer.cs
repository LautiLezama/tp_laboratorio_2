namespace Formularios
{
    partial class FrmTienda
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAbrirNegocio = new System.Windows.Forms.Button();
            this.btnReporteGeneral = new System.Windows.Forms.Button();
            this.btnAdministracion = new System.Windows.Forms.Button();
            this.lstVendidos = new System.Windows.Forms.ListBox();
            this.picTiendaCerrada = new System.Windows.Forms.PictureBox();
            this.picTiendaAbierta = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picTiendaCerrada)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTiendaAbierta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAbrirNegocio
            // 
            this.btnAbrirNegocio.Location = new System.Drawing.Point(573, 307);
            this.btnAbrirNegocio.Name = "btnAbrirNegocio";
            this.btnAbrirNegocio.Size = new System.Drawing.Size(82, 51);
            this.btnAbrirNegocio.TabIndex = 0;
            this.btnAbrirNegocio.Text = "Abrir Negocio";
            this.btnAbrirNegocio.UseVisualStyleBackColor = true;
            this.btnAbrirNegocio.Click += new System.EventHandler(this.btnAbrirNegocio_Click);
            // 
            // btnReporteGeneral
            // 
            this.btnReporteGeneral.Location = new System.Drawing.Point(661, 307);
            this.btnReporteGeneral.Name = "btnReporteGeneral";
            this.btnReporteGeneral.Size = new System.Drawing.Size(82, 51);
            this.btnReporteGeneral.TabIndex = 1;
            this.btnReporteGeneral.Text = "Reporte General";
            this.btnReporteGeneral.UseVisualStyleBackColor = true;
            this.btnReporteGeneral.Click += new System.EventHandler(this.btnReporteGeneral_Click);
            // 
            // btnAdministracion
            // 
            this.btnAdministracion.Location = new System.Drawing.Point(573, 365);
            this.btnAdministracion.Name = "btnAdministracion";
            this.btnAdministracion.Size = new System.Drawing.Size(170, 23);
            this.btnAdministracion.TabIndex = 2;
            this.btnAdministracion.Text = "Administracion";
            this.btnAdministracion.UseVisualStyleBackColor = true;
            this.btnAdministracion.Click += new System.EventHandler(this.btnAdministracion_Click);
            // 
            // lstVendidos
            // 
            this.lstVendidos.FormattingEnabled = true;
            this.lstVendidos.HorizontalScrollbar = true;
            this.lstVendidos.Location = new System.Drawing.Point(573, 13);
            this.lstVendidos.Name = "lstVendidos";
            this.lstVendidos.Size = new System.Drawing.Size(170, 277);
            this.lstVendidos.TabIndex = 3;
            // 
            // picTiendaCerrada
            // 
            this.picTiendaCerrada.Image = global::Formularios.Properties.Resources.Tienda_Cerrada;
            this.picTiendaCerrada.Location = new System.Drawing.Point(12, 12);
            this.picTiendaCerrada.Name = "picTiendaCerrada";
            this.picTiendaCerrada.Size = new System.Drawing.Size(544, 375);
            this.picTiendaCerrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTiendaCerrada.TabIndex = 4;
            this.picTiendaCerrada.TabStop = false;
            // 
            // picTiendaAbierta
            // 
            this.picTiendaAbierta.Image = global::Formularios.Properties.Resources.Tienda_Abierta;
            this.picTiendaAbierta.Location = new System.Drawing.Point(13, 13);
            this.picTiendaAbierta.Name = "picTiendaAbierta";
            this.picTiendaAbierta.Size = new System.Drawing.Size(543, 374);
            this.picTiendaAbierta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTiendaAbierta.TabIndex = 5;
            this.picTiendaAbierta.TabStop = false;
            this.picTiendaAbierta.Visible = false;
            // 
            // FrmTienda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 400);
            this.Controls.Add(this.picTiendaAbierta);
            this.Controls.Add(this.picTiendaCerrada);
            this.Controls.Add(this.lstVendidos);
            this.Controls.Add(this.btnAdministracion);
            this.Controls.Add(this.btnReporteGeneral);
            this.Controls.Add(this.btnAbrirNegocio);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmTienda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tienda de Ropa Lautaro Lezama 2C";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTienda_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picTiendaCerrada)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTiendaAbierta)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAbrirNegocio;
        private System.Windows.Forms.Button btnReporteGeneral;
        private System.Windows.Forms.Button btnAdministracion;
        private System.Windows.Forms.ListBox lstVendidos;
        private System.Windows.Forms.PictureBox picTiendaCerrada;
        private System.Windows.Forms.PictureBox picTiendaAbierta;
    }
}

