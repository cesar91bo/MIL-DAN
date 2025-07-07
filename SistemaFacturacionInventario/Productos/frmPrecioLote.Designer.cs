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
            this.label3 = new System.Windows.Forms.Label();
            this.chkFiltrar = new System.Windows.Forms.CheckBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.lblListaPrecios = new System.Windows.Forms.Label();
            this.listViewProductos = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewProdSelec = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPorcCambio = new System.Windows.Forms.TextBox();
            this.rbAumentar = new System.Windows.Forms.RadioButton();
            this.rbDisminuir = new System.Windows.Forms.RadioButton();
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
            this.btnBuscar.Location = new System.Drawing.Point(598, 56);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 30);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.chkFiltrar);
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.btnBuscar);
            this.panel1.Controls.Add(this.lblListaPrecios);
            this.panel1.Location = new System.Drawing.Point(184, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 100);
            this.panel1.TabIndex = 33;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(123, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 24;
            this.label3.Text = "Nombre:";
            // 
            // chkFiltrar
            // 
            this.chkFiltrar.AutoSize = true;
            this.chkFiltrar.Location = new System.Drawing.Point(45, 38);
            this.chkFiltrar.Name = "chkFiltrar";
            this.chkFiltrar.Size = new System.Drawing.Size(129, 17);
            this.chkFiltrar.TabIndex = 23;
            this.chkFiltrar.Text = "Filtrar Por Categoría";
            this.chkFiltrar.UseVisualStyleBackColor = true;
            this.chkFiltrar.CheckedChanged += new System.EventHandler(this.chkFiltrar_CheckedChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(199, 63);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(392, 22);
            this.txtFiltro.TabIndex = 22;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Enabled = false;
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(199, 36);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(251, 21);
            this.cmbCategoria.TabIndex = 8;
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
            this.listViewProductos.CheckBoxes = true;
            this.listViewProductos.FullRowSelect = true;
            this.listViewProductos.GridLines = true;
            this.listViewProductos.HideSelection = false;
            this.listViewProductos.Location = new System.Drawing.Point(73, 114);
            this.listViewProductos.MultiSelect = false;
            this.listViewProductos.Name = "listViewProductos";
            this.listViewProductos.Size = new System.Drawing.Size(1016, 194);
            this.listViewProductos.TabIndex = 32;
            this.listViewProductos.UseCompatibleStateImageBehavior = false;
            this.listViewProductos.View = System.Windows.Forms.View.Details;
            this.listViewProductos.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewProductos_ItemChecked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(467, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(200, 21);
            this.label2.TabIndex = 23;
            this.label2.Text = "Productos Seleccionados";
            // 
            // listViewProdSelec
            // 
            this.listViewProdSelec.CheckBoxes = true;
            this.listViewProdSelec.FullRowSelect = true;
            this.listViewProdSelec.GridLines = true;
            this.listViewProdSelec.HideSelection = false;
            this.listViewProdSelec.Location = new System.Drawing.Point(73, 338);
            this.listViewProdSelec.MultiSelect = false;
            this.listViewProdSelec.Name = "listViewProdSelec";
            this.listViewProdSelec.Size = new System.Drawing.Size(1016, 192);
            this.listViewProdSelec.TabIndex = 35;
            this.listViewProdSelec.UseCompatibleStateImageBehavior = false;
            this.listViewProdSelec.View = System.Windows.Forms.View.Details;
            this.listViewProdSelec.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.listViewProdSelec_ItemChecked);
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
            this.txtPorcCambio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPorcCambio_KeyPress);
            // 
            // rbAumentar
            // 
            this.rbAumentar.AutoSize = true;
            this.rbAumentar.Checked = true;
            this.rbAumentar.Location = new System.Drawing.Point(259, 24);
            this.rbAumentar.Name = "rbAumentar";
            this.rbAumentar.Size = new System.Drawing.Size(75, 17);
            this.rbAumentar.TabIndex = 37;
            this.rbAumentar.TabStop = true;
            this.rbAumentar.Text = "Aumentar";
            this.rbAumentar.UseVisualStyleBackColor = true;
            // 
            // rbDisminuir
            // 
            this.rbDisminuir.AutoSize = true;
            this.rbDisminuir.Location = new System.Drawing.Point(359, 24);
            this.rbDisminuir.Name = "rbDisminuir";
            this.rbDisminuir.Size = new System.Drawing.Size(74, 17);
            this.rbDisminuir.TabIndex = 38;
            this.rbDisminuir.Text = "Disminuir";
            this.rbDisminuir.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(497, 611);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 36);
            this.button1.TabIndex = 39;
            this.button1.Text = "Aplicar Cambios";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDisminuir);
            this.groupBox1.Controls.Add(this.rbAumentar);
            this.groupBox1.Controls.Add(this.txtPorcCambio);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(73, 541);
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
            this.ClientSize = new System.Drawing.Size(1134, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listViewProdSelec);
            this.Controls.Add(this.label2);
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
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label lblListaPrecios;
        private System.Windows.Forms.ListView listViewProductos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView listViewProdSelec;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPorcCambio;
        private System.Windows.Forms.RadioButton rbAumentar;
        private System.Windows.Forms.RadioButton rbDisminuir;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkFiltrar;
        private System.Windows.Forms.Label label3;
    }
}