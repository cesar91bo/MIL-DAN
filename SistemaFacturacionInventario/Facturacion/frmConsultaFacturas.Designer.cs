namespace SistemaFacturacionInventario.Facturacion
{
    partial class frmConsultaFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaFacturas));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkClienteFactura = new System.Windows.Forms.CheckBox();
            this.lblHasta = new System.Windows.Forms.Label();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpFechaHastaFact = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaDesdeFact = new System.Windows.Forms.DateTimePicker();
            this.chkFechaFactura = new System.Windows.Forms.CheckBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.lblListaFacturas = new System.Windows.Forms.Label();
            this.btnEditar = new System.Windows.Forms.Button();
            this.listViewFactura = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(556, 71);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 30);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkClienteFactura);
            this.panel1.Controls.Add(this.lblHasta);
            this.panel1.Controls.Add(this.lblDesde);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.dtpFechaHastaFact);
            this.panel1.Controls.Add(this.dtpFechaDesdeFact);
            this.panel1.Controls.Add(this.chkFechaFactura);
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.lblListaFacturas);
            this.panel1.Location = new System.Drawing.Point(200, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 132);
            this.panel1.TabIndex = 30;
            // 
            // chkClienteFactura
            // 
            this.chkClienteFactura.AutoSize = true;
            this.chkClienteFactura.Location = new System.Drawing.Point(45, 45);
            this.chkClienteFactura.Name = "chkClienteFactura";
            this.chkClienteFactura.Size = new System.Drawing.Size(103, 17);
            this.chkClienteFactura.TabIndex = 47;
            this.chkClienteFactura.Text = "Cliente Factura";
            this.chkClienteFactura.UseVisualStyleBackColor = true;
            this.chkClienteFactura.CheckedChanged += new System.EventHandler(this.chkClienteFactura_CheckedChanged);
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Enabled = false;
            this.lblHasta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblHasta.Location = new System.Drawing.Point(357, 80);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(39, 13);
            this.lblHasta.TabIndex = 46;
            this.lblHasta.Text = "Hasta:";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Enabled = false;
            this.lblDesde.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDesde.Location = new System.Drawing.Point(157, 80);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(42, 13);
            this.lblDesde.TabIndex = 45;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpFechaHastaFact
            // 
            this.dtpFechaHastaFact.Enabled = false;
            this.dtpFechaHastaFact.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaHastaFact.Location = new System.Drawing.Point(411, 75);
            this.dtpFechaHastaFact.Name = "dtpFechaHastaFact";
            this.dtpFechaHastaFact.Size = new System.Drawing.Size(105, 22);
            this.dtpFechaHastaFact.TabIndex = 43;
            // 
            // dtpFechaDesdeFact
            // 
            this.dtpFechaDesdeFact.Enabled = false;
            this.dtpFechaDesdeFact.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaDesdeFact.Location = new System.Drawing.Point(213, 74);
            this.dtpFechaDesdeFact.Name = "dtpFechaDesdeFact";
            this.dtpFechaDesdeFact.Size = new System.Drawing.Size(105, 22);
            this.dtpFechaDesdeFact.TabIndex = 42;
            // 
            // chkFechaFactura
            // 
            this.chkFechaFactura.AutoSize = true;
            this.chkFechaFactura.Location = new System.Drawing.Point(45, 80);
            this.chkFechaFactura.Name = "chkFechaFactura";
            this.chkFechaFactura.Size = new System.Drawing.Size(97, 17);
            this.chkFechaFactura.TabIndex = 41;
            this.chkFechaFactura.Text = "Fecha Factura";
            this.chkFechaFactura.UseVisualStyleBackColor = true;
            this.chkFechaFactura.CheckedChanged += new System.EventHandler(this.chkFechaFactura_CheckedChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Enabled = false;
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(160, 43);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(474, 22);
            this.txtFiltro.TabIndex = 22;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // lblListaFacturas
            // 
            this.lblListaFacturas.AutoSize = true;
            this.lblListaFacturas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListaFacturas.Location = new System.Drawing.Point(309, 4);
            this.lblListaFacturas.Name = "lblListaFacturas";
            this.lblListaFacturas.Size = new System.Drawing.Size(135, 21);
            this.lblListaFacturas.TabIndex = 6;
            this.lblListaFacturas.Text = "Lista de Facturas";
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(425, 477);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(84, 37);
            this.btnEditar.TabIndex = 29;
            this.btnEditar.Text = "Detalle";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // listViewFactura
            // 
            this.listViewFactura.FullRowSelect = true;
            this.listViewFactura.GridLines = true;
            this.listViewFactura.HideSelection = false;
            this.listViewFactura.Location = new System.Drawing.Point(83, 169);
            this.listViewFactura.MultiSelect = false;
            this.listViewFactura.Name = "listViewFactura";
            this.listViewFactura.Size = new System.Drawing.Size(1003, 302);
            this.listViewFactura.TabIndex = 26;
            this.listViewFactura.UseCompatibleStateImageBehavior = false;
            this.listViewFactura.View = System.Windows.Forms.View.Details;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(515, 477);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 31;
            this.button1.Text = "Imprimir";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(617, 477);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(99, 37);
            this.button2.TabIndex = 32;
            this.button2.Text = "Anulación";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // frmConsultaFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1164, 526);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.listViewFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmConsultaFacturas";
            this.Text = "frmConsultaFacturas";
            this.Load += new System.EventHandler(this.frmConsultaFacturas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker dtpFechaHastaFact;
        private System.Windows.Forms.DateTimePicker dtpFechaDesdeFact;
        private System.Windows.Forms.CheckBox chkFechaFactura;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label lblListaFacturas;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.ListView listViewFactura;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.CheckBox chkClienteFactura;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}