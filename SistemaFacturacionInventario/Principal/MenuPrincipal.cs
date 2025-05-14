using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using SistemaFacturacionInventario.Cajas;
using SistemaFacturacionInventario.Clientes;
using SistemaFacturacionInventario.Facturacion;
using SistemaFacturacionInventario.Principal;
using SistemaFacturacionInventario.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            PersonalizarDiseño();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            CajaNegocio cajaNegocio = new CajaNegocio();
            if (cajaNegocio.ExisteCajaAnteriorSinCerrar())
            {
                DialogResult result = MessageBox.Show(this, "Atención: la caja anterior no fue cerrada. ¿Desea cerrar ahora?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    var frmCerrarCaja = new frmCierreCaja();
                    frmCerrarCaja.ShowDialog();
                }
            }

            AbrirFormularioHijo(new frmIndex());
            OcultarPanelesSubMenu();
        }

        #region Paneles    
        private void PersonalizarDiseño()
        {
            pnlSubMenuClientes.Visible = false;
            pnlSubmenuFacturacion.Visible = false;
            pnlSubmenuProductos.Visible = false;
        }

        private void OcultarPanelesSubMenu()
        {
            if (pnlSubmenuFacturacion.Visible == true)
                pnlSubmenuFacturacion.Visible = false;
            if (pnlSubMenuClientes.Visible == true)
                pnlSubMenuClientes.Visible = false;
            if (pnlSubmenuProductos.Visible == true)
                pnlSubmenuProductos.Visible = false;
        }

        private void MostrarPanelSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                OcultarPanelesSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private async void btnInicio_Click(object sender, EventArgs e)
        {
            // Deshabilitar el botón para evitar múltiples clics
            btnInicio.Enabled = false;

            // Ejecutar los métodos después del retraso
            AbrirFormularioHijo(new frmIndex());
            OcultarPanelesSubMenu();

            // Esperar 2 segundos (2000 milisegundos)
            await Task.Delay(2000);

            // Volver a habilitar el botón
            btnInicio.Enabled = true;
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            this.MostrarPanelSubMenu(pnlSubmenuFacturacion);
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            this.MostrarPanelSubMenu(pnlSubmenuProductos);
        }

        private void btnGestionClientes_Click(object sender, EventArgs e)
        {
            this.MostrarPanelSubMenu(pnlSubMenuClientes);
        }

        private void btnNuevaFactura_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmFacturacion {Accion = "ALTA", IdTipoDoc = 1 });
            OcultarPanelesSubMenu();
        }

        private void btnFacturaX_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmFacturacion { Accion = "ALTA", IdTipoDoc = 8 });
            OcultarPanelesSubMenu();
        }

        private void btnListadoFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmConsultaFacturas());
            OcultarPanelesSubMenu();
        }

        private void btnListadoProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmListaProductos());
            OcultarPanelesSubMenu();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmProducto { Accion = "ALTA" });
            OcultarPanelesSubMenu();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmListaPrecio());
            OcultarPanelesSubMenu();
        }

        private void btnListadoClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmListaClientes());
            OcultarPanelesSubMenu();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmCliente{ Accion = "ALTA" });
            OcultarPanelesSubMenu();
        }

        private void btnHistorialCompra_Click(object sender, EventArgs e)
        {
            OcultarPanelesSubMenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            OcultarPanelesSubMenu();
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmConfiguracion());
            OcultarPanelesSubMenu();
        }
        #endregion

        #region
        private Form formularioActivo = null;
        private void AbrirFormularioHijo(Form formularioHijo)
        {
            if (formularioActivo != null)
                formularioActivo.Close();
            formularioActivo = formularioHijo;
            formularioHijo.TopLevel = false;
            formularioHijo.FormBorderStyle = FormBorderStyle.None;
            formularioHijo.Dock = DockStyle.Fill;   
            pnlContenedorPrincipal.Controls.Add(formularioHijo);
            pnlContenedorPrincipal.Tag = formularioHijo;
            formularioHijo.BringToFront();
            formularioHijo.Show();
        }

        #endregion

        private void btnCaja_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmCaja());
            OcultarPanelesSubMenu();
        }
    }
}
