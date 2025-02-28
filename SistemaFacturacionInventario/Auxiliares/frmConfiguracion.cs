using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Principal;
using SistemaFacturacionInventario.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Auxiliares
{
    public partial class frmConfiguracion : FormBase
    {
        Empresa empresa = null;
        Seteos seteos = null;
        public frmConfiguracion()
        {
            InitializeComponent();
        }

        private void frmConfiguracion_Load(object sender, EventArgs e)
        {
            BuscarConfiguracion();
        }

        private void BuscarConfiguracion()
        {
            var aux = new AuxiliaresNegocio();
            seteos = aux.ObtenerSeteos();
            if (seteos != null) 
            { 
                txtGncia.Text = seteos.PorcentajeGcia.ToString();
            }

            empresa = aux.ObtenerEmpresa();

            if (empresa != null)
            {
                txtRazonSocial.Text = empresa.RazonSocial.ToString();
                txtNombreFantasia.Text = empresa.NFantasia.ToString();
                txtDireccion.Text = empresa.Direccion.ToString();
                dtpIncioAct.Text = empresa.InicioActividades.ToString();
                txtCUIT.Text = empresa.CUIT.ToString();
                txtTelefono.Text = empresa.Telefono.ToString();
            }
        }

        private void txtGncia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtGncia.Text.Contains(".") || txtGncia.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
            OpenChildForm(new frmIndex(), sender);
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            MenuPrincipal principal = Application.OpenForms["MenuPrincipal"] as MenuPrincipal;
            if (principal != null)
            {
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                principal.pnlContenedorPrincipal.Controls.Add(childForm);
                principal.pnlContenedorPrincipal.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }


        }

        private void txtGncia_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtGncia.Text, out decimal value))
            {
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Ingrese un porcentaje entre 0 y 100.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGncia.Text = "0";
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var empresa = new Empresa
            {
                RazonSocial = txtRazonSocial.Text,
                NFantasia = txtNombreFantasia.Text,
                Direccion = txtDireccion.Text,
                InicioActividades = Convert.ToDateTime(dtpIncioAct.Text),
                CUIT = txtCUIT.Text,
                Telefono = txtTelefono.Text
            };

            var seteos = new Seteos
            {
                PorcentajeGcia = Convert.ToDecimal(txtGncia.Text)
            };

            var auxiliaresNegocio = new AuxiliaresNegocio();

            if (!auxiliaresNegocio.NuevoSeteos(seteos)) return;

            if (!auxiliaresNegocio.NuevaEmpresa(empresa)) return;
            MessageBox.Show("Los datos se almacenaron correctamente", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '(' && e.KeyChar != ')' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (txtTelefono.Text.Length > 15)
            {
                txtTelefono.Text = txtTelefono.Text.Substring(0, 8);
                txtTelefono.SelectionStart = txtTelefono.Text.Length; // Mantiene el cursor al final
            }
        }

        private void txtCUIT_TextChanged(object sender, EventArgs e)
        {
            if (txtCUIT.Text.Length > 15)
            {
                txtCUIT.Text = txtCUIT.Text.Substring(0, 8);
                txtCUIT.SelectionStart = txtCUIT.Text.Length; // Mantiene el cursor al final
            }
        }

        private void txtCUIT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }
    }
}
