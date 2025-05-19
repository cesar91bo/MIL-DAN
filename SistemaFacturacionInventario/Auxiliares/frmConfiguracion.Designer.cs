namespace SistemaFacturacionInventario.Auxiliares
{
    partial class frmConfiguracion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguracion));
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.lblNombreFantasia = new System.Windows.Forms.Label();
            this.txtNombreFantasia = new System.Windows.Forms.TextBox();
            this.lblInicioAct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCUIT = new System.Windows.Forms.TextBox();
            this.dtpIncioAct = new System.Windows.Forms.DateTimePicker();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblRazonSocial = new System.Windows.Forms.Label();
            this.txtGncia = new System.Windows.Forms.TextBox();
            this.lblGcia = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblDiasVto = new System.Windows.Forms.Label();
            this.txtDiasVto = new System.Windows.Forms.TextBox();
            this.txtNroTolerancia = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(158, 23);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(4);
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(310, 22);
            this.txtRazonSocial.TabIndex = 6;
            // 
            // lblNombreFantasia
            // 
            this.lblNombreFantasia.AutoSize = true;
            this.lblNombreFantasia.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNombreFantasia.Location = new System.Drawing.Point(22, 62);
            this.lblNombreFantasia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreFantasia.Name = "lblNombreFantasia";
            this.lblNombreFantasia.Size = new System.Drawing.Size(113, 13);
            this.lblNombreFantasia.TabIndex = 9;
            this.lblNombreFantasia.Text = "Nombre de Fantasía:";
            // 
            // txtNombreFantasia
            // 
            this.txtNombreFantasia.Location = new System.Drawing.Point(158, 62);
            this.txtNombreFantasia.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreFantasia.Name = "txtNombreFantasia";
            this.txtNombreFantasia.Size = new System.Drawing.Size(310, 22);
            this.txtNombreFantasia.TabIndex = 8;
            // 
            // lblInicioAct
            // 
            this.lblInicioAct.AutoSize = true;
            this.lblInicioAct.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblInicioAct.Location = new System.Drawing.Point(535, 26);
            this.lblInicioAct.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInicioAct.Name = "lblInicioAct";
            this.lblInicioAct.Size = new System.Drawing.Size(112, 13);
            this.lblInicioAct.TabIndex = 10;
            this.lblInicioAct.Text = "Incio de Actividades:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(614, 65);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "CUIT:";
            // 
            // txtCUIT
            // 
            this.txtCUIT.Location = new System.Drawing.Point(655, 59);
            this.txtCUIT.Margin = new System.Windows.Forms.Padding(4);
            this.txtCUIT.Name = "txtCUIT";
            this.txtCUIT.Size = new System.Drawing.Size(170, 22);
            this.txtCUIT.TabIndex = 12;
            this.txtCUIT.TextChanged += new System.EventHandler(this.txtCUIT_TextChanged);
            this.txtCUIT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCUIT_KeyPress);
            // 
            // dtpIncioAct
            // 
            this.dtpIncioAct.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIncioAct.Location = new System.Drawing.Point(655, 23);
            this.dtpIncioAct.Name = "dtpIncioAct";
            this.dtpIncioAct.Size = new System.Drawing.Size(80, 22);
            this.dtpIncioAct.TabIndex = 13;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDireccion.Location = new System.Drawing.Point(77, 101);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 13);
            this.lblDireccion.TabIndex = 14;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(158, 98);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(310, 22);
            this.txtDireccion.TabIndex = 15;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTelefono.Location = new System.Drawing.Point(593, 101);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(54, 13);
            this.lblTelefono.TabIndex = 16;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(655, 98);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(170, 22);
            this.txtTelefono.TabIndex = 17;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtTelefono);
            this.groupBox1.Controls.Add(this.lblTelefono);
            this.groupBox1.Controls.Add(this.txtDireccion);
            this.groupBox1.Controls.Add(this.lblDireccion);
            this.groupBox1.Controls.Add(this.dtpIncioAct);
            this.groupBox1.Controls.Add(this.txtCUIT);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblInicioAct);
            this.groupBox1.Controls.Add(this.lblNombreFantasia);
            this.groupBox1.Controls.Add(this.txtNombreFantasia);
            this.groupBox1.Controls.Add(this.lblRazonSocial);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Location = new System.Drawing.Point(95, 88);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(927, 158);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Empresa";
            // 
            // lblRazonSocial
            // 
            this.lblRazonSocial.AutoSize = true;
            this.lblRazonSocial.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRazonSocial.Location = new System.Drawing.Point(61, 26);
            this.lblRazonSocial.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRazonSocial.Name = "lblRazonSocial";
            this.lblRazonSocial.Size = new System.Drawing.Size(74, 13);
            this.lblRazonSocial.TabIndex = 7;
            this.lblRazonSocial.Text = "Razón social:";
            // 
            // txtGncia
            // 
            this.txtGncia.Location = new System.Drawing.Point(253, 269);
            this.txtGncia.Margin = new System.Windows.Forms.Padding(4);
            this.txtGncia.Name = "txtGncia";
            this.txtGncia.Size = new System.Drawing.Size(57, 22);
            this.txtGncia.TabIndex = 20;
            this.txtGncia.Text = "0";
            this.txtGncia.TextChanged += new System.EventHandler(this.txtGncia_TextChanged);
            this.txtGncia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtGncia_KeyPress);
            // 
            // lblGcia
            // 
            this.lblGcia.AutoSize = true;
            this.lblGcia.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblGcia.Location = new System.Drawing.Point(101, 272);
            this.lblGcia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblGcia.Name = "lblGcia";
            this.lblGcia.Size = new System.Drawing.Size(129, 13);
            this.lblGcia.TabIndex = 19;
            this.lblGcia.Text = "Margen de Ganancia %:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(927, 502);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 22;
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
            this.btnGuardar.Location = new System.Drawing.Point(829, 502);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 43);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(498, 26);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(119, 21);
            this.lblTitulo.TabIndex = 23;
            this.lblTitulo.Text = "Configuración";
            // 
            // lblDiasVto
            // 
            this.lblDiasVto.AutoSize = true;
            this.lblDiasVto.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDiasVto.Location = new System.Drawing.Point(117, 313);
            this.lblDiasVto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDiasVto.Name = "lblDiasVto";
            this.lblDiasVto.Size = new System.Drawing.Size(113, 13);
            this.lblDiasVto.TabIndex = 24;
            this.lblDiasVto.Text = "Días de Vto. Factura:";
            // 
            // txtDiasVto
            // 
            this.txtDiasVto.Location = new System.Drawing.Point(253, 309);
            this.txtDiasVto.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiasVto.Name = "txtDiasVto";
            this.txtDiasVto.Size = new System.Drawing.Size(57, 22);
            this.txtDiasVto.TabIndex = 25;
            this.txtDiasVto.Text = "0";
            // 
            // txtNroTolerancia
            // 
            this.txtNroTolerancia.Location = new System.Drawing.Point(505, 269);
            this.txtNroTolerancia.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroTolerancia.Name = "txtNroTolerancia";
            this.txtNroTolerancia.Size = new System.Drawing.Size(57, 22);
            this.txtNroTolerancia.TabIndex = 27;
            this.txtNroTolerancia.Text = "0";
            this.txtNroTolerancia.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNroTolerancia_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label2.Location = new System.Drawing.Point(353, 272);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tolerancia de Difrencia:";
            // 
            // frmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1025, 549);
            this.Controls.Add(this.txtNroTolerancia);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDiasVto);
            this.Controls.Add(this.lblDiasVto);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtGncia);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblGcia);
            this.Name = "frmConfiguracion";
            this.Text = "Configuracion";
            this.Load += new System.EventHandler(this.frmConfiguracion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label lblNombreFantasia;
        private System.Windows.Forms.TextBox txtNombreFantasia;
        private System.Windows.Forms.Label lblInicioAct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCUIT;
        private System.Windows.Forms.DateTimePicker dtpIncioAct;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblRazonSocial;
        private System.Windows.Forms.TextBox txtGncia;
        private System.Windows.Forms.Label lblGcia;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblDiasVto;
        private System.Windows.Forms.TextBox txtDiasVto;
        private System.Windows.Forms.TextBox txtNroTolerancia;
        private System.Windows.Forms.Label label2;
    }
}