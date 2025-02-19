namespace SistemaFacturacionInventario.Productos
{
    partial class frmPrecios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecios));
            this.txtNroProducto = new System.Windows.Forms.TextBox();
            this.lblNroArticulo = new System.Windows.Forms.Label();
            this.lblPrecioBase = new System.Windows.Forms.Label();
            this.txtPrecioBase = new System.Windows.Forms.TextBox();
            this.rdbSinIVA = new System.Windows.Forms.RadioButton();
            this.rdbConIVA = new System.Windows.Forms.RadioButton();
            this.lblFechaPrecio = new System.Windows.Forms.Label();
            this.grpBoxProducto = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNombreProd = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.grpBoxVariables = new System.Windows.Forms.GroupBox();
            this.cmbIVA = new System.Windows.Forms.ComboBox();
            this.lblBonificacion = new System.Windows.Forms.Label();
            this.txtBonif = new System.Windows.Forms.TextBox();
            this.lblCostoFinal = new System.Windows.Forms.Label();
            this.lblGanancia = new System.Windows.Forms.Label();
            this.txtGanancia = new System.Windows.Forms.TextBox();
            this.lblTipoIVA = new System.Windows.Forms.Label();
            this.lblBonificacionNro = new System.Windows.Forms.Label();
            this.lblGananciaNro = new System.Windows.Forms.Label();
            this.lblIVANro = new System.Windows.Forms.Label();
            this.lblContadoSIVA = new System.Windows.Forms.Label();
            this.txtContadoSIVA = new System.Windows.Forms.TextBox();
            this.lblFlete = new System.Windows.Forms.Label();
            this.txtFlete = new System.Windows.Forms.TextBox();
            this.lblFleteNro = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtContadoConIVA = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCostoFinal = new System.Windows.Forms.TextBox();
            this.grpBoxProducto.SuspendLayout();
            this.grpBoxVariables.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNroProducto
            // 
            this.txtNroProducto.Enabled = false;
            this.txtNroProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroProducto.Location = new System.Drawing.Point(117, 14);
            this.txtNroProducto.MaxLength = 6;
            this.txtNroProducto.Name = "txtNroProducto";
            this.txtNroProducto.Size = new System.Drawing.Size(71, 22);
            this.txtNroProducto.TabIndex = 13;
            this.txtNroProducto.TabStop = false;
            this.txtNroProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroProducto_KeyDown);
            this.txtNroProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroProducto_KeyPress);
            this.txtNroProducto.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtNroProducto_PreviewKeyDown);
            // 
            // lblNroArticulo
            // 
            this.lblNroArticulo.AutoSize = true;
            this.lblNroArticulo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNroArticulo.Location = new System.Drawing.Point(11, 19);
            this.lblNroArticulo.Name = "lblNroArticulo";
            this.lblNroArticulo.Size = new System.Drawing.Size(82, 13);
            this.lblNroArticulo.TabIndex = 14;
            this.lblNroArticulo.Text = "Nro. Producto:";
            // 
            // lblPrecioBase
            // 
            this.lblPrecioBase.AutoSize = true;
            this.lblPrecioBase.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPrecioBase.Location = new System.Drawing.Point(19, 58);
            this.lblPrecioBase.Name = "lblPrecioBase";
            this.lblPrecioBase.Size = new System.Drawing.Size(74, 13);
            this.lblPrecioBase.TabIndex = 17;
            this.lblPrecioBase.Text = "Precio Costo:";
            // 
            // txtPrecioBase
            // 
            this.txtPrecioBase.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtPrecioBase.Location = new System.Drawing.Point(117, 55);
            this.txtPrecioBase.MaxLength = 6;
            this.txtPrecioBase.Name = "txtPrecioBase";
            this.txtPrecioBase.Size = new System.Drawing.Size(71, 22);
            this.txtPrecioBase.TabIndex = 0;
            this.txtPrecioBase.Text = "0";
            this.txtPrecioBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPrecioBase.TextChanged += new System.EventHandler(this.txtPrecioBase_TextChanged);
            this.txtPrecioBase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioBase_KeyPress);
            this.txtPrecioBase.Leave += new System.EventHandler(this.txtPrecioBase_Leave);
            // 
            // rdbSinIVA
            // 
            this.rdbSinIVA.AutoSize = true;
            this.rdbSinIVA.Location = new System.Drawing.Point(210, 57);
            this.rdbSinIVA.Name = "rdbSinIVA";
            this.rdbSinIVA.Size = new System.Drawing.Size(60, 17);
            this.rdbSinIVA.TabIndex = 2;
            this.rdbSinIVA.TabStop = true;
            this.rdbSinIVA.Text = "Sin IVA";
            this.rdbSinIVA.UseVisualStyleBackColor = true;
            // 
            // rdbConIVA
            // 
            this.rdbConIVA.AutoSize = true;
            this.rdbConIVA.Checked = true;
            this.rdbConIVA.Location = new System.Drawing.Point(267, 58);
            this.rdbConIVA.Name = "rdbConIVA";
            this.rdbConIVA.Size = new System.Drawing.Size(65, 17);
            this.rdbConIVA.TabIndex = 3;
            this.rdbConIVA.Text = "Con IVA";
            this.rdbConIVA.UseVisualStyleBackColor = true;
            // 
            // lblFechaPrecio
            // 
            this.lblFechaPrecio.AutoSize = true;
            this.lblFechaPrecio.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFechaPrecio.Location = new System.Drawing.Point(297, 19);
            this.lblFechaPrecio.Name = "lblFechaPrecio";
            this.lblFechaPrecio.Size = new System.Drawing.Size(74, 13);
            this.lblFechaPrecio.TabIndex = 21;
            this.lblFechaPrecio.Text = "Fecha Precio:";
            // 
            // grpBoxProducto
            // 
            this.grpBoxProducto.Controls.Add(this.textBox1);
            this.grpBoxProducto.Controls.Add(this.btnBuscar);
            this.grpBoxProducto.Controls.Add(this.lblNombreProd);
            this.grpBoxProducto.Controls.Add(this.lblFechaPrecio);
            this.grpBoxProducto.Controls.Add(this.rdbConIVA);
            this.grpBoxProducto.Controls.Add(this.rdbSinIVA);
            this.grpBoxProducto.Controls.Add(this.txtPrecioBase);
            this.grpBoxProducto.Controls.Add(this.lblPrecioBase);
            this.grpBoxProducto.Controls.Add(this.btnVolver);
            this.grpBoxProducto.Controls.Add(this.lblNroArticulo);
            this.grpBoxProducto.Controls.Add(this.txtNroProducto);
            this.grpBoxProducto.Location = new System.Drawing.Point(16, 14);
            this.grpBoxProducto.Name = "grpBoxProducto";
            this.grpBoxProducto.Size = new System.Drawing.Size(779, 94);
            this.grpBoxProducto.TabIndex = 22;
            this.grpBoxProducto.TabStop = false;
            this.grpBoxProducto.Text = "Producto";
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.textBox1.Location = new System.Drawing.Point(117, 165);
            this.textBox1.MaxLength = 6;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(71, 22);
            this.textBox1.TabIndex = 24;
            this.textBox1.Text = "0";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::SistemaFacturacionInventario.Properties.Resources.icons8_buscar_20;
            this.btnBuscar.Location = new System.Drawing.Point(198, 9);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 28);
            this.btnBuscar.TabIndex = 23;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblNombreProd
            // 
            this.lblNombreProd.AutoSize = true;
            this.lblNombreProd.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblNombreProd.Location = new System.Drawing.Point(374, 59);
            this.lblNombreProd.Name = "lblNombreProd";
            this.lblNombreProd.Size = new System.Drawing.Size(120, 13);
            this.lblNombreProd.TabIndex = 22;
            this.lblNombreProd.Text = "Nombre del Producto";
            // 
            // btnVolver
            // 
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(240, 8);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(30, 30);
            this.btnVolver.TabIndex = 16;
            this.btnVolver.TabStop = false;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // grpBoxVariables
            // 
            this.grpBoxVariables.Controls.Add(this.cmbIVA);
            this.grpBoxVariables.Location = new System.Drawing.Point(16, 123);
            this.grpBoxVariables.Name = "grpBoxVariables";
            this.grpBoxVariables.Size = new System.Drawing.Size(779, 103);
            this.grpBoxVariables.TabIndex = 24;
            this.grpBoxVariables.TabStop = false;
            this.grpBoxVariables.Text = "Variables";
            // 
            // cmbIVA
            // 
            this.cmbIVA.FormattingEnabled = true;
            this.cmbIVA.Items.AddRange(new object[] {
            "21",
            "10.5",
            "0"});
            this.cmbIVA.Location = new System.Drawing.Point(431, 57);
            this.cmbIVA.Name = "cmbIVA";
            this.cmbIVA.Size = new System.Drawing.Size(43, 21);
            this.cmbIVA.TabIndex = 6;
            this.cmbIVA.SelectedValueChanged += new System.EventHandler(this.cmbIVA_SelectedValueChanged);
            // 
            // lblBonificacion
            // 
            this.lblBonificacion.AutoSize = true;
            this.lblBonificacion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblBonificacion.Location = new System.Drawing.Point(41, 150);
            this.lblBonificacion.Name = "lblBonificacion";
            this.lblBonificacion.Size = new System.Drawing.Size(86, 13);
            this.lblBonificacion.TabIndex = 18;
            this.lblBonificacion.Text = "Bonificación %:";
            // 
            // txtBonif
            // 
            this.txtBonif.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtBonif.Location = new System.Drawing.Point(133, 147);
            this.txtBonif.MaxLength = 6;
            this.txtBonif.Name = "txtBonif";
            this.txtBonif.Size = new System.Drawing.Size(43, 22);
            this.txtBonif.TabIndex = 4;
            this.txtBonif.Text = "0.00";
            this.txtBonif.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBonif.TextChanged += new System.EventHandler(this.txtBonif_TextChanged);
            this.txtBonif.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBonif_KeyPress);
            this.txtBonif.Leave += new System.EventHandler(this.txtBonif_Leave);
            // 
            // lblCostoFinal
            // 
            this.lblCostoFinal.AutoSize = true;
            this.lblCostoFinal.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCostoFinal.Location = new System.Drawing.Point(59, 183);
            this.lblCostoFinal.Name = "lblCostoFinal";
            this.lblCostoFinal.Size = new System.Drawing.Size(68, 13);
            this.lblCostoFinal.TabIndex = 25;
            this.lblCostoFinal.Text = "Costo Final:";
            // 
            // lblGanancia
            // 
            this.lblGanancia.AutoSize = true;
            this.lblGanancia.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblGanancia.Location = new System.Drawing.Point(319, 150);
            this.lblGanancia.Name = "lblGanancia";
            this.lblGanancia.Size = new System.Drawing.Size(122, 13);
            this.lblGanancia.TabIndex = 26;
            this.lblGanancia.Text = "Margen de Ganacia %:";
            // 
            // txtGanancia
            // 
            this.txtGanancia.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtGanancia.Location = new System.Drawing.Point(447, 147);
            this.txtGanancia.MaxLength = 6;
            this.txtGanancia.Name = "txtGanancia";
            this.txtGanancia.Size = new System.Drawing.Size(43, 22);
            this.txtGanancia.TabIndex = 5;
            this.txtGanancia.Text = "0.00";
            this.txtGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtGanancia.TextChanged += new System.EventHandler(this.txtGanancia_TextChanged);
            this.txtGanancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGanancia_KeyPress);
            this.txtGanancia.Leave += new System.EventHandler(this.txtGanancia_Leave);
            // 
            // lblTipoIVA
            // 
            this.lblTipoIVA.AutoSize = true;
            this.lblTipoIVA.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTipoIVA.Location = new System.Drawing.Point(390, 183);
            this.lblTipoIVA.Name = "lblTipoIVA";
            this.lblTipoIVA.Size = new System.Drawing.Size(51, 13);
            this.lblTipoIVA.TabIndex = 28;
            this.lblTipoIVA.Text = "Tipo IVA:";
            // 
            // lblBonificacionNro
            // 
            this.lblBonificacionNro.AutoSize = true;
            this.lblBonificacionNro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblBonificacionNro.Location = new System.Drawing.Point(182, 150);
            this.lblBonificacionNro.Name = "lblBonificacionNro";
            this.lblBonificacionNro.Size = new System.Drawing.Size(28, 13);
            this.lblBonificacionNro.TabIndex = 29;
            this.lblBonificacionNro.Text = "0.00";
            // 
            // lblGananciaNro
            // 
            this.lblGananciaNro.AutoSize = true;
            this.lblGananciaNro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblGananciaNro.Location = new System.Drawing.Point(496, 150);
            this.lblGananciaNro.Name = "lblGananciaNro";
            this.lblGananciaNro.Size = new System.Drawing.Size(28, 13);
            this.lblGananciaNro.TabIndex = 30;
            this.lblGananciaNro.Text = "0.00";
            // 
            // lblIVANro
            // 
            this.lblIVANro.AutoSize = true;
            this.lblIVANro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblIVANro.Location = new System.Drawing.Point(496, 183);
            this.lblIVANro.Name = "lblIVANro";
            this.lblIVANro.Size = new System.Drawing.Size(28, 13);
            this.lblIVANro.TabIndex = 31;
            this.lblIVANro.Text = "0.00";
            // 
            // lblContadoSIVA
            // 
            this.lblContadoSIVA.AutoSize = true;
            this.lblContadoSIVA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblContadoSIVA.Location = new System.Drawing.Point(163, 265);
            this.lblContadoSIVA.Name = "lblContadoSIVA";
            this.lblContadoSIVA.Size = new System.Drawing.Size(94, 13);
            this.lblContadoSIVA.TabIndex = 32;
            this.lblContadoSIVA.Text = "Contado Sin IVA:";
            // 
            // txtContadoSIVA
            // 
            this.txtContadoSIVA.Enabled = false;
            this.txtContadoSIVA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtContadoSIVA.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtContadoSIVA.Location = new System.Drawing.Point(281, 262);
            this.txtContadoSIVA.MaxLength = 6;
            this.txtContadoSIVA.Name = "txtContadoSIVA";
            this.txtContadoSIVA.Size = new System.Drawing.Size(71, 22);
            this.txtContadoSIVA.TabIndex = 33;
            this.txtContadoSIVA.Text = "0";
            this.txtContadoSIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblFlete
            // 
            this.lblFlete.AutoSize = true;
            this.lblFlete.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFlete.Location = new System.Drawing.Point(616, 150);
            this.lblFlete.Name = "lblFlete";
            this.lblFlete.Size = new System.Drawing.Size(47, 13);
            this.lblFlete.TabIndex = 34;
            this.lblFlete.Text = "Flete %:";
            // 
            // txtFlete
            // 
            this.txtFlete.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtFlete.Location = new System.Drawing.Point(669, 147);
            this.txtFlete.MaxLength = 6;
            this.txtFlete.Name = "txtFlete";
            this.txtFlete.Size = new System.Drawing.Size(43, 22);
            this.txtFlete.TabIndex = 7;
            this.txtFlete.Text = "0.00";
            this.txtFlete.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFlete.TextChanged += new System.EventHandler(this.txtFlete_TextChanged);
            this.txtFlete.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFlete_KeyPress);
            this.txtFlete.Leave += new System.EventHandler(this.txtFlete_Leave);
            // 
            // lblFleteNro
            // 
            this.lblFleteNro.AutoSize = true;
            this.lblFleteNro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblFleteNro.Location = new System.Drawing.Point(718, 150);
            this.lblFleteNro.Name = "lblFleteNro";
            this.lblFleteNro.Size = new System.Drawing.Size(28, 13);
            this.lblFleteNro.TabIndex = 36;
            this.lblFleteNro.Text = "0.00";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(392, 265);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 37;
            this.label1.Text = "Contado Con IVA:";
            // 
            // txtContadoConIVA
            // 
            this.txtContadoConIVA.Enabled = false;
            this.txtContadoConIVA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.txtContadoConIVA.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtContadoConIVA.Location = new System.Drawing.Point(518, 262);
            this.txtContadoConIVA.MaxLength = 6;
            this.txtContadoConIVA.Name = "txtContadoConIVA";
            this.txtContadoConIVA.Size = new System.Drawing.Size(71, 22);
            this.txtContadoConIVA.TabIndex = 38;
            this.txtContadoConIVA.Text = "0";
            this.txtContadoConIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(705, 334);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(607, 334);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 43);
            this.btnGuardar.TabIndex = 8;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCostoFinal
            // 
            this.txtCostoFinal.Enabled = false;
            this.txtCostoFinal.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCostoFinal.Location = new System.Drawing.Point(133, 179);
            this.txtCostoFinal.MaxLength = 6;
            this.txtCostoFinal.Name = "txtCostoFinal";
            this.txtCostoFinal.Size = new System.Drawing.Size(71, 22);
            this.txtCostoFinal.TabIndex = 41;
            this.txtCostoFinal.Text = "0";
            this.txtCostoFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmPrecios
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(816, 390);
            this.Controls.Add(this.txtCostoFinal);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtContadoConIVA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFleteNro);
            this.Controls.Add(this.txtFlete);
            this.Controls.Add(this.lblFlete);
            this.Controls.Add(this.txtContadoSIVA);
            this.Controls.Add(this.lblContadoSIVA);
            this.Controls.Add(this.lblIVANro);
            this.Controls.Add(this.lblGananciaNro);
            this.Controls.Add(this.lblBonificacionNro);
            this.Controls.Add(this.lblTipoIVA);
            this.Controls.Add(this.txtGanancia);
            this.Controls.Add(this.lblGanancia);
            this.Controls.Add(this.lblCostoFinal);
            this.Controls.Add(this.txtBonif);
            this.Controls.Add(this.lblBonificacion);
            this.Controls.Add(this.grpBoxProducto);
            this.Controls.Add(this.grpBoxVariables);
            this.Name = "frmPrecios";
            this.Text = "Precios";
            this.Load += new System.EventHandler(this.frmPrecios_Load);
            this.Shown += new System.EventHandler(this.frmPrecios_Shown);
            this.grpBoxProducto.ResumeLayout(false);
            this.grpBoxProducto.PerformLayout();
            this.grpBoxVariables.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNroProducto;
        private System.Windows.Forms.Label lblNroArticulo;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblPrecioBase;
        private System.Windows.Forms.TextBox txtPrecioBase;
        private System.Windows.Forms.RadioButton rdbSinIVA;
        private System.Windows.Forms.RadioButton rdbConIVA;
        private System.Windows.Forms.Label lblFechaPrecio;
        private System.Windows.Forms.GroupBox grpBoxProducto;
        private System.Windows.Forms.GroupBox grpBoxVariables;
        private System.Windows.Forms.Label lblBonificacion;
        private System.Windows.Forms.TextBox txtBonif;
        private System.Windows.Forms.Label lblCostoFinal;
        private System.Windows.Forms.Label lblGanancia;
        private System.Windows.Forms.TextBox txtGanancia;
        private System.Windows.Forms.Label lblTipoIVA;
        private System.Windows.Forms.ComboBox cmbIVA;
        private System.Windows.Forms.Label lblBonificacionNro;
        private System.Windows.Forms.Label lblGananciaNro;
        private System.Windows.Forms.Label lblIVANro;
        private System.Windows.Forms.Label lblNombreProd;
        private System.Windows.Forms.Label lblContadoSIVA;
        private System.Windows.Forms.TextBox txtContadoSIVA;
        private System.Windows.Forms.Label lblFlete;
        private System.Windows.Forms.TextBox txtFlete;
        private System.Windows.Forms.Label lblFleteNro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtContadoConIVA;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtCostoFinal;
    }
}