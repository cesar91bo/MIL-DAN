namespace SistemaFacturacionInventario.Facturacion
{
    partial class frmIngProdDesconocido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngProdDesconocido));
            this.lblDescCorta = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.lblUMedida = new System.Windows.Forms.Label();
            this.txtUMedida = new System.Windows.Forms.TextBox();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.chkPrecioFinal = new System.Windows.Forms.CheckBox();
            this.cmbIVA = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.Error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Error)).BeginInit();
            this.SuspendLayout();
            // 
            // lblDescCorta
            // 
            this.lblDescCorta.AutoSize = true;
            this.lblDescCorta.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDescCorta.Location = new System.Drawing.Point(77, 56);
            this.lblDescCorta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescCorta.Name = "lblDescCorta";
            this.lblDescCorta.Size = new System.Drawing.Size(120, 19);
            this.lblDescCorta.TabIndex = 7;
            this.lblDescCorta.Text = "Descripción Corta:";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(221, 53);
            this.txtDesc.Margin = new System.Windows.Forms.Padding(4);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(310, 26);
            this.txtDesc.TabIndex = 6;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblCantidad.Location = new System.Drawing.Point(130, 94);
            this.lblCantidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(67, 19);
            this.lblCantidad.TabIndex = 9;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(221, 91);
            this.txtCant.Margin = new System.Windows.Forms.Padding(4);
            this.txtCant.Name = "txtCant";
            this.txtCant.Size = new System.Drawing.Size(86, 26);
            this.txtCant.TabIndex = 8;
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCant_KeyPress);
            // 
            // lblUMedida
            // 
            this.lblUMedida.AutoSize = true;
            this.lblUMedida.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblUMedida.Location = new System.Drawing.Point(72, 136);
            this.lblUMedida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUMedida.Name = "lblUMedida";
            this.lblUMedida.Size = new System.Drawing.Size(125, 19);
            this.lblUMedida.TabIndex = 10;
            this.lblUMedida.Text = "Unidad de Medida:";
            // 
            // txtUMedida
            // 
            this.txtUMedida.Location = new System.Drawing.Point(221, 133);
            this.txtUMedida.Margin = new System.Windows.Forms.Padding(4);
            this.txtUMedida.Name = "txtUMedida";
            this.txtUMedida.Size = new System.Drawing.Size(310, 26);
            this.txtUMedida.TabIndex = 11;
            this.txtUMedida.Text = "-";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPrecio.Location = new System.Drawing.Point(148, 176);
            this.lblPrecio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(49, 19);
            this.lblPrecio.TabIndex = 13;
            this.lblPrecio.Text = "Precio:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(221, 173);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(86, 26);
            this.txtPrecio.TabIndex = 12;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // chkPrecioFinal
            // 
            this.chkPrecioFinal.AutoSize = true;
            this.chkPrecioFinal.Checked = true;
            this.chkPrecioFinal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrecioFinal.Location = new System.Drawing.Point(314, 176);
            this.chkPrecioFinal.Name = "chkPrecioFinal";
            this.chkPrecioFinal.Size = new System.Drawing.Size(100, 23);
            this.chkPrecioFinal.TabIndex = 14;
            this.chkPrecioFinal.Text = "Precio Final";
            this.chkPrecioFinal.UseVisualStyleBackColor = true;
            // 
            // cmbIVA
            // 
            this.cmbIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIVA.FormattingEnabled = true;
            this.cmbIVA.Location = new System.Drawing.Point(221, 216);
            this.cmbIVA.Name = "cmbIVA";
            this.cmbIVA.Size = new System.Drawing.Size(86, 27);
            this.cmbIVA.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 219);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "%IVA:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(447, 275);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 18;
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
            this.btnGuardar.Location = new System.Drawing.Point(349, 275);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 43);
            this.btnGuardar.TabIndex = 17;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // Error
            // 
            this.Error.ContainerControl = this;
            // 
            // frmIngProdDesconocido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 374);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbIVA);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkPrecioFinal);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtUMedida);
            this.Controls.Add(this.lblUMedida);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.lblDescCorta);
            this.Controls.Add(this.txtDesc);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmIngProdDesconocido";
            this.Text = "Ingreso Producto Desconocido";
            this.Load += new System.EventHandler(this.frmIngProdDesconocido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDescCorta;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblUMedida;
        private System.Windows.Forms.TextBox txtUMedida;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.CheckBox chkPrecioFinal;
        private System.Windows.Forms.ComboBox cmbIVA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ErrorProvider Error;
    }
}