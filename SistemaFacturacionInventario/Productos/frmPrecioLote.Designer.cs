namespace SistemaFacturacionInventario.Productos
{
    partial class frmPrecioLote
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrecioLote));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblListaPrecios = new System.Windows.Forms.Label();
            this.listViewProductos = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorcCambio = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(740, 69);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 30);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.cmbFiltro);
            this.panel1.Controls.Add(this.lblFiltrar);
            this.panel1.Controls.Add(this.lblListaPrecios);
            this.panel1.Location = new System.Drawing.Point(184, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 100);
            this.panel1.TabIndex = 33;
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(45, 63);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(504, 22);
            this.txtFiltro.TabIndex = 22;
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(100, 36);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(251, 21);
            this.cmbFiltro.TabIndex = 8;
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Enabled = false;
            this.lblFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFiltrar.Location = new System.Drawing.Point(42, 40);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(60, 13);
            this.lblFiltrar.TabIndex = 7;
            this.lblFiltrar.Text = "Filtrar Por:";
            // 
            // lblListaPrecios
            // 
            this.lblListaPrecios.AutoSize = true;
            this.lblListaPrecios.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListaPrecios.Location = new System.Drawing.Point(309, 4);
            this.lblListaPrecios.Name = "lblListaPrecios";
            this.lblListaPrecios.Size = new System.Drawing.Size(141, 21);
            this.lblListaPrecios.TabIndex = 6;
            this.lblListaPrecios.Text = "Buscar Productos";
            // 
            // listViewProductos
            // 
            this.listViewProductos.FullRowSelect = true;
            this.listViewProductos.GridLines = true;
            this.listViewProductos.HideSelection = false;
            this.listViewProductos.Location = new System.Drawing.Point(73, 114);
            this.listViewProductos.MultiSelect = false;
            this.listViewProductos.Name = "listViewProductos";
            this.listViewProductos.Size = new System.Drawing.Size(1016, 230);
            this.listViewProductos.TabIndex = 32;
            this.listViewProductos.UseCompatibleStateImageBehavior = false;
            this.listViewProductos.View = System.Windows.Forms.View.Details;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(467, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Productos Seleccionados";
            // 
            // listView1
            // 
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(73, 397);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(1016, 230);
            this.listView1.TabIndex = 35;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.label1.Location = new System.Drawing.Point(13, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Porcentaje de Cambio:";
            // 
            // txtPorcCambio
            // 
            this.txtPorcCambio.Location = new System.Drawing.Point(141, 23);
            this.txtPorcCambio.Name = "txtPorcCambio";
            this.txtPorcCambio.Size = new System.Drawing.Size(82, 22);
            this.txtPorcCambio.TabIndex = 36;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(259, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(75, 17);
            this.radioButton1.TabIndex = 37;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Aumentar";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(359, 24);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(74, 17);
            this.radioButton2.TabIndex = 38;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Disminuir";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 703);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 39;
            this.button1.Text = "Aplicar Cambios";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.txtPorcCambio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(73, 633);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(520, 64);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificación de precios";
            // 
            // frmPrecioLote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 751);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listViewProductos);
            this.Name = "frmPrecioLote";
            this.Text = "Actualización de Precios";
            this.Load += new System.EventHandler(this.frmPrecioLote_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.Label lblListaPrecios;
        private System.Windows.Forms.ListView listViewProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorcCambio;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}