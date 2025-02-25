﻿namespace SistemaFacturacionInventario.Facturacion
{
    partial class frmFacturacion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            this.btnListado = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNroCliente = new System.Windows.Forms.Label();
            this.txtNroCliente = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.brnAnonimo = new System.Windows.Forms.Button();
            this.lblTipoFact = new System.Windows.Forms.Label();
            this.cmbTipoFac = new System.Windows.Forms.ComboBox();
            this.txtBV = new System.Windows.Forms.TextBox();
            this.txtNroComp = new System.Windows.Forms.TextBox();
            this.cmboFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.lblFechaVto = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.grupBoxCabecera = new System.Windows.Forms.GroupBox();
            this.dgrDetalle = new System.Windows.Forms.DataGridView();
            this.Borrar = new System.Windows.Forms.DataGridViewImageColumn();
            this.Buscar = new System.Windows.Forms.DataGridViewImageColumn();
            this.ArtDesconocido = new System.Windows.Forms.DataGridViewImageColumn();
            this.NroArt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescCorta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iva = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nueva = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SiDesc = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DesdeRem = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrecioManual = new System.Windows.Forms.DataGridViewImageColumn();
            this.IdFactVtaDetalle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecManual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grupBoxCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnListado
            // 
            this.btnListado.Enabled = false;
            this.btnListado.Image = ((System.Drawing.Image)(resources.GetObject("btnListado.Image")));
            this.btnListado.Location = new System.Drawing.Point(257, 11);
            this.btnListado.Margin = new System.Windows.Forms.Padding(4);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(35, 35);
            this.btnListado.TabIndex = 36;
            this.btnListado.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::SistemaFacturacionInventario.Properties.Resources.icons8_buscar_20;
            this.btnBuscar.Location = new System.Drawing.Point(214, 11);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 35;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // lblNroCliente
            // 
            this.lblNroCliente.AutoSize = true;
            this.lblNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNroCliente.Location = new System.Drawing.Point(71, 24);
            this.lblNroCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroCliente.Name = "lblNroCliente";
            this.lblNroCliente.Size = new System.Drawing.Size(46, 13);
            this.lblNroCliente.TabIndex = 34;
            this.lblNroCliente.Text = "Cliente:";
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.Enabled = false;
            this.txtNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroCliente.Location = new System.Drawing.Point(125, 19);
            this.txtNroCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroCliente.MaxLength = 6;
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.Size = new System.Drawing.Size(68, 22);
            this.txtNroCliente.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(342, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(644, 21);
            this.label1.TabIndex = 37;
            this.label1.Text = "Nombre Cliente";
            // 
            // brnAnonimo
            // 
            this.brnAnonimo.Enabled = false;
            this.brnAnonimo.Image = ((System.Drawing.Image)(resources.GetObject("brnAnonimo.Image")));
            this.brnAnonimo.Location = new System.Drawing.Point(300, 11);
            this.brnAnonimo.Margin = new System.Windows.Forms.Padding(4);
            this.brnAnonimo.Name = "brnAnonimo";
            this.brnAnonimo.Size = new System.Drawing.Size(35, 35);
            this.brnAnonimo.TabIndex = 38;
            this.brnAnonimo.UseVisualStyleBackColor = true;
            // 
            // lblTipoFact
            // 
            this.lblTipoFact.AutoSize = true;
            this.lblTipoFact.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTipoFact.Location = new System.Drawing.Point(14, 58);
            this.lblTipoFact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoFact.Name = "lblTipoFact";
            this.lblTipoFact.Size = new System.Drawing.Size(103, 13);
            this.lblTipoFact.TabIndex = 39;
            this.lblTipoFact.Text = "Tipo y Nro Factura:";
            // 
            // cmbTipoFac
            // 
            this.cmbTipoFac.FormattingEnabled = true;
            this.cmbTipoFac.Location = new System.Drawing.Point(125, 55);
            this.cmbTipoFac.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoFac.Name = "cmbTipoFac";
            this.cmbTipoFac.Size = new System.Drawing.Size(68, 21);
            this.cmbTipoFac.TabIndex = 40;
            // 
            // txtBV
            // 
            this.txtBV.Enabled = false;
            this.txtBV.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtBV.Location = new System.Drawing.Point(201, 54);
            this.txtBV.Margin = new System.Windows.Forms.Padding(4);
            this.txtBV.MaxLength = 6;
            this.txtBV.Name = "txtBV";
            this.txtBV.Size = new System.Drawing.Size(39, 22);
            this.txtBV.TabIndex = 41;
            // 
            // txtNroComp
            // 
            this.txtNroComp.Enabled = false;
            this.txtNroComp.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroComp.Location = new System.Drawing.Point(248, 54);
            this.txtNroComp.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroComp.MaxLength = 6;
            this.txtNroComp.Name = "txtNroComp";
            this.txtNroComp.Size = new System.Drawing.Size(113, 22);
            this.txtNroComp.TabIndex = 42;
            // 
            // cmboFormaPago
            // 
            this.cmboFormaPago.FormattingEnabled = true;
            this.cmboFormaPago.Location = new System.Drawing.Point(125, 88);
            this.cmboFormaPago.Margin = new System.Windows.Forms.Padding(4);
            this.cmboFormaPago.Name = "cmboFormaPago";
            this.cmboFormaPago.Size = new System.Drawing.Size(167, 21);
            this.cmboFormaPago.TabIndex = 44;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFormaPago.Location = new System.Drawing.Point(30, 91);
            this.lblFormaPago.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(87, 13);
            this.lblFormaPago.TabIndex = 43;
            this.lblFormaPago.Text = "Forma de Pago:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFecha.Location = new System.Drawing.Point(362, 93);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 45;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(409, 90);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(97, 22);
            this.dtpFecha.TabIndex = 46;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(682, 90);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(97, 22);
            this.dateTimePicker1.TabIndex = 48;
            // 
            // lblFechaVto
            // 
            this.lblFechaVto.AutoSize = true;
            this.lblFechaVto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFechaVto.Location = new System.Drawing.Point(611, 95);
            this.lblFechaVto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaVto.Name = "lblFechaVto";
            this.lblFechaVto.Size = new System.Drawing.Size(64, 13);
            this.lblFechaVto.TabIndex = 47;
            this.lblFechaVto.Text = "Fecha Vto.:";
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(917, 91);
            this.cmbConcepto.Margin = new System.Windows.Forms.Padding(4);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(167, 21);
            this.cmbConcepto.TabIndex = 50;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblConcepto.Location = new System.Drawing.Point(849, 94);
            this.lblConcepto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(60, 13);
            this.lblConcepto.TabIndex = 49;
            this.lblConcepto.Text = "Concepto:";
            // 
            // grupBoxCabecera
            // 
            this.grupBoxCabecera.Controls.Add(this.cmbConcepto);
            this.grupBoxCabecera.Controls.Add(this.lblConcepto);
            this.grupBoxCabecera.Controls.Add(this.dateTimePicker1);
            this.grupBoxCabecera.Controls.Add(this.lblFechaVto);
            this.grupBoxCabecera.Controls.Add(this.dtpFecha);
            this.grupBoxCabecera.Controls.Add(this.lblFecha);
            this.grupBoxCabecera.Controls.Add(this.cmboFormaPago);
            this.grupBoxCabecera.Controls.Add(this.lblFormaPago);
            this.grupBoxCabecera.Controls.Add(this.txtNroComp);
            this.grupBoxCabecera.Controls.Add(this.txtBV);
            this.grupBoxCabecera.Controls.Add(this.cmbTipoFac);
            this.grupBoxCabecera.Controls.Add(this.lblTipoFact);
            this.grupBoxCabecera.Controls.Add(this.brnAnonimo);
            this.grupBoxCabecera.Controls.Add(this.label1);
            this.grupBoxCabecera.Controls.Add(this.btnListado);
            this.grupBoxCabecera.Controls.Add(this.btnBuscar);
            this.grupBoxCabecera.Controls.Add(this.lblNroCliente);
            this.grupBoxCabecera.Controls.Add(this.txtNroCliente);
            this.grupBoxCabecera.Location = new System.Drawing.Point(26, 12);
            this.grupBoxCabecera.Name = "grupBoxCabecera";
            this.grupBoxCabecera.Size = new System.Drawing.Size(1106, 176);
            this.grupBoxCabecera.TabIndex = 51;
            this.grupBoxCabecera.TabStop = false;
            this.grupBoxCabecera.Text = "Cabecera";
            // 
            // dgrDetalle
            // 
            this.dgrDetalle.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgrDetalle.CausesValidation = false;
            this.dgrDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Borrar,
            this.Buscar,
            this.ArtDesconocido,
            this.NroArt,
            this.DescCorta,
            this.Cantidad,
            this.UMedida,
            this.Iva,
            this.Precio,
            this.Total,
            this.Nueva,
            this.SiDesc,
            this.DesdeRem,
            this.PrecioManual,
            this.IdFactVtaDetalle,
            this.PrecManual});
            this.dgrDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgrDetalle.Location = new System.Drawing.Point(43, 232);
            this.dgrDetalle.MultiSelect = false;
            this.dgrDetalle.Name = "dgrDetalle";
            this.dgrDetalle.RowHeadersVisible = false;
            this.dgrDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgrDetalle.Size = new System.Drawing.Size(1089, 208);
            this.dgrDetalle.TabIndex = 52;
            // 
            // Borrar
            // 
            this.Borrar.Frozen = true;
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Name = "Borrar";
            this.Borrar.Width = 50;
            // 
            // Buscar
            // 
            this.Buscar.Frozen = true;
            this.Buscar.HeaderText = "Buscar";
            this.Buscar.Name = "Buscar";
            this.Buscar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Buscar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Buscar.Width = 50;
            // 
            // ArtDesconocido
            // 
            this.ArtDesconocido.Frozen = true;
            this.ArtDesconocido.HeaderText = "Art.Desc";
            this.ArtDesconocido.Name = "ArtDesconocido";
            this.ArtDesconocido.Width = 50;
            // 
            // NroArt
            // 
            this.NroArt.Frozen = true;
            this.NroArt.HeaderText = "NroArt.";
            this.NroArt.Name = "NroArt";
            this.NroArt.Width = 65;
            // 
            // DescCorta
            // 
            this.DescCorta.Frozen = true;
            this.DescCorta.HeaderText = "Desc.Corta";
            this.DescCorta.Name = "DescCorta";
            this.DescCorta.ReadOnly = true;
            this.DescCorta.Width = 350;
            // 
            // Cantidad
            // 
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 75;
            // 
            // UMedida
            // 
            this.UMedida.Frozen = true;
            this.UMedida.HeaderText = "U.Medida";
            this.UMedida.Name = "UMedida";
            this.UMedida.ReadOnly = true;
            this.UMedida.Width = 115;
            // 
            // Iva
            // 
            this.Iva.Frozen = true;
            this.Iva.HeaderText = "%IVA";
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Width = 50;
            // 
            // Precio
            // 
            this.Precio.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Precio.Frozen = true;
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.Width = 130;
            // 
            // Total
            // 
            this.Total.Frozen = true;
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Nueva
            // 
            this.Nueva.Frozen = true;
            this.Nueva.HeaderText = "Nueva";
            this.Nueva.Name = "Nueva";
            this.Nueva.Visible = false;
            // 
            // SiDesc
            // 
            this.SiDesc.Frozen = true;
            this.SiDesc.HeaderText = "SiDesc";
            this.SiDesc.Name = "SiDesc";
            this.SiDesc.Visible = false;
            // 
            // DesdeRem
            // 
            this.DesdeRem.Frozen = true;
            this.DesdeRem.HeaderText = "DesdeRem";
            this.DesdeRem.Name = "DesdeRem";
            this.DesdeRem.Visible = false;
            // 
            // PrecioManual
            // 
            this.PrecioManual.Frozen = true;
            this.PrecioManual.HeaderText = "$ Man";
            this.PrecioManual.Name = "PrecioManual";
            this.PrecioManual.Width = 50;
            // 
            // IdFactVtaDetalle
            // 
            this.IdFactVtaDetalle.Frozen = true;
            this.IdFactVtaDetalle.HeaderText = "IdFactVtaDetalle";
            this.IdFactVtaDetalle.Name = "IdFactVtaDetalle";
            this.IdFactVtaDetalle.Visible = false;
            // 
            // PrecManual
            // 
            this.PrecManual.Frozen = true;
            this.PrecManual.HeaderText = "PrecManual";
            this.PrecManual.Name = "PrecManual";
            this.PrecManual.Visible = false;
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 703);
            this.Controls.Add(this.dgrDetalle);
            this.Controls.Add(this.grupBoxCabecera);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmFacturacion";
            this.Text = "frmFacturacion";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.grupBoxCabecera.ResumeLayout(false);
            this.grupBoxCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDetalle)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNroCliente;
        private System.Windows.Forms.TextBox txtNroCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button brnAnonimo;
        private System.Windows.Forms.Label lblTipoFact;
        private System.Windows.Forms.ComboBox cmbTipoFac;
        private System.Windows.Forms.TextBox txtBV;
        private System.Windows.Forms.TextBox txtNroComp;
        private System.Windows.Forms.ComboBox cmboFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label lblFechaVto;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.GroupBox grupBoxCabecera;
        private System.Windows.Forms.DataGridView dgrDetalle;
        private System.Windows.Forms.DataGridViewImageColumn Borrar;
        private System.Windows.Forms.DataGridViewImageColumn Buscar;
        private System.Windows.Forms.DataGridViewImageColumn ArtDesconocido;
        private System.Windows.Forms.DataGridViewTextBoxColumn NroArt;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescCorta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn UMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iva;
        private System.Windows.Forms.DataGridViewComboBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Nueva;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SiDesc;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DesdeRem;
        private System.Windows.Forms.DataGridViewImageColumn PrecioManual;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdFactVtaDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecManual;
    }
}