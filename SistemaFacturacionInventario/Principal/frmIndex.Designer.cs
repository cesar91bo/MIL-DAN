﻿namespace SistemaFacturacionInventario.Principal
{
    partial class frmIndex
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
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblHora = new System.Windows.Forms.Label();
            this.horaFecha = new System.Windows.Forms.Timer(this.components);
            this.lblTemperatura = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.pictureBoxClima = new System.Windows.Forms.PictureBox();
            this.lblDolar = new System.Windows.Forms.Label();
            this.lblCaja = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClima)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFecha
            // 
            this.lblFecha.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFecha.AutoSize = true;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.Color.SlateGray;
            this.lblFecha.Location = new System.Drawing.Point(288, 362);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(131, 46);
            this.lblFecha.TabIndex = 4;
            this.lblFecha.Text = "Fecha";
            // 
            // lblHora
            // 
            this.lblHora.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHora.AutoSize = true;
            this.lblHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 60F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHora.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblHora.Location = new System.Drawing.Point(376, 258);
            this.lblHora.Name = "lblHora";
            this.lblHora.Size = new System.Drawing.Size(212, 91);
            this.lblHora.TabIndex = 3;
            this.lblHora.Text = "Hora";
            // 
            // horaFecha
            // 
            this.horaFecha.Enabled = true;
            this.horaFecha.Tick += new System.EventHandler(this.horaFecha_Tick);
            // 
            // lblTemperatura
            // 
            this.lblTemperatura.AutoSize = true;
            this.lblTemperatura.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemperatura.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblTemperatura.Location = new System.Drawing.Point(162, 27);
            this.lblTemperatura.Name = "lblTemperatura";
            this.lblTemperatura.Size = new System.Drawing.Size(86, 17);
            this.lblTemperatura.TabIndex = 5;
            this.lblTemperatura.Text = "Temperatura";
            this.lblTemperatura.Visible = false;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDescripcion.Location = new System.Drawing.Point(162, 52);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(115, 17);
            this.lblDescripcion.TabIndex = 6;
            this.lblDescripcion.Text = "DescripcionClima";
            this.lblDescripcion.Visible = false;
            // 
            // pictureBoxClima
            // 
            this.pictureBoxClima.Location = new System.Drawing.Point(152, 76);
            this.pictureBoxClima.Name = "pictureBoxClima";
            this.pictureBoxClima.Size = new System.Drawing.Size(109, 51);
            this.pictureBoxClima.TabIndex = 7;
            this.pictureBoxClima.TabStop = false;
            this.pictureBoxClima.Visible = false;
            // 
            // lblDolar
            // 
            this.lblDolar.AutoSize = true;
            this.lblDolar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDolar.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblDolar.Location = new System.Drawing.Point(637, 27);
            this.lblDolar.Name = "lblDolar";
            this.lblDolar.Size = new System.Drawing.Size(73, 17);
            this.lblDolar.TabIndex = 8;
            this.lblDolar.Text = "Dólar hoy:";
            this.lblDolar.Visible = false;
            // 
            // lblCaja
            // 
            this.lblCaja.AutoSize = true;
            this.lblCaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblCaja.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblCaja.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCaja.Location = new System.Drawing.Point(635, 64);
            this.lblCaja.Name = "lblCaja";
            this.lblCaja.Size = new System.Drawing.Size(63, 20);
            this.lblCaja.TabIndex = 9;
            this.lblCaja.Text = "lblCaja";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 499);
            this.Controls.Add(this.lblCaja);
            this.Controls.Add(this.lblDolar);
            this.Controls.Add(this.pictureBoxClima);
            this.Controls.Add(this.lblDescripcion);
            this.Controls.Add(this.lblTemperatura);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblHora);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.Load += new System.EventHandler(this.frmIndex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClima)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.Timer horaFecha;
        private System.Windows.Forms.Label lblTemperatura;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.PictureBox pictureBoxClima;
        private System.Windows.Forms.Label lblDolar;
        private System.Windows.Forms.Label lblCaja;
    }
}