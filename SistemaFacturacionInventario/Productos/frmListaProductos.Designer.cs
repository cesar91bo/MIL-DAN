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
            this.listViewProductos = new System.Windows.Forms.ListView();
            this.lblListaProductos = new System.Windows.Forms.Label();
            this.lblFiltrar = new System.Windows.Forms.Label();
            this.cmbFiltro = new System.Windows.Forms.ComboBox();
            this.menuContextual = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.modificarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarPrecioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darDeBajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuContextual.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewProductos
            // 
            this.listViewProductos.FullRowSelect = true;
            this.listViewProductos.GridLines = true;
            this.listViewProductos.HoverSelection = true;
            this.listViewProductos.Location = new System.Drawing.Point(38, 88);
            this.listViewProductos.MultiSelect = false;
            this.listViewProductos.Name = "listViewProductos";
            this.listViewProductos.Size = new System.Drawing.Size(859, 369);
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
            this.lblListaProductos.Location = new System.Drawing.Point(346, 25);
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
            this.cmbFiltro.Size = new System.Drawing.Size(227, 23);
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
            // frmListaProductos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 519);
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
    }
}