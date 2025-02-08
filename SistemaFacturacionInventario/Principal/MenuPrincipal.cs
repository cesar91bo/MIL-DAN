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

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmIndex());
            OcultarPanelesSubMenu();
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
            AbrirFormularioHijo(new frmFacturacion());
            OcultarPanelesSubMenu();
        }

        private void btnListadoFacturas_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmConsultaFacturas());
            OcultarPanelesSubMenu();
        }

        private void btnAnulacionFactura_Click(object sender, EventArgs e)
        {
            OcultarPanelesSubMenu();
        }

        private void btnListadoProductos_Click(object sender, EventArgs e)
        {
            OcultarPanelesSubMenu();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            AbrirFormularioHijo(new frmProducto { Accion = "ALTA" });
            OcultarPanelesSubMenu();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            OcultarPanelesSubMenu();
        }

        private void btnListadoClientes_Click(object sender, EventArgs e)
        {
            OcultarPanelesSubMenu();
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
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
    }
}
