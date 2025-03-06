namespace SistemaFacturacionInventario.Facturacion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFacturacion));
            this.btnListado = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNroCliente = new System.Windows.Forms.Label();
            this.txtNroCliente = new System.Windows.Forms.TextBox();
            this.lblNomreCliente = new System.Windows.Forms.Label();
            this.brnAnonimo = new System.Windows.Forms.Button();
            this.lblTipoFact = new System.Windows.Forms.Label();
            this.cmbTipoFac = new System.Windows.Forms.ComboBox();
            this.txtBV = new System.Windows.Forms.TextBox();
            this.txtNroComp = new System.Windows.Forms.TextBox();
            this.cmboFormaPago = new System.Windows.Forms.ComboBox();
            this.lblFormaPago = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaVto = new System.Windows.Forms.DateTimePicker();
            this.lblFechaVto = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.grupBoxCabecera = new System.Windows.Forms.GroupBox();
            this.cmbCondPago = new System.Windows.Forms.ComboBox();
            this.lblCondPago = new System.Windows.Forms.Label();
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
            this.groupBoxDetalle = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSubtDto0 = new System.Windows.Forms.Label();
            this.lbllblSubTotaldto0 = new System.Windows.Forms.Label();
            this.lblSubTotal0 = new System.Windows.Forms.Label();
            this.lbllblSubTotal0 = new System.Windows.Forms.Label();
            this.lblTotalIva0 = new System.Windows.Forms.Label();
            this.lbllblIVA0 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTotalIVA = new System.Windows.Forms.Label();
            this.lbllblIVA = new System.Windows.Forms.Label();
            this.lblSubtDto105 = new System.Windows.Forms.Label();
            this.lblSubtDto21 = new System.Windows.Forms.Label();
            this.lbllblSubTotaldto105 = new System.Windows.Forms.Label();
            this.lbllblSubTotaldto21 = new System.Windows.Forms.Label();
            this.lblSubTotal105 = new System.Windows.Forms.Label();
            this.lblSubTotal21 = new System.Windows.Forms.Label();
            this.lbllblSubTotal105 = new System.Windows.Forms.Label();
            this.lbllblSubTotal21 = new System.Windows.Forms.Label();
            this.lblTotalIva105 = new System.Windows.Forms.Label();
            this.lbllblIVA105 = new System.Windows.Forms.Label();
            this.lblTotalIva21 = new System.Windows.Forms.Label();
            this.lbllblIVA21 = new System.Windows.Forms.Label();
            this.lblSubtDto = new System.Windows.Forms.Label();
            this.lbllblSubtDto = new System.Windows.Forms.Label();
            this.lblTotalDto = new System.Windows.Forms.Label();
            this.txtDto = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lblSubTotal = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grupBoxCabecera.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDetalle)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnListado
            // 
            this.btnListado.Image = ((System.Drawing.Image)(resources.GetObject("btnListado.Image")));
            this.btnListado.Location = new System.Drawing.Point(343, 16);
            this.btnListado.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(47, 51);
            this.btnListado.TabIndex = 36;
            this.btnListado.UseVisualStyleBackColor = true;
            this.btnListado.Click += new System.EventHandler(this.btnListado_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SistemaFacturacionInventario.Properties.Resources.icons8_buscar_20;
            this.btnBuscar.Location = new System.Drawing.Point(285, 16);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(47, 51);
            this.btnBuscar.TabIndex = 35;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNroCliente
            // 
            this.lblNroCliente.AutoSize = true;
            this.lblNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNroCliente.Location = new System.Drawing.Point(95, 35);
            this.lblNroCliente.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblNroCliente.Name = "lblNroCliente";
            this.lblNroCliente.Size = new System.Drawing.Size(54, 19);
            this.lblNroCliente.TabIndex = 34;
            this.lblNroCliente.Text = "Cliente:";
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroCliente.Location = new System.Drawing.Point(167, 28);
            this.txtNroCliente.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtNroCliente.MaxLength = 6;
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.Size = new System.Drawing.Size(89, 26);
            this.txtNroCliente.TabIndex = 33;
            // 
            // lblNomreCliente
            // 
            this.lblNomreCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomreCliente.Location = new System.Drawing.Point(456, 29);
            this.lblNomreCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomreCliente.Name = "lblNomreCliente";
            this.lblNomreCliente.Size = new System.Drawing.Size(859, 31);
            this.lblNomreCliente.TabIndex = 37;
            this.lblNomreCliente.Text = "Nombre Cliente";
            this.lblNomreCliente.Visible = false;
            // 
            // brnAnonimo
            // 
            this.brnAnonimo.Image = ((System.Drawing.Image)(resources.GetObject("brnAnonimo.Image")));
            this.brnAnonimo.Location = new System.Drawing.Point(400, 16);
            this.brnAnonimo.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.brnAnonimo.Name = "brnAnonimo";
            this.brnAnonimo.Size = new System.Drawing.Size(47, 51);
            this.brnAnonimo.TabIndex = 38;
            this.brnAnonimo.UseVisualStyleBackColor = true;
            this.brnAnonimo.Click += new System.EventHandler(this.brnAnonimo_Click);
            // 
            // lblTipoFact
            // 
            this.lblTipoFact.AutoSize = true;
            this.lblTipoFact.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTipoFact.Location = new System.Drawing.Point(19, 85);
            this.lblTipoFact.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTipoFact.Name = "lblTipoFact";
            this.lblTipoFact.Size = new System.Drawing.Size(125, 19);
            this.lblTipoFact.TabIndex = 39;
            this.lblTipoFact.Text = "Tipo y Nro Factura:";
            // 
            // cmbTipoFac
            // 
            this.cmbTipoFac.FormattingEnabled = true;
            this.cmbTipoFac.Location = new System.Drawing.Point(167, 80);
            this.cmbTipoFac.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbTipoFac.Name = "cmbTipoFac";
            this.cmbTipoFac.Size = new System.Drawing.Size(89, 27);
            this.cmbTipoFac.TabIndex = 40;
            // 
            // txtBV
            // 
            this.txtBV.Enabled = false;
            this.txtBV.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtBV.Location = new System.Drawing.Point(268, 79);
            this.txtBV.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtBV.MaxLength = 6;
            this.txtBV.Name = "txtBV";
            this.txtBV.Size = new System.Drawing.Size(51, 26);
            this.txtBV.TabIndex = 41;
            // 
            // txtNroComp
            // 
            this.txtNroComp.Enabled = false;
            this.txtNroComp.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroComp.Location = new System.Drawing.Point(331, 79);
            this.txtNroComp.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.txtNroComp.MaxLength = 6;
            this.txtNroComp.Name = "txtNroComp";
            this.txtNroComp.Size = new System.Drawing.Size(149, 26);
            this.txtNroComp.TabIndex = 42;
            // 
            // cmboFormaPago
            // 
            this.cmboFormaPago.FormattingEnabled = true;
            this.cmboFormaPago.Location = new System.Drawing.Point(167, 129);
            this.cmboFormaPago.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmboFormaPago.Name = "cmboFormaPago";
            this.cmboFormaPago.Size = new System.Drawing.Size(221, 27);
            this.cmboFormaPago.TabIndex = 44;
            // 
            // lblFormaPago
            // 
            this.lblFormaPago.AutoSize = true;
            this.lblFormaPago.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFormaPago.Location = new System.Drawing.Point(40, 133);
            this.lblFormaPago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFormaPago.Name = "lblFormaPago";
            this.lblFormaPago.Size = new System.Drawing.Size(105, 19);
            this.lblFormaPago.TabIndex = 43;
            this.lblFormaPago.Text = "Forma de Pago:";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFecha.Location = new System.Drawing.Point(483, 136);
            this.lblFecha.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(47, 19);
            this.lblFecha.TabIndex = 45;
            this.lblFecha.Text = "Fecha:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Enabled = false;
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(545, 132);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(128, 26);
            this.dtpFecha.TabIndex = 46;
            // 
            // dtpFechaVto
            // 
            this.dtpFechaVto.Enabled = false;
            this.dtpFechaVto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaVto.Location = new System.Drawing.Point(909, 132);
            this.dtpFechaVto.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaVto.Name = "dtpFechaVto";
            this.dtpFechaVto.Size = new System.Drawing.Size(128, 26);
            this.dtpFechaVto.TabIndex = 48;
            // 
            // lblFechaVto
            // 
            this.lblFechaVto.AutoSize = true;
            this.lblFechaVto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFechaVto.Location = new System.Drawing.Point(815, 139);
            this.lblFechaVto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblFechaVto.Name = "lblFechaVto";
            this.lblFechaVto.Size = new System.Drawing.Size(76, 19);
            this.lblFechaVto.TabIndex = 47;
            this.lblFechaVto.Text = "Fecha Vto.:";
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(1223, 133);
            this.cmbConcepto.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(221, 27);
            this.cmbConcepto.TabIndex = 50;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblConcepto.Location = new System.Drawing.Point(1132, 137);
            this.lblConcepto.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(71, 19);
            this.lblConcepto.TabIndex = 49;
            this.lblConcepto.Text = "Concepto:";
            // 
            // grupBoxCabecera
            // 
            this.grupBoxCabecera.Controls.Add(this.cmbCondPago);
            this.grupBoxCabecera.Controls.Add(this.lblCondPago);
            this.grupBoxCabecera.Controls.Add(this.cmbConcepto);
            this.grupBoxCabecera.Controls.Add(this.lblConcepto);
            this.grupBoxCabecera.Controls.Add(this.dtpFechaVto);
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
            this.grupBoxCabecera.Controls.Add(this.lblNomreCliente);
            this.grupBoxCabecera.Controls.Add(this.btnListado);
            this.grupBoxCabecera.Controls.Add(this.btnBuscar);
            this.grupBoxCabecera.Controls.Add(this.lblNroCliente);
            this.grupBoxCabecera.Controls.Add(this.txtNroCliente);
            this.grupBoxCabecera.Location = new System.Drawing.Point(35, 18);
            this.grupBoxCabecera.Margin = new System.Windows.Forms.Padding(4);
            this.grupBoxCabecera.Name = "grupBoxCabecera";
            this.grupBoxCabecera.Padding = new System.Windows.Forms.Padding(4);
            this.grupBoxCabecera.Size = new System.Drawing.Size(1511, 257);
            this.grupBoxCabecera.TabIndex = 51;
            this.grupBoxCabecera.TabStop = false;
            this.grupBoxCabecera.Text = "Cabecera";
            // 
            // cmbCondPago
            // 
            this.cmbCondPago.FormattingEnabled = true;
            this.cmbCondPago.Location = new System.Drawing.Point(167, 175);
            this.cmbCondPago.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.cmbCondPago.Name = "cmbCondPago";
            this.cmbCondPago.Size = new System.Drawing.Size(221, 27);
            this.cmbCondPago.TabIndex = 52;
            this.cmbCondPago.Visible = false;
            // 
            // lblCondPago
            // 
            this.lblCondPago.AutoSize = true;
            this.lblCondPago.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCondPago.Location = new System.Drawing.Point(12, 180);
            this.lblCondPago.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblCondPago.Name = "lblCondPago";
            this.lblCondPago.Size = new System.Drawing.Size(127, 19);
            this.lblCondPago.TabIndex = 51;
            this.lblCondPago.Text = "Condición de Pago:";
            this.lblCondPago.Visible = false;
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
            this.dgrDetalle.Location = new System.Drawing.Point(48, 346);
            this.dgrDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.dgrDetalle.MultiSelect = false;
            this.dgrDetalle.Name = "dgrDetalle";
            this.dgrDetalle.RowHeadersVisible = false;
            this.dgrDetalle.RowHeadersWidth = 51;
            this.dgrDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgrDetalle.Size = new System.Drawing.Size(1490, 304);
            this.dgrDetalle.TabIndex = 52;
            this.dgrDetalle.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgrDetalle_CellFormatting);
            // 
            // Borrar
            // 
            this.Borrar.Frozen = true;
            this.Borrar.HeaderText = "Borrar";
            this.Borrar.Image = ((System.Drawing.Image)(resources.GetObject("Borrar.Image")));
            this.Borrar.MinimumWidth = 6;
            this.Borrar.Name = "Borrar";
            this.Borrar.Width = 50;
            // 
            // Buscar
            // 
            this.Buscar.Frozen = true;
            this.Buscar.HeaderText = "Buscar";
            this.Buscar.Image = ((System.Drawing.Image)(resources.GetObject("Buscar.Image")));
            this.Buscar.MinimumWidth = 6;
            this.Buscar.Name = "Buscar";
            this.Buscar.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Buscar.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Buscar.Width = 50;
            // 
            // ArtDesconocido
            // 
            this.ArtDesconocido.Frozen = true;
            this.ArtDesconocido.HeaderText = "Art.Desc";
            this.ArtDesconocido.MinimumWidth = 6;
            this.ArtDesconocido.Name = "ArtDesconocido";
            this.ArtDesconocido.Width = 50;
            // 
            // NroArt
            // 
            this.NroArt.Frozen = true;
            this.NroArt.HeaderText = "NroArt.";
            this.NroArt.MinimumWidth = 6;
            this.NroArt.Name = "NroArt";
            this.NroArt.Width = 65;
            // 
            // DescCorta
            // 
            this.DescCorta.Frozen = true;
            this.DescCorta.HeaderText = "Desc.Corta";
            this.DescCorta.MinimumWidth = 6;
            this.DescCorta.Name = "DescCorta";
            this.DescCorta.ReadOnly = true;
            this.DescCorta.Width = 350;
            // 
            // Cantidad
            // 
            this.Cantidad.Frozen = true;
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.MinimumWidth = 6;
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Width = 75;
            // 
            // UMedida
            // 
            this.UMedida.Frozen = true;
            this.UMedida.HeaderText = "U.Medida";
            this.UMedida.MinimumWidth = 6;
            this.UMedida.Name = "UMedida";
            this.UMedida.ReadOnly = true;
            this.UMedida.Width = 115;
            // 
            // Iva
            // 
            this.Iva.Frozen = true;
            this.Iva.HeaderText = "%IVA";
            this.Iva.MinimumWidth = 6;
            this.Iva.Name = "Iva";
            this.Iva.ReadOnly = true;
            this.Iva.Width = 50;
            // 
            // Precio
            // 
            this.Precio.DisplayStyle = System.Windows.Forms.DataGridViewComboBoxDisplayStyle.ComboBox;
            this.Precio.Frozen = true;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.Width = 130;
            // 
            // Total
            // 
            this.Total.Frozen = true;
            this.Total.HeaderText = "Total";
            this.Total.MinimumWidth = 6;
            this.Total.Name = "Total";
            this.Total.ReadOnly = true;
            this.Total.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Total.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Total.Width = 125;
            // 
            // Nueva
            // 
            this.Nueva.Frozen = true;
            this.Nueva.HeaderText = "Nueva";
            this.Nueva.MinimumWidth = 6;
            this.Nueva.Name = "Nueva";
            this.Nueva.Visible = false;
            this.Nueva.Width = 125;
            // 
            // SiDesc
            // 
            this.SiDesc.Frozen = true;
            this.SiDesc.HeaderText = "SiDesc";
            this.SiDesc.MinimumWidth = 6;
            this.SiDesc.Name = "SiDesc";
            this.SiDesc.Visible = false;
            this.SiDesc.Width = 125;
            // 
            // DesdeRem
            // 
            this.DesdeRem.Frozen = true;
            this.DesdeRem.HeaderText = "DesdeRem";
            this.DesdeRem.MinimumWidth = 6;
            this.DesdeRem.Name = "DesdeRem";
            this.DesdeRem.Visible = false;
            this.DesdeRem.Width = 125;
            // 
            // PrecioManual
            // 
            this.PrecioManual.Frozen = true;
            this.PrecioManual.HeaderText = "$ Man";
            this.PrecioManual.MinimumWidth = 6;
            this.PrecioManual.Name = "PrecioManual";
            this.PrecioManual.Width = 50;
            // 
            // IdFactVtaDetalle
            // 
            this.IdFactVtaDetalle.Frozen = true;
            this.IdFactVtaDetalle.HeaderText = "IdFactVtaDetalle";
            this.IdFactVtaDetalle.MinimumWidth = 6;
            this.IdFactVtaDetalle.Name = "IdFactVtaDetalle";
            this.IdFactVtaDetalle.Visible = false;
            this.IdFactVtaDetalle.Width = 125;
            // 
            // PrecManual
            // 
            this.PrecManual.Frozen = true;
            this.PrecManual.HeaderText = "PrecManual";
            this.PrecManual.MinimumWidth = 6;
            this.PrecManual.Name = "PrecManual";
            this.PrecManual.Visible = false;
            this.PrecManual.Width = 125;
            // 
            // groupBoxDetalle
            // 
            this.groupBoxDetalle.Location = new System.Drawing.Point(32, 273);
            this.groupBoxDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDetalle.Name = "groupBoxDetalle";
            this.groupBoxDetalle.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDetalle.Size = new System.Drawing.Size(1514, 377);
            this.groupBoxDetalle.TabIndex = 53;
            this.groupBoxDetalle.TabStop = false;
            this.groupBoxDetalle.Text = "Detalle";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblSubtDto0);
            this.groupBox4.Controls.Add(this.lbllblSubTotaldto0);
            this.groupBox4.Controls.Add(this.lblSubTotal0);
            this.groupBox4.Controls.Add(this.lbllblSubTotal0);
            this.groupBox4.Controls.Add(this.lblTotalIva0);
            this.groupBox4.Controls.Add(this.lbllblIVA0);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.lblTotal);
            this.groupBox4.Controls.Add(this.lblTotalIVA);
            this.groupBox4.Controls.Add(this.lbllblIVA);
            this.groupBox4.Controls.Add(this.lblSubtDto105);
            this.groupBox4.Controls.Add(this.lblSubtDto21);
            this.groupBox4.Controls.Add(this.lbllblSubTotaldto105);
            this.groupBox4.Controls.Add(this.lbllblSubTotaldto21);
            this.groupBox4.Controls.Add(this.lblSubTotal105);
            this.groupBox4.Controls.Add(this.lblSubTotal21);
            this.groupBox4.Controls.Add(this.lbllblSubTotal105);
            this.groupBox4.Controls.Add(this.lbllblSubTotal21);
            this.groupBox4.Controls.Add(this.lblTotalIva105);
            this.groupBox4.Controls.Add(this.lbllblIVA105);
            this.groupBox4.Controls.Add(this.lblTotalIva21);
            this.groupBox4.Controls.Add(this.lbllblIVA21);
            this.groupBox4.Controls.Add(this.lblSubtDto);
            this.groupBox4.Controls.Add(this.lbllblSubtDto);
            this.groupBox4.Controls.Add(this.lblTotalDto);
            this.groupBox4.Controls.Add(this.txtDto);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.lblSubTotal);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Enabled = false;
            this.groupBox4.Location = new System.Drawing.Point(32, 659);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1514, 250);
            this.groupBox4.TabIndex = 54;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Pie";
            // 
            // lblSubtDto0
            // 
            this.lblSubtDto0.AutoSize = true;
            this.lblSubtDto0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtDto0.Location = new System.Drawing.Point(405, 83);
            this.lblSubtDto0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtDto0.Name = "lblSubtDto0";
            this.lblSubtDto0.Size = new System.Drawing.Size(17, 18);
            this.lblSubtDto0.TabIndex = 67;
            this.lblSubtDto0.Text = "0";
            // 
            // lbllblSubTotaldto0
            // 
            this.lbllblSubTotaldto0.AutoSize = true;
            this.lbllblSubTotaldto0.Location = new System.Drawing.Point(213, 85);
            this.lbllblSubTotaldto0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubTotaldto0.Name = "lbllblSubTotaldto0";
            this.lbllblSubTotaldto0.Size = new System.Drawing.Size(160, 19);
            this.lbllblSubTotaldto0.TabIndex = 66;
            this.lbllblSubTotaldto0.Text = "SubTotal c/dto IVA 0%: $";
            // 
            // lblSubTotal0
            // 
            this.lblSubTotal0.AutoSize = true;
            this.lblSubTotal0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal0.Location = new System.Drawing.Point(405, 19);
            this.lblSubTotal0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal0.Name = "lblSubTotal0";
            this.lblSubTotal0.Size = new System.Drawing.Size(17, 18);
            this.lblSubTotal0.TabIndex = 65;
            this.lblSubTotal0.Text = "0";
            // 
            // lbllblSubTotal0
            // 
            this.lbllblSubTotal0.AutoSize = true;
            this.lbllblSubTotal0.Location = new System.Drawing.Point(255, 20);
            this.lbllblSubTotal0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubTotal0.Name = "lbllblSubTotal0";
            this.lbllblSubTotal0.Size = new System.Drawing.Size(124, 19);
            this.lbllblSubTotal0.TabIndex = 64;
            this.lbllblSubTotal0.Text = "SubTotal IVA 0%: $";
            // 
            // lblTotalIva0
            // 
            this.lblTotalIva0.AutoSize = true;
            this.lblTotalIva0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIva0.Location = new System.Drawing.Point(405, 114);
            this.lblTotalIva0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalIva0.Name = "lblTotalIva0";
            this.lblTotalIva0.Size = new System.Drawing.Size(17, 18);
            this.lblTotalIva0.TabIndex = 63;
            this.lblTotalIva0.Text = "0";
            // 
            // lbllblIVA0
            // 
            this.lbllblIVA0.AutoSize = true;
            this.lbllblIVA0.Location = new System.Drawing.Point(281, 115);
            this.lbllblIVA0.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblIVA0.Name = "lbllblIVA0";
            this.lbllblIVA0.Size = new System.Drawing.Size(101, 19);
            this.lbllblIVA0.TabIndex = 62;
            this.lbllblIVA0.Text = "Total IVA 0%: $";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1277, 203);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 32);
            this.label13.TabIndex = 42;
            this.label13.Text = "Total: $";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(1395, 203);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(30, 31);
            this.lblTotal.TabIndex = 43;
            this.lblTotal.Text = "0";
            // 
            // lblTotalIVA
            // 
            this.lblTotalIVA.AutoSize = true;
            this.lblTotalIVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIVA.Location = new System.Drawing.Point(1280, 115);
            this.lblTotalIVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalIVA.Name = "lblTotalIVA";
            this.lblTotalIVA.Size = new System.Drawing.Size(17, 18);
            this.lblTotalIVA.TabIndex = 55;
            this.lblTotalIVA.Text = "0";
            // 
            // lbllblIVA
            // 
            this.lbllblIVA.AutoSize = true;
            this.lbllblIVA.Location = new System.Drawing.Point(1189, 118);
            this.lbllblIVA.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblIVA.Name = "lbllblIVA";
            this.lbllblIVA.Size = new System.Drawing.Size(78, 19);
            this.lbllblIVA.TabIndex = 54;
            this.lbllblIVA.Text = "Total IVA: $";
            // 
            // lblSubtDto105
            // 
            this.lblSubtDto105.AutoSize = true;
            this.lblSubtDto105.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtDto105.Location = new System.Drawing.Point(1027, 83);
            this.lblSubtDto105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtDto105.Name = "lblSubtDto105";
            this.lblSubtDto105.Size = new System.Drawing.Size(17, 18);
            this.lblSubtDto105.TabIndex = 53;
            this.lblSubtDto105.Text = "0";
            // 
            // lblSubtDto21
            // 
            this.lblSubtDto21.AutoSize = true;
            this.lblSubtDto21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtDto21.Location = new System.Drawing.Point(711, 85);
            this.lblSubtDto21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtDto21.Name = "lblSubtDto21";
            this.lblSubtDto21.Size = new System.Drawing.Size(17, 18);
            this.lblSubtDto21.TabIndex = 52;
            this.lblSubtDto21.Text = "0";
            // 
            // lbllblSubTotaldto105
            // 
            this.lbllblSubTotaldto105.AutoSize = true;
            this.lbllblSubTotaldto105.Location = new System.Drawing.Point(816, 85);
            this.lbllblSubTotaldto105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubTotaldto105.Name = "lbllblSubTotaldto105";
            this.lbllblSubTotaldto105.Size = new System.Drawing.Size(179, 19);
            this.lbllblSubTotaldto105.TabIndex = 51;
            this.lbllblSubTotaldto105.Text = "SubTotal c/dto IVA 10,5%: $";
            // 
            // lbllblSubTotaldto21
            // 
            this.lbllblSubTotaldto21.AutoSize = true;
            this.lbllblSubTotaldto21.Location = new System.Drawing.Point(512, 86);
            this.lbllblSubTotaldto21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubTotaldto21.Name = "lbllblSubTotaldto21";
            this.lbllblSubTotaldto21.Size = new System.Drawing.Size(168, 19);
            this.lbllblSubTotaldto21.TabIndex = 50;
            this.lbllblSubTotaldto21.Text = "SubTotal c/dto IVA 21%: $";
            // 
            // lblSubTotal105
            // 
            this.lblSubTotal105.AutoSize = true;
            this.lblSubTotal105.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal105.Location = new System.Drawing.Point(1027, 19);
            this.lblSubTotal105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal105.Name = "lblSubTotal105";
            this.lblSubTotal105.Size = new System.Drawing.Size(17, 18);
            this.lblSubTotal105.TabIndex = 49;
            this.lblSubTotal105.Text = "0";
            // 
            // lblSubTotal21
            // 
            this.lblSubTotal21.AutoSize = true;
            this.lblSubTotal21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal21.Location = new System.Drawing.Point(711, 20);
            this.lblSubTotal21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal21.Name = "lblSubTotal21";
            this.lblSubTotal21.Size = new System.Drawing.Size(17, 18);
            this.lblSubTotal21.TabIndex = 48;
            this.lblSubTotal21.Text = "0";
            // 
            // lbllblSubTotal105
            // 
            this.lbllblSubTotal105.AutoSize = true;
            this.lbllblSubTotal105.Location = new System.Drawing.Point(857, 20);
            this.lbllblSubTotal105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubTotal105.Name = "lbllblSubTotal105";
            this.lbllblSubTotal105.Size = new System.Drawing.Size(143, 19);
            this.lbllblSubTotal105.TabIndex = 47;
            this.lbllblSubTotal105.Text = "SubTotal IVA 10,5%: $";
            // 
            // lbllblSubTotal21
            // 
            this.lbllblSubTotal21.AutoSize = true;
            this.lbllblSubTotal21.Location = new System.Drawing.Point(553, 22);
            this.lbllblSubTotal21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubTotal21.Name = "lbllblSubTotal21";
            this.lbllblSubTotal21.Size = new System.Drawing.Size(132, 19);
            this.lbllblSubTotal21.TabIndex = 46;
            this.lbllblSubTotal21.Text = "SubTotal IVA 21%: $";
            // 
            // lblTotalIva105
            // 
            this.lblTotalIva105.AutoSize = true;
            this.lblTotalIva105.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIva105.Location = new System.Drawing.Point(1027, 115);
            this.lblTotalIva105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalIva105.Name = "lblTotalIva105";
            this.lblTotalIva105.Size = new System.Drawing.Size(17, 18);
            this.lblTotalIva105.TabIndex = 45;
            this.lblTotalIva105.Text = "0";
            // 
            // lbllblIVA105
            // 
            this.lbllblIVA105.AutoSize = true;
            this.lbllblIVA105.Location = new System.Drawing.Point(884, 117);
            this.lbllblIVA105.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblIVA105.Name = "lbllblIVA105";
            this.lbllblIVA105.Size = new System.Drawing.Size(120, 19);
            this.lbllblIVA105.TabIndex = 44;
            this.lbllblIVA105.Text = "Total IVA 10,5%: $";
            // 
            // lblTotalIva21
            // 
            this.lblTotalIva21.AutoSize = true;
            this.lblTotalIva21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalIva21.Location = new System.Drawing.Point(711, 115);
            this.lblTotalIva21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalIva21.Name = "lblTotalIva21";
            this.lblTotalIva21.Size = new System.Drawing.Size(17, 18);
            this.lblTotalIva21.TabIndex = 41;
            this.lblTotalIva21.Text = "0";
            // 
            // lbllblIVA21
            // 
            this.lbllblIVA21.AutoSize = true;
            this.lbllblIVA21.Location = new System.Drawing.Point(580, 117);
            this.lbllblIVA21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblIVA21.Name = "lbllblIVA21";
            this.lbllblIVA21.Size = new System.Drawing.Size(109, 19);
            this.lbllblIVA21.TabIndex = 14;
            this.lbllblIVA21.Text = "Total IVA 21%: $";
            // 
            // lblSubtDto
            // 
            this.lblSubtDto.AutoSize = true;
            this.lblSubtDto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtDto.Location = new System.Drawing.Point(1280, 86);
            this.lblSubtDto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubtDto.Name = "lblSubtDto";
            this.lblSubtDto.Size = new System.Drawing.Size(17, 18);
            this.lblSubtDto.TabIndex = 13;
            this.lblSubtDto.Text = "0";
            // 
            // lbllblSubtDto
            // 
            this.lbllblSubtDto.AutoSize = true;
            this.lbllblSubtDto.Location = new System.Drawing.Point(1133, 86);
            this.lbllblSubtDto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbllblSubtDto.Name = "lbllblSubtDto";
            this.lbllblSubtDto.Size = new System.Drawing.Size(129, 19);
            this.lbllblSubtDto.TabIndex = 12;
            this.lbllblSubtDto.Text = "SubTotal con Dto: $";
            // 
            // lblTotalDto
            // 
            this.lblTotalDto.AutoSize = true;
            this.lblTotalDto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDto.Location = new System.Drawing.Point(1344, 51);
            this.lblTotalDto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDto.Name = "lblTotalDto";
            this.lblTotalDto.Size = new System.Drawing.Size(0, 18);
            this.lblTotalDto.TabIndex = 11;
            // 
            // txtDto
            // 
            this.txtDto.Location = new System.Drawing.Point(1280, 47);
            this.txtDto.Margin = new System.Windows.Forms.Padding(4);
            this.txtDto.MaxLength = 5;
            this.txtDto.Name = "txtDto";
            this.txtDto.Size = new System.Drawing.Size(47, 26);
            this.txtDto.TabIndex = 11;
            this.txtDto.Text = "0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(1175, 53);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 19);
            this.label9.TabIndex = 9;
            this.label9.Text = "Descuento: %";
            // 
            // lblSubTotal
            // 
            this.lblSubTotal.AutoSize = true;
            this.lblSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubTotal.Location = new System.Drawing.Point(1280, 19);
            this.lblSubTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSubTotal.Name = "lblSubTotal";
            this.lblSubTotal.Size = new System.Drawing.Size(17, 18);
            this.lblSubTotal.TabIndex = 8;
            this.lblSubTotal.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1189, 22);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 19);
            this.label8.TabIndex = 7;
            this.label8.Text = "SubTotal: $";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "archivos.gif");
            this.imageList1.Images.SetKeyName(1, "eliminar.gif");
            this.imageList1.Images.SetKeyName(2, "Credito.ico");
            this.imageList1.Images.SetKeyName(3, "Moneda.ico");
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1963, 1274);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dgrDetalle);
            this.Controls.Add(this.grupBoxCabecera);
            this.Controls.Add(this.groupBoxDetalle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmFacturacion";
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.grupBoxCabecera.ResumeLayout(false);
            this.grupBoxCabecera.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgrDetalle)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNroCliente;
        private System.Windows.Forms.TextBox txtNroCliente;
        private System.Windows.Forms.Label lblNomreCliente;
        private System.Windows.Forms.Button brnAnonimo;
        private System.Windows.Forms.Label lblTipoFact;
        private System.Windows.Forms.ComboBox cmbTipoFac;
        private System.Windows.Forms.TextBox txtBV;
        private System.Windows.Forms.TextBox txtNroComp;
        private System.Windows.Forms.ComboBox cmboFormaPago;
        private System.Windows.Forms.Label lblFormaPago;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaVto;
        private System.Windows.Forms.Label lblFechaVto;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.GroupBox grupBoxCabecera;
        private System.Windows.Forms.DataGridView dgrDetalle;
        private System.Windows.Forms.GroupBox groupBoxDetalle;
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
        private System.Windows.Forms.ComboBox cmbCondPago;
        private System.Windows.Forms.Label lblCondPago;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblSubtDto0;
        private System.Windows.Forms.Label lbllblSubTotaldto0;
        private System.Windows.Forms.Label lblSubTotal0;
        private System.Windows.Forms.Label lbllblSubTotal0;
        private System.Windows.Forms.Label lblTotalIva0;
        private System.Windows.Forms.Label lbllblIVA0;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalIVA;
        private System.Windows.Forms.Label lbllblIVA;
        private System.Windows.Forms.Label lblSubtDto105;
        private System.Windows.Forms.Label lblSubtDto21;
        private System.Windows.Forms.Label lbllblSubTotaldto105;
        private System.Windows.Forms.Label lbllblSubTotaldto21;
        private System.Windows.Forms.Label lblSubTotal105;
        private System.Windows.Forms.Label lblSubTotal21;
        private System.Windows.Forms.Label lbllblSubTotal105;
        private System.Windows.Forms.Label lbllblSubTotal21;
        private System.Windows.Forms.Label lblTotalIva105;
        private System.Windows.Forms.Label lbllblIVA105;
        private System.Windows.Forms.Label lblTotalIva21;
        private System.Windows.Forms.Label lbllblIVA21;
        private System.Windows.Forms.Label lblSubtDto;
        private System.Windows.Forms.Label lbllblSubtDto;
        private System.Windows.Forms.Label lblTotalDto;
        private System.Windows.Forms.TextBox txtDto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ImageList imageList1;
    }
}