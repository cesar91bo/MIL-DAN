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
            this.txtDescrCorta = new System.Windows.Forms.TextBox();
            this.txtNroProducto = new System.Windows.Forms.TextBox();
            this.lblNroArticulo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.lblStockMinimo = new System.Windows.Forms.Label();
            this.lblUMedida = new System.Windows.Forms.Label();
            this.txtStockMin = new System.Windows.Forms.TextBox();
            this.lblStockActual = new System.Windows.Forms.Label();
            this.txtStockActual = new System.Windows.Forms.TextBox();
            this.chkStock = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.lblRubro = new System.Windows.Forms.Label();
            this.lblDescLarga = new System.Windows.Forms.Label();
            this.tctDescLarga = new System.Windows.Forms.TextBox();
            this.lblDescCorta = new System.Windows.Forms.Label();
            this.lblProducto = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnUMedida = new System.Windows.Forms.Button();
            this.btnRubro = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDescrCorta
            // 
            this.txtDescrCorta.Location = new System.Drawing.Point(152, 77);
            this.txtDescrCorta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDescrCorta.Name = "txtDescrCorta";
            this.txtDescrCorta.Size = new System.Drawing.Size(310, 22);
            this.txtDescrCorta.TabIndex = 0;
            // 
            // txtNroProducto
            // 
            this.txtNroProducto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroProducto.Location = new System.Drawing.Point(152, 26);
            this.txtNroProducto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNroProducto.Name = "txtNroProducto";
            this.txtNroProducto.Size = new System.Drawing.Size(82, 22);
            this.txtNroProducto.TabIndex = 1;
            // 
            // lblNroArticulo
            // 
            this.lblNroArticulo.AutoSize = true;
            this.lblNroArticulo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNroArticulo.Location = new System.Drawing.Point(20, 38);
            this.lblNroArticulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroArticulo.Name = "lblNroArticulo";
            this.lblNroArticulo.Size = new System.Drawing.Size(82, 13);
            this.lblNroArticulo.TabIndex = 2;
            this.lblNroArticulo.Text = "Nro. Producto:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnUMedida);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.lblStockMinimo);
            this.groupBox1.Controls.Add(this.lblUMedida);
            this.groupBox1.Controls.Add(this.txtStockMin);
            this.groupBox1.Controls.Add(this.lblStockActual);
            this.groupBox1.Controls.Add(this.txtStockActual);
            this.groupBox1.Controls.Add(this.chkStock);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnRubro);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.lblRubro);
            this.groupBox1.Controls.Add(this.lblDescLarga);
            this.groupBox1.Controls.Add(this.tctDescLarga);
            this.groupBox1.Controls.Add(this.lblDescCorta);
            this.groupBox1.Controls.Add(this.btnVolver);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.lblNroArticulo);
            this.groupBox1.Controls.Add(this.txtNroProducto);
            this.groupBox1.Controls.Add(this.txtDescrCorta);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(49, 96);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(895, 264);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(615, 69);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(227, 21);
            this.comboBox2.TabIndex = 18;
            // 
            // lblStockMinimo
            // 
            this.lblStockMinimo.AutoSize = true;
            this.lblStockMinimo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblStockMinimo.Location = new System.Drawing.Point(484, 167);
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
            this.lblUMedida.Location = new System.Drawing.Point(469, 77);
            this.lblUMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUMedida.Name = "lblUMedida";
            this.lblUMedida.Size = new System.Drawing.Size(106, 13);
            this.lblUMedida.TabIndex = 17;
            this.lblUMedida.Text = "Unidad de Medida:";
            // 
            // txtStockMin
            // 
            this.txtStockMin.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtStockMin.Location = new System.Drawing.Point(615, 167);
            this.txtStockMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStockMin.Name = "txtStockMin";
            this.txtStockMin.Size = new System.Drawing.Size(82, 22);
            this.txtStockMin.TabIndex = 15;
            // 
            // lblStockActual
            // 
            this.lblStockActual.AutoSize = true;
            this.lblStockActual.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblStockActual.Location = new System.Drawing.Point(489, 137);
            this.lblStockActual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStockActual.Name = "lblStockActual";
            this.lblStockActual.Size = new System.Drawing.Size(73, 13);
            this.lblStockActual.TabIndex = 14;
            this.lblStockActual.Text = "Stock Actual:";
            // 
            // txtStockActual
            // 
            this.txtStockActual.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtStockActual.Location = new System.Drawing.Point(615, 131);
            this.txtStockActual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStockActual.Name = "txtStockActual";
            this.txtStockActual.Size = new System.Drawing.Size(82, 22);
            this.txtStockActual.TabIndex = 13;
            // 
            // chkStock
            // 
            this.chkStock.AutoSize = true;
            this.chkStock.Location = new System.Drawing.Point(615, 105);
            this.chkStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkStock.Name = "chkStock";
            this.chkStock.Size = new System.Drawing.Size(18, 18);
            this.chkStock.TabIndex = 12;
            this.chkStock.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(490, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Llevar Stock:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(615, 34);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(227, 21);
            this.comboBox1.TabIndex = 9;
            // 
            // lblRubro
            // 
            this.lblRubro.AutoSize = true;
            this.lblRubro.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRubro.Location = new System.Drawing.Point(506, 47);
            this.lblRubro.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRubro.Name = "lblRubro";
            this.lblRubro.Size = new System.Drawing.Size(42, 13);
            this.lblRubro.TabIndex = 8;
            this.lblRubro.Text = "Rubro:";
            // 
            // lblDescLarga
            // 
            this.lblDescLarga.AutoSize = true;
            this.lblDescLarga.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescLarga.Location = new System.Drawing.Point(9, 119);
            this.lblDescLarga.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescLarga.Name = "lblDescLarga";
            this.lblDescLarga.Size = new System.Drawing.Size(101, 13);
            this.lblDescLarga.TabIndex = 7;
            this.lblDescLarga.Text = "Descripción Larga:";
            // 
            // tctDescLarga
            // 
            this.tctDescLarga.Location = new System.Drawing.Point(152, 116);
            this.tctDescLarga.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tctDescLarga.Multiline = true;
            this.tctDescLarga.Name = "tctDescLarga";
            this.tctDescLarga.Size = new System.Drawing.Size(310, 105);
            this.tctDescLarga.TabIndex = 6;
            // 
            // lblDescCorta
            // 
            this.lblDescCorta.AutoSize = true;
            this.lblDescCorta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescCorta.Location = new System.Drawing.Point(9, 78);
            this.lblDescCorta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescCorta.Name = "lblDescCorta";
            this.lblDescCorta.Size = new System.Drawing.Size(101, 13);
            this.lblDescCorta.TabIndex = 5;
            this.lblDescCorta.Text = "Descripción Corta:";
            // 
            // lblProducto
            // 
            this.lblProducto.AutoSize = true;
            this.lblProducto.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblProducto.Location = new System.Drawing.Point(481, 28);
            this.lblProducto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProducto.Name = "lblProducto";
            this.lblProducto.Size = new System.Drawing.Size(80, 21);
            this.lblProducto.TabIndex = 5;
            this.lblProducto.Text = "Producto";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(60, 406);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(882, 3);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(851, 479);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 8;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnBaja
            // 
            this.btnBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnBaja.Image")));
            this.btnBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaja.Location = new System.Drawing.Point(657, 479);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(91, 43);
            this.btnBaja.TabIndex = 7;
            this.btnBaja.Text = "Eliminar";
            this.btnBaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(753, 479);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 43);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnUMedida
            // 
            this.btnUMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnUMedida.Image")));
            this.btnUMedida.Location = new System.Drawing.Point(852, 63);
            this.btnUMedida.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUMedida.Name = "btnUMedida";
            this.btnUMedida.Size = new System.Drawing.Size(41, 37);
            this.btnUMedida.TabIndex = 19;
            this.btnUMedida.UseVisualStyleBackColor = true;
            // 
            // btnRubro
            // 
            this.btnRubro.Image = ((System.Drawing.Image)(resources.GetObject("btnRubro.Image")));
            this.btnRubro.Location = new System.Drawing.Point(852, 27);
            this.btnRubro.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRubro.Name = "btnRubro";
            this.btnRubro.Size = new System.Drawing.Size(41, 37);
            this.btnRubro.TabIndex = 10;
            this.btnRubro.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            this.btnVolver.Image = ((System.Drawing.Image)(resources.GetObject("btnVolver.Image")));
            this.btnVolver.Location = new System.Drawing.Point(289, 22);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(41, 37);
            this.btnVolver.TabIndex = 4;
            this.btnVolver.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Image = global::SistemaFacturacionInventario.Properties.Resources.icons8_buscar_20;
            this.btnBuscar.Location = new System.Drawing.Point(241, 22);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(41, 37);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // frmProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(230)))));
            this.ClientSize = new System.Drawing.Size(975, 573);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblProducto);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmProducto";
            this.Text = "frmProducto";
            this.Load += new System.EventHandler(this.frmProducto_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDescrCorta;
        private System.Windows.Forms.TextBox txtNroProducto;
        private System.Windows.Forms.Label lblNroArticulo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblProducto;
        private System.Windows.Forms.Label lblDescCorta;
        private System.Windows.Forms.Label lblDescLarga;
        private System.Windows.Forms.TextBox tctDescLarga;
        private System.Windows.Forms.Label lblRubro;
        private System.Windows.Forms.Button btnRubro;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label lblStockActual;
        private System.Windows.Forms.TextBox txtStockActual;
        private System.Windows.Forms.CheckBox chkStock;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblUMedida;
        private System.Windows.Forms.Label lblStockMinimo;
        private System.Windows.Forms.TextBox txtStockMin;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnUMedida;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}