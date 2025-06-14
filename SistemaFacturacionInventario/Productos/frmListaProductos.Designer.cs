﻿namespace SistemaFacturacionInventario.Productos
{
    partial class frmListaProductos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmListaProductos));
            this.menuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chkProdBaja = new System.Windows.Forms.CheckBox();
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPrecio = new System.Windows.Forms.Button();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.lblListaProductos = new System.Windows.Forms.Label();
            this.listViewProductos = new System.Windows.Forms.ListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnActivar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.menuContextual.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuContextual
            // 
            this.menuContextual.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modificarToolStripMenuItem,
            this.cargarPrecioToolStripMenuItem,
            this.darDeBajaToolStripMenuItem});
            this.menuContextual.Name = "menuContextual";
            this.menuContextual.Size = new System.Drawing.Size(146, 70);
            // 
            // modificarToolStripMenuItem
            // 
            this.modificarToolStripMenuItem.Name = "modificarToolStripMenuItem";
            this.modificarToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.modificarToolStripMenuItem.Text = "Modificar";
            // 
            // cargarPrecioToolStripMenuItem
            // 
            this.cargarPrecioToolStripMenuItem.Name = "cargarPrecioToolStripMenuItem";
            this.cargarPrecioToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.cargarPrecioToolStripMenuItem.Text = "Cargar Precio";
            // 
            // darDeBajaToolStripMenuItem
            // 
            this.darDeBajaToolStripMenuItem.Name = "darDeBajaToolStripMenuItem";
            this.darDeBajaToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.darDeBajaToolStripMenuItem.Text = "Dar de Baja";
            // 
            // chkProdBaja
            // 
            this.chkProdBaja.AutoSize = true;
            this.chkProdBaja.Location = new System.Drawing.Point(561, 37);
            this.chkProdBaja.Name = "chkProdBaja";
            this.chkProdBaja.Size = new System.Drawing.Size(204, 17);
            this.chkProdBaja.TabIndex = 15;
            this.chkProdBaja.Text = " Mostrar Productos Dados de  Baja";
            this.chkProdBaja.UseVisualStyleBackColor = true;
            this.chkProdBaja.CheckedChanged += new System.EventHandler(this.chkProdBaja_CheckedChanged);
            // 
            // txtFiltro
            // 
            this.txtFiltro.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFiltro.Location = new System.Drawing.Point(45, 63);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(504, 22);
            this.txtFiltro.TabIndex = 22;
            this.txtFiltro.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyDown);
            // 
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(476, 439);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(82, 37);
            this.btnEditar.TabIndex = 14;
            this.btnEditar.Text = "Editar";
            this.btnEditar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminar.Image")));
            this.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new System.Drawing.Point(649, 439);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(78, 37);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnPrecio
            // 
            this.btnPrecio.Enabled = false;
            this.btnPrecio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrecio.Image = ((System.Drawing.Image)(resources.GetObject("btnPrecio.Image")));
            this.btnPrecio.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPrecio.Location = new System.Drawing.Point(565, 439);
            this.btnPrecio.Name = "btnPrecio";
            this.btnPrecio.Size = new System.Drawing.Size(77, 37);
            this.btnPrecio.TabIndex = 12;
            this.btnPrecio.Text = "Precio";
            this.btnPrecio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPrecio.UseVisualStyleBackColor = true;
            this.btnPrecio.Click += new System.EventHandler(this.btnPrecio_Click);
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
            // lblListaProductos
            // 
            this.lblListaProductos.AutoSize = true;
            this.lblListaProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListaProductos.Location = new System.Drawing.Point(309, 4);
            this.lblListaProductos.Name = "lblListaProductos";
            this.lblListaProductos.Size = new System.Drawing.Size(149, 21);
            this.lblListaProductos.TabIndex = 6;
            this.lblListaProductos.Text = "Lista de Productos";
            // 
            // listViewProductos
            // 
            this.listViewProductos.FullRowSelect = true;
            this.listViewProductos.GridLines = true;
            this.listViewProductos.HideSelection = false;
            this.listViewProductos.Location = new System.Drawing.Point(72, 114);
            this.listViewProductos.MultiSelect = false;
            this.listViewProductos.Name = "listViewProductos";
            this.listViewProductos.Size = new System.Drawing.Size(1003, 302);
            this.listViewProductos.TabIndex = 0;
            this.listViewProductos.UseCompatibleStateImageBehavior = false;
            this.listViewProductos.View = System.Windows.Forms.View.Details;
            this.listViewProductos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProductos_ColumnClick);
            this.listViewProductos.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewProductos_ItemSelectionChanged);
            this.listViewProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProductos_KeyDown);
            this.listViewProductos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewProductos_MouseClick);
            this.listViewProductos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewProductos_MouseDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkProdBaja);
            this.panel1.Controls.Add(this.txtFiltro);
            this.panel1.Controls.Add(this.cmbFiltro);
            this.panel1.Controls.Add(this.lblFiltrar);
            this.panel1.Controls.Add(this.lblListaProductos);
            this.panel1.Location = new System.Drawing.Point(191, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(806, 100);
            this.panel1.TabIndex = 23;
            // 
            // btnActivar
            // 
            this.btnActivar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActivar.Image = ((System.Drawing.Image)(resources.GetObject("btnActivar.Image")));
            this.btnActivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnActivar.Location = new System.Drawing.Point(997, 439);
            this.btnActivar.Name = "btnActivar";
            this.btnActivar.Size = new System.Drawing.Size(78, 37);
            this.btnActivar.TabIndex = 24;
            this.btnActivar.Text = "Activar";
            this.btnActivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnActivar.UseVisualStyleBackColor = true;
            this.btnActivar.Visible = false;
            this.btnActivar.Click += new System.EventHandler(this.btnActivar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(747, 69);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(78, 30);
            this.btnBuscar.TabIndex = 25;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // frmListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowOnly;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1137, 479);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnActivar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnPrecio);
            this.Controls.Add(this.listViewProductos);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmListaProductos";
            this.Text = "Lista de Productos";
            this.Load += new System.EventHandler(this.frmListaProductos_Load);
            this.menuContextual.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewProductos;
        private System.Windows.Forms.Label lblListaProductos;
        private System.Windows.Forms.Label lblFiltrar;
        private System.Windows.Forms.ComboBox cmbFiltro;
        private System.Windows.Forms.ContextMenuStrip menuContextual;
        private System.Windows.Forms.ToolStripMenuItem modificarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarPrecioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darDeBajaToolStripMenuItem;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnPrecio;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.CheckBox chkProdBaja;
        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnActivar;
        private System.Windows.Forms.Button btnBuscar;
    }
}