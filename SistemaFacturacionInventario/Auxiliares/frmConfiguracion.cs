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
                txtNroTolerancia.Text = (seteos.ToleranciaDiferencia ?? 0).ToString();
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
            var auxiliaresNegocio = new AuxiliaresNegocio();

            var empresa = auxiliaresNegocio.ObtenerEmpresa();

            if (empresa == null)
            {
                // Si no existe, creamos una nueva empresa
                empresa = new Empresa();
            }

            // En ambos casos, asignamos los datos del formulario
            empresa.RazonSocial = txtRazonSocial.Text;
            empresa.NFantasia = txtNombreFantasia.Text;
            empresa.Direccion = txtDireccion.Text;
            empresa.InicioActividades = Convert.ToDateTime(dtpIncioAct.Text);
            empresa.CUIT = txtCUIT.Text;
            empresa.Telefono = txtTelefono.Text;

            // Seteos
            var seteos = new Seteos
            {
                PorcentajeGcia = Convert.ToDecimal(txtGncia.Text),
                DiasVtoFact = Convert.ToByte(txtDiasVto.Text),
                ToleranciaDiferencia = Convert.ToDecimal(txtNroTolerancia.Text)
            };

            var seteosExistente = auxiliaresNegocio.ObtenerSeteos();

            if (seteosExistente != null)
            {
                seteos.IdSeteo = seteosExistente.IdSeteo;
                auxiliaresNegocio.ActualizarSeteos(seteos);
            }
            else
            {
                if (!auxiliaresNegocio.NuevoSeteos(seteos)) return;
            }         

            bool resultado;

            if (empresa.IdEmpresa == 0)
            {
                resultado = auxiliaresNegocio.NuevaEmpresa(empresa);
            }
            else
            {
                resultado = auxiliaresNegocio.ActualizarEmpresa(empresa);
            }

            if (resultado)
            {
                MessageBox.Show("Los datos se almacenaron correctamente", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Error al guardar los datos", "Configuración", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void txtNroTolerancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir control keys (ej: Backspace)
            if (char.IsControl(e.KeyChar))
            {
                return;
            }

            // Permitir solo números
            if (char.IsDigit(e.KeyChar))
            {
                return;
            }

            // Permitir solo un separador decimal (coma o punto)
            if ((e.KeyChar == '.') &&
                !textBox.Text.Contains("."))
            {
                return;
            }

            // Cualquier otra tecla se bloquea
            e.Handled = true;
        }
    }
}
