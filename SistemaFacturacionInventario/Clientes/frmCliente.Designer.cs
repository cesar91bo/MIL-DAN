namespace SistemaFacturacionInventario.Clientes
{
    partial class frmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCliente));
            this.lblCliente = new System.Windows.Forms.Label();
            this.cmbRegimen = new System.Windows.Forms.ComboBox();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.btnListado = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblNroCliente = new System.Windows.Forms.Label();
            this.txtNroCliente = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblRegimen = new System.Windows.Forms.Label();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblTipoDoc = new System.Windows.Forms.Label();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtCuit1 = new System.Windows.Forms.TextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.dtpFechaNac = new System.Windows.Forms.DateTimePicker();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtCuit2 = new System.Windows.Forms.TextBox();
            this.txtCuit0 = new System.Windows.Forms.TextBox();
            this.txtNumDoc = new System.Windows.Forms.TextBox();
            this.lblErrores = new System.Windows.Forms.Label();
            this.btnBaja = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblCliente.Location = new System.Drawing.Point(503, 24);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(64, 21);
            this.lblCliente.TabIndex = 19;
            this.lblCliente.Text = "Cliente";
            // 
            // cmbRegimen
            // 
            this.cmbRegimen.FormattingEnabled = true;
            this.cmbRegimen.Location = new System.Drawing.Point(708, 127);
            this.cmbRegimen.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRegimen.Name = "cmbRegimen";
            this.cmbRegimen.Size = new System.Drawing.Size(266, 21);
            this.cmbRegimen.TabIndex = 5;
            this.cmbRegimen.SelectedValueChanged += new System.EventHandler(this.cmbRegimen_SelectedValueChanged);
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblLocalidad.Location = new System.Drawing.Point(195, 232);
            this.lblLocalidad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(59, 13);
            this.lblLocalidad.TabIndex = 40;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(262, 228);
            this.cmbLocalidad.Margin = new System.Windows.Forms.Padding(4);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(212, 21);
            this.cmbLocalidad.TabIndex = 3;
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(262, 194);
            this.cmbProvincia.Margin = new System.Windows.Forms.Padding(4);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(212, 21);
            this.cmbProvincia.TabIndex = 2;
            this.cmbProvincia.SelectedIndexChanged += new System.EventHandler(this.cmbProvincia_SelectedIndexChanged);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNombre.Location = new System.Drawing.Point(198, 127);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 13);
            this.lblNombre.TabIndex = 30;
            this.lblNombre.Text = "Nombres:";
            // 
            // btnListado
            // 
            this.btnListado.Enabled = false;
            this.btnListado.Image = ((System.Drawing.Image)(resources.GetObject("btnListado.Image")));
            this.btnListado.Location = new System.Drawing.Point(394, 73);
            this.btnListado.Margin = new System.Windows.Forms.Padding(4);
            this.btnListado.Name = "btnListado";
            this.btnListado.Size = new System.Drawing.Size(35, 35);
            this.btnListado.TabIndex = 32;
            this.btnListado.UseVisualStyleBackColor = true;
            this.btnListado.Click += new System.EventHandler(this.btnListado_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Image = global::SistemaFacturacionInventario.Properties.Resources.icons8_buscar_20;
            this.btnBuscar.Location = new System.Drawing.Point(351, 73);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(35, 35);
            this.btnBuscar.TabIndex = 31;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.btnBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.btnBuscar_KeyPress);
            // 
            // lblNroCliente
            // 
            this.lblNroCliente.AutoSize = true;
            this.lblNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblNroCliente.Location = new System.Drawing.Point(183, 87);
            this.lblNroCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNroCliente.Name = "lblNroCliente";
            this.lblNroCliente.Size = new System.Drawing.Size(71, 13);
            this.lblNroCliente.TabIndex = 28;
            this.lblNroCliente.Text = "Nro. Cliente:";
            // 
            // txtNroCliente
            // 
            this.txtNroCliente.Enabled = false;
            this.txtNroCliente.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.txtNroCliente.Location = new System.Drawing.Point(262, 81);
            this.txtNroCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtNroCliente.MaxLength = 6;
            this.txtNroCliente.Name = "txtNroCliente";
            this.txtNroCliente.Size = new System.Drawing.Size(82, 22);
            this.txtNroCliente.TabIndex = 27;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(262, 124);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(310, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // lblRegimen
            // 
            this.lblRegimen.AutoSize = true;
            this.lblRegimen.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblRegimen.Location = new System.Drawing.Point(588, 132);
            this.lblRegimen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegimen.Name = "lblRegimen";
            this.lblRegimen.Size = new System.Drawing.Size(111, 13);
            this.lblRegimen.TabIndex = 41;
            this.lblRegimen.Text = "Régimen Impositivo:";
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblProvincia.Location = new System.Drawing.Point(198, 197);
            this.lblProvincia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(56, 13);
            this.lblProvincia.TabIndex = 38;
            this.lblProvincia.Text = "Provincia:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblDireccion.Location = new System.Drawing.Point(196, 265);
            this.lblDireccion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 13);
            this.lblDireccion.TabIndex = 37;
            this.lblDireccion.Text = "Dirección:";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(262, 262);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(310, 22);
            this.txtDireccion.TabIndex = 4;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblApellido.Location = new System.Drawing.Point(196, 161);
            this.lblApellido.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(58, 13);
            this.lblApellido.TabIndex = 35;
            this.lblApellido.Text = "Apellidos:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(262, 158);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(4);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(310, 22);
            this.txtApellido.TabIndex = 1;
            // 
            // lblTipoDoc
            // 
            this.lblTipoDoc.AutoSize = true;
            this.lblTipoDoc.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTipoDoc.Location = new System.Drawing.Point(581, 161);
            this.lblTipoDoc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoDoc.Name = "lblTipoDoc";
            this.lblTipoDoc.Size = new System.Drawing.Size(118, 13);
            this.lblTipoDoc.TabIndex = 43;
            this.lblTipoDoc.Text = "Tipo y N° Documento:";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(708, 159);
            this.cmbTipoDoc.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(68, 21);
            this.cmbTipoDoc.TabIndex = 6;
            this.cmbTipoDoc.SelectedValueChanged += new System.EventHandler(this.cmbTipoDoc_SelectedValueChanged);
            // 
            // txtCuit1
            // 
            this.txtCuit1.Location = new System.Drawing.Point(817, 158);
            this.txtCuit1.Margin = new System.Windows.Forms.Padding(4);
            this.txtCuit1.Name = "txtCuit1";
            this.txtCuit1.Size = new System.Drawing.Size(122, 22);
            this.txtCuit1.TabIndex = 9;
            this.txtCuit1.Visible = false;
            this.txtCuit1.TextChanged += new System.EventHandler(this.txtCuit1_TextChanged);
            this.txtCuit1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuit1_KeyPress);
            this.txtCuit1.Leave += new System.EventHandler(this.txtCuit1_Leave);
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFechaNac.Location = new System.Drawing.Point(598, 197);
            this.lblFechaNac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(101, 13);
            this.lblFechaNac.TabIndex = 46;
            this.lblFechaNac.Text = "Fecha Nacimiento:";
            // 
            // dtpFechaNac
            // 
            this.dtpFechaNac.Checked = false;
            this.dtpFechaNac.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNac.Location = new System.Drawing.Point(708, 194);
            this.dtpFechaNac.Name = "dtpFechaNac";
            this.dtpFechaNac.ShowCheckBox = true;
            this.dtpFechaNac.Size = new System.Drawing.Size(105, 22);
            this.dtpFechaNac.TabIndex = 11;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTelefono.Location = new System.Drawing.Point(645, 232);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(54, 13);
            this.lblTelefono.TabIndex = 49;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(708, 228);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(266, 22);
            this.txtTelefono.TabIndex = 12;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            this.txtTelefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelefono_KeyPress);
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblEmail.Location = new System.Drawing.Point(662, 266);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(37, 13);
            this.lblEmail.TabIndex = 51;
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(708, 262);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(266, 22);
            this.txtEmail.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtComentario);
            this.groupBox1.Location = new System.Drawing.Point(186, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 118);
            this.groupBox1.TabIndex = 52;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comentario";
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(15, 22);
            this.txtComentario.Margin = new System.Windows.Forms.Padding(4);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(765, 89);
            this.txtComentario.TabIndex = 14;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelar.Image")));
            this.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new System.Drawing.Point(784, 484);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(91, 43);
            this.btnCancelar.TabIndex = 16;
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
            this.btnGuardar.Location = new System.Drawing.Point(685, 484);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(91, 43);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtCuit2
            // 
            this.txtCuit2.Location = new System.Drawing.Point(947, 158);
            this.txtCuit2.Margin = new System.Windows.Forms.Padding(4);
            this.txtCuit2.Name = "txtCuit2";
            this.txtCuit2.Size = new System.Drawing.Size(25, 22);
            this.txtCuit2.TabIndex = 10;
            this.txtCuit2.Visible = false;
            this.txtCuit2.TextChanged += new System.EventHandler(this.txtCuit2_TextChanged);
            this.txtCuit2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCuit2_KeyPress);
            // 
            // txtCuit0
            // 
            this.txtCuit0.Location = new System.Drawing.Point(784, 158);
            this.txtCuit0.Margin = new System.Windows.Forms.Padding(4);
            this.txtCuit0.Name = "txtCuit0";
            this.txtCuit0.Size = new System.Drawing.Size(25, 22);
            this.txtCuit0.TabIndex = 8;
            this.txtCuit0.Visible = false;
            this.txtCuit0.TextChanged += new System.EventHandler(this.txtCuit0_TextChanged);
            // 
            // txtNumDoc
            // 
            this.txtNumDoc.Location = new System.Drawing.Point(784, 158);
            this.txtNumDoc.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumDoc.Name = "txtNumDoc";
            this.txtNumDoc.Size = new System.Drawing.Size(122, 22);
            this.txtNumDoc.TabIndex = 7;
            this.txtNumDoc.TextChanged += new System.EventHandler(this.txtNumDoc_TextChanged);
            this.txtNumDoc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumDoc_KeyPress);
            // 
            // lblErrores
            // 
            this.lblErrores.AutoSize = true;
            this.lblErrores.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblErrores.ForeColor = System.Drawing.Color.Red;
            this.lblErrores.Location = new System.Drawing.Point(183, 442);
            this.lblErrores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrores.Name = "lblErrores";
            this.lblErrores.Size = new System.Drawing.Size(43, 13);
            this.lblErrores.TabIndex = 60;
            this.lblErrores.Text = "errores";
            this.lblErrores.Visible = false;
            // 
            // btnBaja
            // 
            this.btnBaja.Enabled = false;
            this.btnBaja.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.Image = ((System.Drawing.Image)(resources.GetObject("btnBaja.Image")));
            this.btnBaja.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaja.Location = new System.Drawing.Point(883, 484);
            this.btnBaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(91, 43);
            this.btnBaja.TabIndex = 61;
            this.btnBaja.Text = "Eliminar";
            this.btnBaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 573);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.lblErrores);
            this.Controls.Add(this.txtNumDoc);
            this.Controls.Add(this.txtCuit0);
            this.Controls.Add(this.txtCuit2);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblTelefono);
            this.Controls.Add(this.txtTelefono);
            this.Controls.Add(this.dtpFechaNac);
            this.Controls.Add(this.lblFechaNac);
            this.Controls.Add(this.txtCuit1);
            this.Controls.Add(this.cmbTipoDoc);
            this.Controls.Add(this.lblTipoDoc);
            this.Controls.Add(this.cmbRegimen);
            this.Controls.Add(this.lblLocalidad);
            this.Controls.Add(this.cmbLocalidad);
            this.Controls.Add(this.cmbProvincia);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.btnListado);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblNroCliente);
            this.Controls.Add(this.txtNroCliente);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblRegimen);
            this.Controls.Add(this.lblProvincia);
            this.Controls.Add(this.lblDireccion);
            this.Controls.Add(this.txtDireccion);
            this.Controls.Add(this.lblApellido);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.lblCliente);
            this.Name = "frmCliente";
            this.Text = "frmCliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmCliente_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.ComboBox cmbRegimen;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Button btnListado;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblNroCliente;
        private System.Windows.Forms.TextBox txtNroCliente;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblRegimen;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblTipoDoc;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.TextBox txtCuit1;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.DateTimePicker dtpFechaNac;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtCuit2;
        private System.Windows.Forms.TextBox txtCuit0;
        private System.Windows.Forms.TextBox txtNumDoc;
        private System.Windows.Forms.Label lblErrores;
        private System.Windows.Forms.Button btnBaja;
    }
}