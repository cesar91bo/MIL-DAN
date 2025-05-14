namespace SistemaFacturacionInventario.Cajas
{
    partial class frmCaja
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCaja));
            this.btnIngleso = new System.Windows.Forms.Button();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnCerrarCaja = new System.Windows.Forms.Button();
            this.btnEgreso = new System.Windows.Forms.Button();
            this.btnAbrirCaja = new System.Windows.Forms.Button();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.checkHabilitar = new System.Windows.Forms.CheckBox();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.listCaja = new System.Windows.Forms.ListView();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnIngleso
            // 
            this.btnIngleso.Location = new System.Drawing.Point(372, 482);
            this.btnIngleso.Margin = new System.Windows.Forms.Padding(4);
            this.btnIngleso.Name = "btnIngleso";
            this.btnIngleso.Size = new System.Drawing.Size(100, 35);
            this.btnIngleso.TabIndex = 76;
            this.btnIngleso.Text = "Ingreso";
            this.btnIngleso.UseVisualStyleBackColor = true;
            this.btnIngleso.Click += new System.EventHandler(this.btnIngleso_Click);
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Location = new System.Drawing.Point(821, 39);
            this.btnExportarPDF.Margin = new System.Windows.Forms.Padding(4);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(100, 27);
            this.btnExportarPDF.TabIndex = 75;
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnCerrarCaja
            // 
            this.btnCerrarCaja.Location = new System.Drawing.Point(613, 482);
            this.btnCerrarCaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnCerrarCaja.Name = "btnCerrarCaja";
            this.btnCerrarCaja.Size = new System.Drawing.Size(100, 35);
            this.btnCerrarCaja.TabIndex = 74;
            this.btnCerrarCaja.Text = "Cerrar Caja";
            this.btnCerrarCaja.UseVisualStyleBackColor = true;
            this.btnCerrarCaja.Click += new System.EventHandler(this.btnCerrarCaja_Click);
            // 
            // btnEgreso
            // 
            this.btnEgreso.Location = new System.Drawing.Point(494, 482);
            this.btnEgreso.Margin = new System.Windows.Forms.Padding(4);
            this.btnEgreso.Name = "btnEgreso";
            this.btnEgreso.Size = new System.Drawing.Size(100, 35);
            this.btnEgreso.TabIndex = 73;
            this.btnEgreso.Text = "Egresos";
            this.btnEgreso.UseVisualStyleBackColor = true;
            this.btnEgreso.Click += new System.EventHandler(this.btnEgreso_Click);
            // 
            // btnAbrirCaja
            // 
            this.btnAbrirCaja.Location = new System.Drawing.Point(252, 482);
            this.btnAbrirCaja.Margin = new System.Windows.Forms.Padding(4);
            this.btnAbrirCaja.Name = "btnAbrirCaja";
            this.btnAbrirCaja.Size = new System.Drawing.Size(100, 35);
            this.btnAbrirCaja.TabIndex = 72;
            this.btnAbrirCaja.Text = "Abrir Caja";
            this.btnAbrirCaja.UseVisualStyleBackColor = true;
            this.btnAbrirCaja.Click += new System.EventHandler(this.btnAbrirCaja_Click);
            // 
            // dtpHasta
            // 
            this.dtpHasta.Enabled = false;
            this.dtpHasta.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(471, 43);
            this.dtpHasta.Margin = new System.Windows.Forms.Padding(4);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(139, 23);
            this.dtpHasta.TabIndex = 71;
            this.dtpHasta.ValueChanged += new System.EventHandler(this.dtpHasta_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(396, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Hasta:";
            // 
            // checkHabilitar
            // 
            this.checkHabilitar.AutoSize = true;
            this.checkHabilitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkHabilitar.Location = new System.Drawing.Point(57, 45);
            this.checkHabilitar.Margin = new System.Windows.Forms.Padding(4);
            this.checkHabilitar.Name = "checkHabilitar";
            this.checkHabilitar.Size = new System.Drawing.Size(63, 21);
            this.checkHabilitar.TabIndex = 69;
            this.checkHabilitar.Text = "Filtrar";
            this.checkHabilitar.UseVisualStyleBackColor = true;
            this.checkHabilitar.CheckedChanged += new System.EventHandler(this.checkHabilitar_CheckedChanged);
            // 
            // dtpDesde
            // 
            this.dtpDesde.Enabled = false;
            this.dtpDesde.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(233, 43);
            this.dtpDesde.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(139, 23);
            this.dtpDesde.TabIndex = 67;
            this.dtpDesde.ValueChanged += new System.EventHandler(this.dtpDesde_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(153, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 17);
            this.label1.TabIndex = 66;
            this.label1.Text = "Desde:";
            // 
            // listCaja
            // 
            this.listCaja.FullRowSelect = true;
            this.listCaja.GridLines = true;
            this.listCaja.HideSelection = false;
            this.listCaja.Location = new System.Drawing.Point(57, 87);
            this.listCaja.Margin = new System.Windows.Forms.Padding(4);
            this.listCaja.MultiSelect = false;
            this.listCaja.Name = "listCaja";
            this.listCaja.Size = new System.Drawing.Size(864, 366);
            this.listCaja.TabIndex = 65;
            this.listCaja.UseCompatibleStateImageBehavior = false;
            this.listCaja.View = System.Windows.Forms.View.Details;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Enabled = false;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(644, 39);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(86, 27);
            this.btnBuscar.TabIndex = 68;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(952, 586);
            this.Controls.Add(this.btnIngleso);
            this.Controls.Add(this.btnExportarPDF);
            this.Controls.Add(this.btnCerrarCaja);
            this.Controls.Add(this.btnEgreso);
            this.Controls.Add(this.btnAbrirCaja);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkHabilitar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listCaja);
            this.Name = "frmCaja";
            this.Text = "frmCaja";
            this.Load += new System.EventHandler(this.frmCaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIngleso;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnCerrarCaja;
        private System.Windows.Forms.Button btnEgreso;
        private System.Windows.Forms.Button btnAbrirCaja;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox checkHabilitar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listCaja;
    }
}