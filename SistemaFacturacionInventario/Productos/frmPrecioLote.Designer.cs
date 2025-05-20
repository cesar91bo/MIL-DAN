namespace SistemaFacturacionInventario.Productos
{
    partial class frmPrecioLote
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecioLote));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblListaPrecios = new System.Windows.Forms.Label();
            this.listViewProductos = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(740, 69);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 30);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.cmbFiltro);
            this.panel1.Controls.Add(this.lblFiltrar);
            this.panel1.Controls.Add(this.lblListaPrecios);
            this.panel1.Location = new System.Drawing.Point(184, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 100);
            this.panel1.TabIndex = 33;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(45, 63);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(504, 22);
            this.txtFiltro.TabIndex = 22;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(100, 36);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(251, 21);
            this.cmbFiltro.TabIndex = 8;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Enabled = false;
            this.lblFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFiltrar.Location = new System.Drawing.Point(42, 40);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(60, 13);
            this.lblFiltrar.TabIndex = 7;
            this.lblFiltrar.Text = "Filtrar Por:";
            // 
            // lblListaPrecios
            // 
            this.lblListaPrecios.AutoSize = true;
            this.lblListaPrecios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListaPrecios.Location = new System.Drawing.Point(309, 4);
            this.lblListaPrecios.Name = "lblListaPrecios";
            this.lblListaPrecios.Size = new System.Drawing.Size(127, 21);
            this.lblListaPrecios.TabIndex = 6;
            this.lblListaPrecios.Text = "Lista de Precios";
            // 
            // listViewProductos
            // 
            this.listViewProductos.FullRowSelect = true;
            this.listViewProductos.GridLines = true;
            this.listViewProductos.HideSelection = false;
            this.listViewProductos.Location = new System.Drawing.Point(73, 114);
            this.listViewProductos.MultiSelect = false;
            this.listViewProductos.Name = "listViewProductos";
            this.listViewProductos.Size = new System.Drawing.Size(1016, 184);
            this.listViewProductos.TabIndex = 32;
            this.listViewProductos.UseCompatibleStateImageBehavior = false;
            this.listViewProductos.View = System.Windows.Forms.View.Details;
            // 
            // frmPrecioLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 597);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewProductos);
            this.Name = "frmPrecioLote";
            this.Text = "Actualización de Precios";
            this.Load += new System.EventHandler(this.frmPrecioLote_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblListaPrecios;
        private System.Windows.Forms.ListView listViewProductos;
    }
}