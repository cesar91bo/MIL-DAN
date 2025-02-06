namespace SistemaFacturacionInventario
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            this.pnlLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlMenuLateral = new System.Windows.Forms.Panel();
            this.btnReportes = new System.Windows.Forms.Button();
            this.pnlSubMenuClientes = new System.Windows.Forms.Panel();
            this.btnHistorialCompra = new System.Windows.Forms.Button();
            this.btnNuevoCliente = new System.Windows.Forms.Button();
            this.btnListadoClientes = new System.Windows.Forms.Button();
            this.btnGestionClientes = new System.Windows.Forms.Button();
            this.pnlSubmenuProductos = new System.Windows.Forms.Panel();
            this.btnInventario = new System.Windows.Forms.Button();
            this.btnNuevoProducto = new System.Windows.Forms.Button();
            this.btnListadoProductos = new System.Windows.Forms.Button();
            this.btnProductos = new System.Windows.Forms.Button();
            this.pnlSubmenuFacturacion = new System.Windows.Forms.Panel();
            this.btnAnulacionFactura = new System.Windows.Forms.Button();
            this.btnListadoFacturas = new System.Windows.Forms.Button();
            this.btnNuevaFactura = new System.Windows.Forms.Button();
            this.btnFacturacion = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.btnConfiguracion = new System.Windows.Forms.Button();
            this.pnlContenedorPrincipal = new System.Windows.Forms.Panel();
            this.pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlMenuLateral.SuspendLayout();
            this.pnlSubMenuClientes.SuspendLayout();
            this.pnlSubmenuProductos.SuspendLayout();
            this.pnlSubmenuFacturacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogo
            // 
            this.pnlLogo.Controls.Add(this.pictureBox1);
            this.pnlLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLogo.Location = new System.Drawing.Point(0, 0);
            this.pnlLogo.Name = "pnlLogo";
            this.pnlLogo.Size = new System.Drawing.Size(250, 147);
            this.pnlLogo.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::SistemaFacturacionInventario.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 147);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pnlMenuLateral
            // 
            this.pnlMenuLateral.AutoScroll = true;
            this.pnlMenuLateral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.pnlMenuLateral.Controls.Add(this.btnReportes);
            this.pnlMenuLateral.Controls.Add(this.pnlSubMenuClientes);
            this.pnlMenuLateral.Controls.Add(this.btnGestionClientes);
            this.pnlMenuLateral.Controls.Add(this.pnlSubmenuProductos);
            this.pnlMenuLateral.Controls.Add(this.btnProductos);
            this.pnlMenuLateral.Controls.Add(this.pnlSubmenuFacturacion);
            this.pnlMenuLateral.Controls.Add(this.btnFacturacion);
            this.pnlMenuLateral.Controls.Add(this.btnInicio);
            this.pnlMenuLateral.Controls.Add(this.btnConfiguracion);
            this.pnlMenuLateral.Controls.Add(this.pnlLogo);
            this.pnlMenuLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenuLateral.Location = new System.Drawing.Point(0, 0);
            this.pnlMenuLateral.Name = "pnlMenuLateral";
            this.pnlMenuLateral.Size = new System.Drawing.Size(250, 792);
            this.pnlMenuLateral.TabIndex = 0;
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReportes.Image = ((System.Drawing.Image)(resources.GetObject("btnReportes.Image")));
            this.btnReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnReportes.Location = new System.Drawing.Point(0, 699);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnReportes.Size = new System.Drawing.Size(250, 45);
            this.btnReportes.TabIndex = 9;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // pnlSubMenuClientes
            // 
            this.pnlSubMenuClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.pnlSubMenuClientes.Controls.Add(this.btnHistorialCompra);
            this.pnlSubMenuClientes.Controls.Add(this.btnNuevoCliente);
            this.pnlSubMenuClientes.Controls.Add(this.btnListadoClientes);
            this.pnlSubMenuClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubMenuClientes.Location = new System.Drawing.Point(0, 575);
            this.pnlSubMenuClientes.Name = "pnlSubMenuClientes";
            this.pnlSubMenuClientes.Size = new System.Drawing.Size(250, 124);
            this.pnlSubMenuClientes.TabIndex = 8;
            // 
            // btnHistorialCompra
            // 
            this.btnHistorialCompra.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHistorialCompra.FlatAppearance.BorderSize = 0;
            this.btnHistorialCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistorialCompra.ForeColor = System.Drawing.Color.LightGray;
            this.btnHistorialCompra.Location = new System.Drawing.Point(0, 80);
            this.btnHistorialCompra.Name = "btnHistorialCompra";
            this.btnHistorialCompra.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnHistorialCompra.Size = new System.Drawing.Size(250, 40);
            this.btnHistorialCompra.TabIndex = 2;
            this.btnHistorialCompra.Text = "Historial de Compras";
            this.btnHistorialCompra.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHistorialCompra.UseVisualStyleBackColor = true;
            this.btnHistorialCompra.Click += new System.EventHandler(this.btnHistorialCompra_Click);
            // 
            // btnNuevoCliente
            // 
            this.btnNuevoCliente.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevoCliente.FlatAppearance.BorderSize = 0;
            this.btnNuevoCliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoCliente.ForeColor = System.Drawing.Color.LightGray;
            this.btnNuevoCliente.Location = new System.Drawing.Point(0, 40);
            this.btnNuevoCliente.Name = "btnNuevoCliente";
            this.btnNuevoCliente.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNuevoCliente.Size = new System.Drawing.Size(250, 40);
            this.btnNuevoCliente.TabIndex = 1;
            this.btnNuevoCliente.Text = "Agregar Cliente";
            this.btnNuevoCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoCliente.UseVisualStyleBackColor = true;
            this.btnNuevoCliente.Click += new System.EventHandler(this.btnNuevoCliente_Click);
            // 
            // btnListadoClientes
            // 
            this.btnListadoClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListadoClientes.FlatAppearance.BorderSize = 0;
            this.btnListadoClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListadoClientes.ForeColor = System.Drawing.Color.LightGray;
            this.btnListadoClientes.Location = new System.Drawing.Point(0, 0);
            this.btnListadoClientes.Name = "btnListadoClientes";
            this.btnListadoClientes.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnListadoClientes.Size = new System.Drawing.Size(250, 40);
            this.btnListadoClientes.TabIndex = 0;
            this.btnListadoClientes.Text = "Listado de Clientes";
            this.btnListadoClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListadoClientes.UseVisualStyleBackColor = true;
            this.btnListadoClientes.Click += new System.EventHandler(this.btnListadoClientes_Click);
            // 
            // btnGestionClientes
            // 
            this.btnGestionClientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGestionClientes.FlatAppearance.BorderSize = 0;
            this.btnGestionClientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGestionClientes.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnGestionClientes.Image = ((System.Drawing.Image)(resources.GetObject("btnGestionClientes.Image")));
            this.btnGestionClientes.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGestionClientes.Location = new System.Drawing.Point(0, 530);
            this.btnGestionClientes.Name = "btnGestionClientes";
            this.btnGestionClientes.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnGestionClientes.Size = new System.Drawing.Size(250, 45);
            this.btnGestionClientes.TabIndex = 9;
            this.btnGestionClientes.Text = "Gestión de Clientes";
            this.btnGestionClientes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGestionClientes.UseVisualStyleBackColor = true;
            this.btnGestionClientes.Click += new System.EventHandler(this.btnGestionClientes_Click);
            // 
            // pnlSubmenuProductos
            // 
            this.pnlSubmenuProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.pnlSubmenuProductos.Controls.Add(this.btnInventario);
            this.pnlSubmenuProductos.Controls.Add(this.btnNuevoProducto);
            this.pnlSubmenuProductos.Controls.Add(this.btnListadoProductos);
            this.pnlSubmenuProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmenuProductos.Location = new System.Drawing.Point(0, 406);
            this.pnlSubmenuProductos.Name = "pnlSubmenuProductos";
            this.pnlSubmenuProductos.Size = new System.Drawing.Size(250, 124);
            this.pnlSubmenuProductos.TabIndex = 6;
            // 
            // btnInventario
            // 
            this.btnInventario.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInventario.FlatAppearance.BorderSize = 0;
            this.btnInventario.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInventario.ForeColor = System.Drawing.Color.LightGray;
            this.btnInventario.Location = new System.Drawing.Point(0, 80);
            this.btnInventario.Name = "btnInventario";
            this.btnInventario.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnInventario.Size = new System.Drawing.Size(250, 40);
            this.btnInventario.TabIndex = 2;
            this.btnInventario.Text = "Inventario";
            this.btnInventario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInventario.UseVisualStyleBackColor = true;
            this.btnInventario.Click += new System.EventHandler(this.btnInventario_Click);
            // 
            // btnNuevoProducto
            // 
            this.btnNuevoProducto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevoProducto.FlatAppearance.BorderSize = 0;
            this.btnNuevoProducto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoProducto.ForeColor = System.Drawing.Color.LightGray;
            this.btnNuevoProducto.Location = new System.Drawing.Point(0, 40);
            this.btnNuevoProducto.Name = "btnNuevoProducto";
            this.btnNuevoProducto.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNuevoProducto.Size = new System.Drawing.Size(250, 40);
            this.btnNuevoProducto.TabIndex = 1;
            this.btnNuevoProducto.Text = "Nuevo Producto";
            this.btnNuevoProducto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoProducto.UseVisualStyleBackColor = true;
            this.btnNuevoProducto.Click += new System.EventHandler(this.btnNuevoProducto_Click);
            // 
            // btnListadoProductos
            // 
            this.btnListadoProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListadoProductos.FlatAppearance.BorderSize = 0;
            this.btnListadoProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListadoProductos.ForeColor = System.Drawing.Color.LightGray;
            this.btnListadoProductos.Location = new System.Drawing.Point(0, 0);
            this.btnListadoProductos.Name = "btnListadoProductos";
            this.btnListadoProductos.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnListadoProductos.Size = new System.Drawing.Size(250, 40);
            this.btnListadoProductos.TabIndex = 0;
            this.btnListadoProductos.Text = "Listado de Productos";
            this.btnListadoProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListadoProductos.UseVisualStyleBackColor = true;
            this.btnListadoProductos.Click += new System.EventHandler(this.btnListadoProductos_Click);
            // 
            // btnProductos
            // 
            this.btnProductos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProductos.FlatAppearance.BorderSize = 0;
            this.btnProductos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProductos.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnProductos.Image = ((System.Drawing.Image)(resources.GetObject("btnProductos.Image")));
            this.btnProductos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProductos.Location = new System.Drawing.Point(0, 361);
            this.btnProductos.Name = "btnProductos";
            this.btnProductos.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnProductos.Size = new System.Drawing.Size(250, 45);
            this.btnProductos.TabIndex = 9;
            this.btnProductos.Text = "Productos";
            this.btnProductos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProductos.UseVisualStyleBackColor = true;
            this.btnProductos.Click += new System.EventHandler(this.btnProductos_Click);
            // 
            // pnlSubmenuFacturacion
            // 
            this.pnlSubmenuFacturacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(32)))), ((int)(((byte)(39)))));
            this.pnlSubmenuFacturacion.Controls.Add(this.btnAnulacionFactura);
            this.pnlSubmenuFacturacion.Controls.Add(this.btnListadoFacturas);
            this.pnlSubmenuFacturacion.Controls.Add(this.btnNuevaFactura);
            this.pnlSubmenuFacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlSubmenuFacturacion.Location = new System.Drawing.Point(0, 237);
            this.pnlSubmenuFacturacion.Name = "pnlSubmenuFacturacion";
            this.pnlSubmenuFacturacion.Size = new System.Drawing.Size(250, 124);
            this.pnlSubmenuFacturacion.TabIndex = 4;
            // 
            // btnAnulacionFactura
            // 
            this.btnAnulacionFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnulacionFactura.FlatAppearance.BorderSize = 0;
            this.btnAnulacionFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnulacionFactura.ForeColor = System.Drawing.Color.LightGray;
            this.btnAnulacionFactura.Location = new System.Drawing.Point(0, 80);
            this.btnAnulacionFactura.Name = "btnAnulacionFactura";
            this.btnAnulacionFactura.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnAnulacionFactura.Size = new System.Drawing.Size(250, 40);
            this.btnAnulacionFactura.TabIndex = 2;
            this.btnAnulacionFactura.Text = "Anulación de Facturas";
            this.btnAnulacionFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnulacionFactura.UseVisualStyleBackColor = true;
            this.btnAnulacionFactura.Click += new System.EventHandler(this.btnAnulacionFactura_Click);
            // 
            // btnListadoFacturas
            // 
            this.btnListadoFacturas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnListadoFacturas.FlatAppearance.BorderSize = 0;
            this.btnListadoFacturas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnListadoFacturas.ForeColor = System.Drawing.Color.LightGray;
            this.btnListadoFacturas.Location = new System.Drawing.Point(0, 40);
            this.btnListadoFacturas.Name = "btnListadoFacturas";
            this.btnListadoFacturas.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnListadoFacturas.Size = new System.Drawing.Size(250, 40);
            this.btnListadoFacturas.TabIndex = 1;
            this.btnListadoFacturas.Text = "Listado de Facturas";
            this.btnListadoFacturas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnListadoFacturas.UseVisualStyleBackColor = true;
            this.btnListadoFacturas.Click += new System.EventHandler(this.btnListadoFacturas_Click);
            // 
            // btnNuevaFactura
            // 
            this.btnNuevaFactura.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevaFactura.FlatAppearance.BorderSize = 0;
            this.btnNuevaFactura.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevaFactura.ForeColor = System.Drawing.Color.LightGray;
            this.btnNuevaFactura.Location = new System.Drawing.Point(0, 0);
            this.btnNuevaFactura.Name = "btnNuevaFactura";
            this.btnNuevaFactura.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnNuevaFactura.Size = new System.Drawing.Size(250, 40);
            this.btnNuevaFactura.TabIndex = 0;
            this.btnNuevaFactura.Text = "Nueva factura";
            this.btnNuevaFactura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevaFactura.UseVisualStyleBackColor = true;
            this.btnNuevaFactura.Click += new System.EventHandler(this.btnNuevaFactura_Click_1);
            // 
            // btnFacturacion
            // 
            this.btnFacturacion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFacturacion.FlatAppearance.BorderSize = 0;
            this.btnFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFacturacion.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnFacturacion.Image = ((System.Drawing.Image)(resources.GetObject("btnFacturacion.Image")));
            this.btnFacturacion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFacturacion.Location = new System.Drawing.Point(0, 192);
            this.btnFacturacion.Name = "btnFacturacion";
            this.btnFacturacion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnFacturacion.Size = new System.Drawing.Size(250, 45);
            this.btnFacturacion.TabIndex = 9;
            this.btnFacturacion.Text = "Facturación";
            this.btnFacturacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFacturacion.UseVisualStyleBackColor = true;
            this.btnFacturacion.Click += new System.EventHandler(this.btnFacturacion_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.FlatAppearance.BorderSize = 0;
            this.btnInicio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInicio.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnInicio.Image = ((System.Drawing.Image)(resources.GetObject("btnInicio.Image")));
            this.btnInicio.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnInicio.Location = new System.Drawing.Point(0, 147);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnInicio.Size = new System.Drawing.Size(250, 45);
            this.btnInicio.TabIndex = 10;
            this.btnInicio.Text = "Inicio";
            this.btnInicio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnConfiguracion.FlatAppearance.BorderSize = 0;
            this.btnConfiguracion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfiguracion.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnConfiguracion.Image = ((System.Drawing.Image)(resources.GetObject("btnConfiguracion.Image")));
            this.btnConfiguracion.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 747);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.btnConfiguracion.Size = new System.Drawing.Size(250, 45);
            this.btnConfiguracion.TabIndex = 9;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfiguracion.UseVisualStyleBackColor = true;
            this.btnConfiguracion.Click += new System.EventHandler(this.btnConfiguracion_Click);
            // 
            // pnlContenedorPrincipal
            // 
            this.pnlContenedorPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(21)))), ((int)(((byte)(32)))));
            this.pnlContenedorPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenedorPrincipal.Location = new System.Drawing.Point(250, 0);
            this.pnlContenedorPrincipal.Name = "pnlContenedorPrincipal";
            this.pnlContenedorPrincipal.Size = new System.Drawing.Size(1153, 792);
            this.pnlContenedorPrincipal.TabIndex = 1;
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1403, 792);
            this.Controls.Add(this.pnlContenedorPrincipal);
            this.Controls.Add(this.pnlMenuLateral);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(1419, 742);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load);
            this.pnlLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlMenuLateral.ResumeLayout(false);
            this.pnlSubMenuClientes.ResumeLayout(false);
            this.pnlSubmenuProductos.ResumeLayout(false);
            this.pnlSubmenuFacturacion.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlLogo;
        private System.Windows.Forms.Panel pnlMenuLateral;
        private System.Windows.Forms.Button btnConfiguracion;
        private System.Windows.Forms.Panel pnlContenedorPrincipal;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Panel pnlSubMenuClientes;
        private System.Windows.Forms.Button btnHistorialCompra;
        private System.Windows.Forms.Button btnNuevoCliente;
        private System.Windows.Forms.Button btnListadoClientes;
        private System.Windows.Forms.Button btnGestionClientes;
        private System.Windows.Forms.Panel pnlSubmenuProductos;
        private System.Windows.Forms.Button btnInventario;
        private System.Windows.Forms.Button btnNuevoProducto;
        private System.Windows.Forms.Button btnListadoProductos;
        private System.Windows.Forms.Button btnProductos;
        private System.Windows.Forms.Panel pnlSubmenuFacturacion;
        private System.Windows.Forms.Button btnAnulacionFactura;
        private System.Windows.Forms.Button btnListadoFacturas;
        private System.Windows.Forms.Button btnNuevaFactura;
        private System.Windows.Forms.Button btnFacturacion;
    }
}

