namespace SistemaFacturacionInventario.Productos
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
            this.listViewProductos = new System.Windows.Forms.ListView();
            this.lblListaProductos = new System.Windows.Forms.Label();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.menuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.menuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProductos
            // 
            this.listViewProductos.FullRowSelect = true;
            this.listViewProductos.GridLines = true;
            this.listViewProductos.Location = new System.Drawing.Point(38, 88);
            this.listViewProductos.MultiSelect = false;
            this.listViewProductos.Name = "listViewProductos";
            this.listViewProductos.Size = new System.Drawing.Size(946, 348);
            this.listViewProductos.TabIndex = 0;
            this.listViewProductos.UseCompatibleStateImageBehavior = false;
            this.listViewProductos.View = System.Windows.Forms.View.Details;
            this.listViewProductos.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewProductos_ColumnClick);
            this.listViewProductos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewProductos_KeyDown);
            this.listViewProductos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewProductos_MouseClick);
            this.listViewProductos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewProductos_MouseDoubleClick);
            // 
            // lblListaProductos
            // 
            this.lblListaProductos.AutoSize = true;
            this.lblListaProductos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblListaProductos.Location = new System.Drawing.Point(405, 21);
            this.lblListaProductos.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblListaProductos.Name = "lblListaProductos";
            this.lblListaProductos.Size = new System.Drawing.Size(149, 21);
            this.lblListaProductos.TabIndex = 6;
            this.lblListaProductos.Text = "Lista de Productos";
            // 
            // lblFiltrar
            // 
            this.lblFiltrar.AutoSize = true;
            this.lblFiltrar.Enabled = false;
            this.lblFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblFiltrar.Location = new System.Drawing.Point(93, 62);
            this.lblFiltrar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFiltrar.Name = "lblFiltrar";
            this.lblFiltrar.Size = new System.Drawing.Size(60, 13);
            this.lblFiltrar.TabIndex = 7;
            this.lblFiltrar.Text = "Filtrar Por:";
            // 
            // cmbFiltro
            // 
            this.cmbFiltro.FormattingEnabled = true;
            this.cmbFiltro.Location = new System.Drawing.Point(161, 58);
            this.cmbFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.cmbFiltro.Name = "cmbFiltro";
            this.cmbFiltro.Size = new System.Drawing.Size(409, 23);
            this.cmbFiltro.TabIndex = 8;
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
            // btnEditar
            // 
            this.btnEditar.Enabled = false;
            this.btnEditar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnEditar.Image")));
            this.btnEditar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditar.Location = new System.Drawing.Point(357, 463);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(96, 43);
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
            this.btnEliminar.Location = new System.Drawing.Point(559, 463);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(91, 43);
            this.btnEliminar.TabIndex = 13;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Enabled = false;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(461, 463);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(90, 43);
            this.btnGuardar.TabIndex = 12;
            this.btnGuardar.Text = "Precio";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGuardar.UseVisualStyleBackColor = true;
            // 
            // frmListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(237)))), ((int)(((byte)(242)))));
            this.ClientSize = new System.Drawing.Size(1011, 519);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.cmbFiltro);
            this.Controls.Add(this.lblFiltrar);
            this.Controls.Add(this.lblListaProductos);
            this.Controls.Add(this.listViewProductos);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "frmListaProductos";
            this.Text = "Lista de Productos";
            this.Load += new System.EventHandler(this.frmListaProductos_Load);
            this.menuContextual.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
    }
}