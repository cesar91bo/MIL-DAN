﻿namespace SistemaFacturacionInventario.Productos
{
    partial class frmProducto
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProducto));
            this.txtDescCorta = new System.Windows.Forms.TextBox();
            this.txtNroProducto = new System.Windows.Forms.TextBox();
            this.lblNroArticulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigoProd = new System.Windows.Forms.TextBox();
            this.btnProveedor = new System.Windows.Forms.Button();
            this.cmbProveedor = new System.Windows.Forms.ComboBox();
            this.lblProveedor = new System.Windows.Forms.Label();
            this.lblErrores = new System.Windows.Forms.Label();
            this.btnUMedida = new System.Windows.Forms.Button();
            this.cmbUMedida = new System.Windows.Forms.ComboBox();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.lblUMedida = new System.Windows.Forms.Label();
            this.txtStockMin = new System.Windows.Forms.TextBox();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.lblLlevarStock = new System.Windows.Forms.Label();
            this.btnRubro = new System.Windows.Forms.Button();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.lblDescLarga = new System.Windows.Forms.Label();
            this.txtDescLarga = new System.Windows.Forms.TextBox();
            this.lblDescCorta = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblProducto = new System.Windows.Forms.Label();
            this.lblBaja = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescCorta
            // 
            this.txtDescCorta.Location = new System.Drawing.Point(152, 57);
            this.txtDescCorta.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescCorta.Name = "txtDescCorta";
            this.txtDescCorta.Size = new System.Drawing.Size(687, 22);
            this.txtDescCorta.TabIndex = 2;
            // 
            // txtNroProducto
            // 
            this.txtNroProducto.Enabled = false;
            this.txtNroProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroProducto.Location = new System.Drawing.Point(152, 22);
            this.txtNroProducto.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroProducto.MaxLength = 6;
            this.txtNroProducto.Name = "txtNroProducto";
            this.txtNroProducto.Size = new System.Drawing.Size(82, 22);
            this.txtNroProducto.TabIndex = 1;
            this.txtNroProducto.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNroProducto_KeyDown);
            this.txtNroProducto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroProducto_KeyPress);
            // 
            // lblNroArticulo
            // 
            this.lblNroArticulo.AutoSize = true;
            this.lblNroArticulo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNroArticulo.Location = new System.Drawing.Point(28, 28);
            this.lblNroArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroArticulo.Name = "lblNroArticulo";
            this.lblNroArticulo.Size = new System.Drawing.Size(82, 13);
            this.lblNroArticulo.TabIndex = 2;
            this.lblNroArticulo.Text = "Nro. Producto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtCodigoProd);
            this.groupBox1.Controls.Add(this.btnProveedor);
            this.groupBox1.Controls.Add(this.cmbProveedor);
            this.groupBox1.Controls.Add(this.lblProveedor);
            this.groupBox1.Controls.Add(this.lblErrores);
            this.groupBox1.Controls.Add(this.btnUMedida);
            this.groupBox1.Controls.Add(this.cmbUMedida);
            this.groupBox1.Controls.Add(this.lblStockMinimo);
            this.groupBox1.Controls.Add(this.lblUMedida);
            this.groupBox1.Controls.Add(this.txtStockMin);
            this.groupBox1.Controls.Add(this.lblStockActual);
            this.groupBox1.Controls.Add(this.txtStockActual);
            this.groupBox1.Controls.Add(this.chkStock);
            this.groupBox1.Controls.Add(this.lblLlevarStock);
            this.groupBox1.Controls.Add(this.btnRubro);
            this.groupBox1.Controls.Add(this.cmbRubro);
            this.groupBox1.Controls.Add(this.lblRubro);
            this.groupBox1.Controls.Add(this.lblDescLarga);
            this.groupBox1.Controls.Add(this.txtDescLarga);
            this.groupBox1.Controls.Add(this.lblDescCorta);
            this.groupBox1.Controls.Add(this.btnVolver);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.lblNroArticulo);
            this.groupBox1.Controls.Add(this.txtNroProducto);
            this.groupBox1.Controls.Add(this.txtDescCorta);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(113, 118);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(895, 377);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(540, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Código Producto:";
            // 
            // txtCodigoProd
            // 
            this.txtCodigoProd.Enabled = false;
            this.txtCodigoProd.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtCodigoProd.Location = new System.Drawing.Point(680, 19);
            this.txtCodigoProd.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoProd.MaxLength = 20;
            this.txtCodigoProd.Name = "txtCodigoProd";
            this.txtCodigoProd.Size = new System.Drawing.Size(159, 22);
            this.txtCodigoProd.TabIndex = 24;
            // 
            // btnProveedor
            // 
            this.btnProveedor.Image = ((System.Drawing.Image)(resources.GetObject("btnProveedor.Image")));
            this.btnProveedor.Location = new System.Drawing.Point(392, 265);
            this.btnProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.btnProveedor.Name = "btnProveedor";
            this.btnProveedor.Size = new System.Drawing.Size(35, 35);
            this.btnProveedor.TabIndex = 22;
            this.btnProveedor.UseVisualStyleBackColor = true;
            this.btnProveedor.Click += new System.EventHandler(this.btnProveedor_Click);
            // 
            // cmbProveedor
            // 
            this.cmbProveedor.FormattingEnabled = true;
            this.cmbProveedor.Location = new System.Drawing.Point(152, 271);
            this.cmbProveedor.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProveedor.Name = "cmbProveedor";
            this.cmbProveedor.Size = new System.Drawing.Size(227, 21);
            this.cmbProveedor.TabIndex = 21;
            // 
            // lblProveedor
            // 
            this.lblProveedor.AutoSize = true;
            this.lblProveedor.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblProveedor.Location = new System.Drawing.Point(54, 276);
            this.lblProveedor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProveedor.Name = "lblProveedor";
            this.lblProveedor.Size = new System.Drawing.Size(62, 13);
            this.lblProveedor.TabIndex = 23;
            this.lblProveedor.Text = "Proveedor:";
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblErrores.ForeColor = System.Drawing.Color.Red;
            this.lblErrores.Location = new System.Drawing.Point(12, 303);
            this.lblErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(43, 13);
            this.lblErrores.TabIndex = 20;
            this.lblErrores.Text = "errores";
            this.lblErrores.Visible = false;
            // 
            // btnUMedida
            // 
            this.btnUMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnUMedida.Image")));
            this.btnUMedida.Location = new System.Drawing.Point(392, 229);
            this.btnUMedida.Margin = new System.Windows.Forms.Padding(4);
            this.btnUMedida.Name = "btnUMedida";
            this.btnUMedida.Size = new System.Drawing.Size(35, 35);
            this.btnUMedida.TabIndex = 14;
            this.btnUMedida.UseVisualStyleBackColor = true;
            this.btnUMedida.Click += new System.EventHandler(this.btnUMedida_Click);
            // 
            // cmbUMedida
            // 
            this.cmbUMedida.FormattingEnabled = true;
            this.cmbUMedida.Location = new System.Drawing.Point(152, 238);
            this.cmbUMedida.Margin = new System.Windows.Forms.Padding(4);
            this.cmbUMedida.Name = "cmbUMedida";
            this.cmbUMedida.Size = new System.Drawing.Size(227, 21);
            this.cmbUMedida.TabIndex = 5;
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblStockMinimo.Location = new System.Drawing.Point(638, 268);
            this.lblStockMinimo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockMinimo.Name = "lblStockMinimo";
            this.lblStockMinimo.Size = new System.Drawing.Size(80, 13);
            this.lblStockMinimo.TabIndex = 16;
            this.lblStockMinimo.Text = "Stock Mínimo:";
            // 
            // lblUMedida
            // 
            this.lblUMedida.AutoSize = true;
            this.lblUMedida.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblUMedida.Location = new System.Drawing.Point(10, 243);
            this.lblUMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUMedida.Name = "lblUMedida";
            this.lblUMedida.Size = new System.Drawing.Size(106, 13);
            this.lblUMedida.TabIndex = 17;
            this.lblUMedida.Text = "Unidad de Medida:";
            // 
            // txtStockMin
            // 
            this.txtStockMin.Enabled = false;
            this.txtStockMin.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtStockMin.Location = new System.Drawing.Point(757, 265);
            this.txtStockMin.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockMin.MaxLength = 6;
            this.txtStockMin.Name = "txtStockMin";
            this.txtStockMin.Size = new System.Drawing.Size(82, 22);
            this.txtStockMin.TabIndex = 8;
            this.txtStockMin.Text = "0";
            this.txtStockMin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockMin_KeyPress);
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblStockActual.Location = new System.Drawing.Point(645, 238);
            this.lblStockActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(73, 13);
            this.lblStockActual.TabIndex = 14;
            this.lblStockActual.Text = "Stock Actual:";
            // 
            // txtStockActual
            // 
            this.txtStockActual.Enabled = false;
            this.txtStockActual.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtStockActual.Location = new System.Drawing.Point(757, 229);
            this.txtStockActual.Margin = new System.Windows.Forms.Padding(4);
            this.txtStockActual.MaxLength = 6;
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(82, 22);
            this.txtStockActual.TabIndex = 7;
            this.txtStockActual.Text = "0";
            this.txtStockActual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStockActual_KeyPress);
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Location = new System.Drawing.Point(757, 203);
            this.chkStock.Margin = new System.Windows.Forms.Padding(4);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(15, 14);
            this.chkStock.TabIndex = 6;
            this.chkStock.UseVisualStyleBackColor = true;
            this.chkStock.CheckedChanged += new System.EventHandler(this.chkStock_CheckedChanged);
            // 
            // lblLlevarStock
            // 
            this.lblLlevarStock.AutoSize = true;
            this.lblLlevarStock.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblLlevarStock.Location = new System.Drawing.Point(648, 205);
            this.lblLlevarStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLlevarStock.Name = "lblLlevarStock";
            this.lblLlevarStock.Size = new System.Drawing.Size(70, 13);
            this.lblLlevarStock.TabIndex = 11;
            this.lblLlevarStock.Text = "Llevar Stock:";
            // 
            // btnRubro
            // 
            this.btnRubro.Image = ((System.Drawing.Image)(resources.GetObject("btnRubro.Image")));
            this.btnRubro.Location = new System.Drawing.Point(392, 194);
            this.btnRubro.Margin = new System.Windows.Forms.Padding(4);
            this.btnRubro.Name = "btnRubro";
            this.btnRubro.Size = new System.Drawing.Size(35, 35);
            this.btnRubro.TabIndex = 13;
            this.btnRubro.UseVisualStyleBackColor = true;
            this.btnRubro.Click += new System.EventHandler(this.btnRubro_Click);
            // 
            // cmbRubro
            // 
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(152, 208);
            this.cmbRubro.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(227, 21);
            this.cmbRubro.TabIndex = 4;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRubro.Location = new System.Drawing.Point(55, 216);
            this.lblRubro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(60, 13);
            this.lblRubro.TabIndex = 8;
            this.lblRubro.Text = "Categoría:";
            // 
            // lblDescLarga
            // 
            this.lblDescLarga.AutoSize = true;
            this.lblDescLarga.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescLarga.Location = new System.Drawing.Point(40, 99);
            this.lblDescLarga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescLarga.Name = "lblDescLarga";
            this.lblDescLarga.Size = new System.Drawing.Size(70, 13);
            this.lblDescLarga.TabIndex = 7;
            this.lblDescLarga.Text = "Descripción:";
            // 
            // txtDescLarga
            // 
            this.txtDescLarga.Location = new System.Drawing.Point(152, 96);
            this.txtDescLarga.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescLarga.Multiline = true;
            this.txtDescLarga.Name = "txtDescLarga";
            this.txtDescLarga.Size = new System.Drawing.Size(687, 84);
            this.txtDescLarga.TabIndex = 3;
            // 
            // lblDescCorta
            // 
            this.lblDescCorta.AutoSize = true;
            this.lblDescCorta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescCorta.Location = new System.Drawing.Point(59, 60);
            this.lblDescCorta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescCorta.Name = "lblDescCorta";
            this.lblDescCorta.Size = new System.Drawing.Size(51, 13);
            this.lblDescCorta.TabIndex = 5;
            this.lblDescCorta.Text = "Nombre:";
            // 
            // btnVolver
            // 
            this.btnVolver.Enabled = false;
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(284, 14);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(35, 35);
            this.btnVolver.TabIndex = 12;
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::SistemaFacturacionInventario.Properties.Resources.icons8_buscar_20;
            this.btnBuscar.Location = new System.Drawing.Point(241, 14);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProducto.Location = new System.Drawing.Point(521, 65);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(80, 21);
            this.lblProducto.TabIndex = 5;
            this.lblProducto.Text = "Producto";
            // 
            // lblBaja
            // 
            this.lblBaja.AutoSize = true;
            this.lblBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblBaja.Location = new System.Drawing.Point(58, 364);
            this.lblBaja.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaja.Name = "lblBaja";
            this.lblBaja.Size = new System.Drawing.Size(0, 13);
            this.lblBaja.TabIndex = 20;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(818, 548);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Enabled = false;
            this.btnBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnBaja.Image")));
            this.btnBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaja.Location = new System.Drawing.Point(917, 548);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(91, 43);
            this.btnBaja.TabIndex = 10;
            this.btnBaja.Text = "Eliminar";
            this.btnBaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(720, 548);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 43);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1084, 595);
            this.Controls.Add(this.lblBaja);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmProducto";
            this.Text = "Producto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescCorta;
        private System.Windows.Forms.TextBox txtNroProducto;
        private System.Windows.Forms.Label lblNroArticulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblDescCorta;
        private System.Windows.Forms.Label lblDescLarga;
        private System.Windows.Forms.TextBox txtDescLarga;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Button btnRubro;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.CheckBox chkStock;
        private System.Windows.Forms.Label lblLlevarStock;
        private System.Windows.Forms.ComboBox cmbUMedida;
        private System.Windows.Forms.Label lblUMedida;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.TextBox txtStockMin;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnUMedida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblBaja;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Button btnProveedor;
        private System.Windows.Forms.ComboBox cmbProveedor;
        private System.Windows.Forms.Label lblProveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigoProd;
    }
}