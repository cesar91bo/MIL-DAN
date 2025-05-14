namespace SistemaFacturacionInventario.Cajas
{
    partial class frmCierreCaja
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
            this.txtMontoIngresos = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.txtTotalVenta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMontoEgresado = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMontoSistema = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.dpkFecha = new System.Windows.Forms.DateTimePicker();
            this.lblFecha = new System.Windows.Forms.Label();
            this.txtMontoFinal = new System.Windows.Forms.TextBox();
            this.lblAbrir = new System.Windows.Forms.Label();
            this.error = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.error)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMontoIngresos
            // 
            this.txtMontoIngresos.Enabled = false;
            this.txtMontoIngresos.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoIngresos.Location = new System.Drawing.Point(421, 240);
            this.txtMontoIngresos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoIngresos.MaxLength = 12;
            this.txtMontoIngresos.Name = "txtMontoIngresos";
            this.txtMontoIngresos.Size = new System.Drawing.Size(175, 26);
            this.txtMontoIngresos.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(160, 243);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 19);
            this.label5.TabIndex = 33;
            this.label5.Text = "Monto Total Ingresado $:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(288, 359);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 19);
            this.label4.TabIndex = 32;
            this.label4.Text = "Observaciones";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(83, 398);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtObservaciones.MaxLength = 150;
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(519, 90);
            this.txtObservaciones.TabIndex = 31;
            // 
            // txtTotalVenta
            // 
            this.txtTotalVenta.Enabled = false;
            this.txtTotalVenta.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalVenta.Location = new System.Drawing.Point(421, 290);
            this.txtTotalVenta.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTotalVenta.MaxLength = 12;
            this.txtTotalVenta.Name = "txtTotalVenta";
            this.txtTotalVenta.Size = new System.Drawing.Size(175, 26);
            this.txtTotalVenta.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(233, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 19);
            this.label3.TabIndex = 29;
            this.label3.Text = "Total Ventas $:";
            // 
            // txtMontoEgresado
            // 
            this.txtMontoEgresado.Enabled = false;
            this.txtMontoEgresado.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoEgresado.Location = new System.Drawing.Point(421, 192);
            this.txtMontoEgresado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoEgresado.MaxLength = 12;
            this.txtMontoEgresado.Name = "txtMontoEgresado";
            this.txtMontoEgresado.Size = new System.Drawing.Size(175, 26);
            this.txtMontoEgresado.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(113, 195);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "Monto Total Egresado del Día $:";
            // 
            // txtMontoSistema
            // 
            this.txtMontoSistema.Enabled = false;
            this.txtMontoSistema.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoSistema.Location = new System.Drawing.Point(421, 146);
            this.txtMontoSistema.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoSistema.MaxLength = 12;
            this.txtMontoSistema.Name = "txtMontoSistema";
            this.txtMontoSistema.Size = new System.Drawing.Size(175, 26);
            this.txtMontoSistema.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(115, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Monto Calculado Por Sistema $:";
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarCaja.Location = new System.Drawing.Point(273, 505);
            this.btnCerrarCaja.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(179, 46);
            this.btnCerrarCaja.TabIndex = 24;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // dpkFecha
            // 
            this.dpkFecha.Enabled = false;
            this.dpkFecha.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpkFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpkFecha.Location = new System.Drawing.Point(421, 50);
            this.dpkFecha.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dpkFecha.Name = "dpkFecha";
            this.dpkFecha.Size = new System.Drawing.Size(175, 26);
            this.dpkFecha.TabIndex = 23;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.Location = new System.Drawing.Point(289, 56);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(53, 19);
            this.lblFecha.TabIndex = 22;
            this.lblFecha.Text = "Fecha:";
            // 
            // txtMontoFinal
            // 
            this.txtMontoFinal.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoFinal.Location = new System.Drawing.Point(421, 98);
            this.txtMontoFinal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMontoFinal.MaxLength = 12;
            this.txtMontoFinal.Name = "txtMontoFinal";
            this.txtMontoFinal.Size = new System.Drawing.Size(175, 26);
            this.txtMontoFinal.TabIndex = 21;
            this.txtMontoFinal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoFinal_KeyPress);
            // 
            // lblAbrir
            // 
            this.lblAbrir.AutoSize = true;
            this.lblAbrir.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAbrir.Location = new System.Drawing.Point(172, 101);
            this.lblAbrir.Name = "lblAbrir";
            this.lblAbrir.Size = new System.Drawing.Size(170, 19);
            this.lblAbrir.TabIndex = 20;
            this.lblAbrir.Text = "Monto Final Contado $:";
            // 
            // error
            // 
            this.error.ContainerControl = this;
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 586);
            this.Controls.Add(this.txtMontoIngresos);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.txtTotalVenta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtMontoEgresado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMontoSistema);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.dpkFecha);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.txtMontoFinal);
            this.Controls.Add(this.lblAbrir);
            this.Name = "frmCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cierre de Caja";
            this.Load += new System.EventHandler(this.frmCierreCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.error)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMontoIngresos;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.TextBox txtTotalVenta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMontoEgresado;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMontoSistema;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.DateTimePicker dpkFecha;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.TextBox txtMontoFinal;
        private System.Windows.Forms.Label lblAbrir;
        private System.Windows.Forms.ErrorProvider error;
    }
}