using CapaDatos.Modelos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Productos
{
    public partial class frmPrecios : FormBase
    {
        public int IdProducto;
        private bool cargaDatos = true;
        private decimal precioBase, bonif1, precioBruto, ganancia, iva, precioContado, flete;
        public bool DeAfuera;
        private Form activeForm;

        private void cmbIVA_SelectedValueChanged(object sender, EventArgs e)
        {
            Calculos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones())
                {
                    MessageBox.Show("Verifique los datos ingresados y vuelva a intentarlo", "Carga de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                var pv = new PreciosVenta
                {
                    IdProducto = IdProducto,
                    UsrAcceso = "",
                    FechaAcceso = DateTime.Now,
                    FechaPrecios = DateTime.Now,
                    PrecioBase = Convert.ToDecimal(txtPrecioBase.Text),
                    Bonificacion1 = txtBonif.Text != "" && Convert.ToDecimal(txtBonif.Text) != 0 ? Convert.ToDecimal(txtBonif.Text) : (decimal?)null,
                    PorcentajeGcia = Convert.ToDecimal(txtGanancia.Text),
                    PorcentajeFlete = Convert.ToDecimal(txtFlete.Text),
                    Iva = Convert.ToDecimal(cmbIVA.SelectedValue?.ToString()),
                    PrecioContado = Convert.ToDecimal(txtContadoSIVA.Text.Substring(1), CultureInfo.InvariantCulture),
                    PrecioContadoIva = Convert.ToDecimal(txtContadoConIVA.Text.Substring(1), CultureInfo.InvariantCulture)
                };
                var productoNegocio = new ProductoNegocio();
                if (!productoNegocio.NuevoPrecioVenta(pv)) return;
                MessageBox.Show("Los precios se cargaron correctamente", "Carga de Precios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                if (DeAfuera)
                {
                    Close();
                }
                lblFechaPrecio.Text = DateTime.Now.ToString();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        public frmPrecios(int idProducto = 0)
        {
            IdProducto = idProducto;
            InitializeComponent();
        }

        private void txtBonif_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir solo números, tecla de retroceso y el punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Evitar más de un punto decimal o coma
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtBonif.Text.Contains(".") || txtBonif.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void txtBonif_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtBonif.Text, out decimal value))
            {
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Ingrese un porcentaje entre 0 y 100.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBonif.Text = "0";
                }
            }
        }

        private void txtGanancia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            // Evitar más de un punto decimal o coma
            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtGanancia.Text.Contains(".") || txtGanancia.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void txtGanancia_TextChanged(object sender, EventArgs e)
        {

            if (decimal.TryParse(txtGanancia.Text, out decimal value))
            {
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Ingrese un porcentaje entre 0 y 100.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtGanancia.Text = "0";
                }
            }
        }

        private void txtFlete_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',')
            {
                e.Handled = true;
            }

            if ((e.KeyChar == '.' || e.KeyChar == ',') && (txtFlete.Text.Contains(".") || txtFlete.Text.Contains(",")))
            {
                e.Handled = true;
            }
        }

        private void txtFlete_TextChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(txtFlete.Text, out decimal value))
            {
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("Ingrese un porcentaje entre 0 y 100.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtFlete.Text = "0";
                }
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            //var frm = new frmListaPrecio();
            //frm.ShowDialog();
            //if (frm.DialogResult != DialogResult.OK || frm.IdProducto <= 0) return;
            //BuscarProducto(frm.IdProducto);
            OpenChildForm(new frmListaPrecio(), sender);
        }

        public void OpenChildForm(Form childForm, object btnSender)
        {
            MenuPrincipal principal = Application.OpenForms["MenuPrincipal"] as MenuPrincipal;
            if (principal != null)
            {
                this.Close();

                activeForm = childForm;
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                principal.pnlContenedorPrincipal.Controls.Add(childForm);
                principal.pnlContenedorPrincipal.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNroProducto.Text != "") BuscarProducto(Convert.ToInt32(txtNroProducto.Text));
        }

        private void txtNroProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtNroProducto.Text != "") BuscarProducto(Convert.ToInt32(txtNroProducto.Text));
        }

        private void txtNroProducto_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab && txtNroProducto.Text != "") BuscarProducto(Convert.ToInt32(txtNroProducto.Text));
        }

        private void txtNroProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',') e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtPrecioBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;

            // Permitir solo números, la tecla de retroceso y una coma/punto decimal
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            // Evitar que empiece con una coma o punto decimal
            if ((e.KeyChar == ',' || e.KeyChar == '.') && string.IsNullOrEmpty(textBox.Text))
            {
                e.Handled = true;
                return;
            }

            // Evitar múltiples comas/puntos
            if ((e.KeyChar == ',' || e.KeyChar == '.') && textBox.Text.Contains(","))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtPrecioBase_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrecioBase.Text))
            {
                txtPrecioBase.Text = "0";
            }

            precioBase = Math.Round(Convert.ToDecimal(txtPrecioBase.Text), 2);

            Calculos();
        }

        private void frmPrecios_Shown(object sender, EventArgs e)
        {
            txtPrecioBase.Focus();
        }

        private void txtGanancia_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtGanancia.Text))
            {
                txtGanancia.Text = "0";
            }
            ganancia = Math.Round(Convert.ToDecimal(txtGanancia.Text), 2);
            Calculos();
        }

        private void txtBonif_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBonif.Text))
            {
                txtBonif.Text = "0";
            }
            bonif1 = Math.Round(Convert.ToDecimal(txtBonif.Text), 2);
            Calculos();
        }

        private void txtFlete_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFlete.Text))
            {
                txtFlete.Text = "0";
            }
            flete = Math.Round(Convert.ToDecimal(txtFlete.Text), 2);
            Calculos();
        }

        private void txtPrecioBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmPrecios_Load(object sender, EventArgs e)
        {
            LlenarComboIVA();
            if (IdProducto > 0)
            {
                BuscarProducto(IdProducto);
            }
            txtPrecioBase.Focus();
            rdbConIVA.TabStop = false;
            activeForm = new frmPrecios();
        }

        private void BuscarProducto(int idProducto)
        {
            var productoNegocio = new ProductoNegocio();

            AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();
            var auxiliares = auxiliaresNegocio.ObtenerSeteo();

            CapaDatos.Modelos.Productos producto = productoNegocio.ObtenerProductoPorId(IdProducto);
            if (producto == null)
            {
                MessageBox.Show("No se encontró el Producto", "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (producto.FechaBaja != null)
            {
                MessageBox.Show("El Producto fue dado de baja", "Error de búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            IdProducto = producto.IdProducto;
            txtNroProducto.Text = IdProducto.ToString();
            lblNombreProd.Text = producto.DescCorta;
            if (!productoNegocio.ExistePrecio(IdProducto))
            {
                lblFechaPrecio.Text = "El Producto no posee precios hasta la fecha";
                txtGanancia.Text = (auxiliares.PorcentajeGcia ?? 0).ToString("0.##");
            }
            else
            {
                VistaPreciosVenta vpv = productoNegocio.ObtenerVistaUltVPV(idProducto);
                lblFechaPrecio.Text = vpv.FechaPrecio.ToString();
                precioBase = Math.Round(Convert.ToDecimal(vpv.PrecioBase), 2);
                if (vpv.Bonificacion1 != null) txtBonif.Text = vpv.Bonificacion1.ToString();
                txtGanancia.Text = vpv.PorcentajeGcia.ToString();
                txtFlete.Text = vpv.PorcentajeFlete.ToString();
                cmbIVA.SelectedValue = Convert.ToSingle(vpv.Iva);
            }

            cargaDatos = false;
            Calculos();
        }

        private void Calculos()
        {
            if (cargaDatos) return;

            bonif1 = txtBonif.Text != "" ? precioBase * Convert.ToDecimal(txtBonif.Text) / 100 : 0;
            precioBruto = precioBase - bonif1;
            CalcularVariables();
            LlenarLabels();
        }

        private void CalcularVariables()
        {
            flete = txtFlete.Text != "" ? precioBruto * (Convert.ToDecimal(txtFlete.Text) / 100) : 0;
            ganancia = txtGanancia.Text != "" ? (precioBruto + flete) * (Convert.ToDecimal(txtGanancia.Text) / 100) : 0;
            precioContado = precioBruto + flete + ganancia;
            iva = cmbIVA.Text != "" ? precioContado * (Convert.ToDecimal(cmbIVA.Text) / 100) : 0;
        }

        private void LlenarLabels()
        {
            txtPrecioBase.Text = Math.Round(precioBase, 2, MidpointRounding.AwayFromZero).ToString();
            lblBonificacionNro.Text = Math.Round(bonif1, 2, MidpointRounding.AwayFromZero).ToString();
            txtCostoFinal.Text = Math.Round(precioBruto, 2, MidpointRounding.AwayFromZero).ToString();
            lblFleteNro.Text = Math.Round(flete, 2, MidpointRounding.AwayFromZero).ToString();
            lblGananciaNro.Text = Math.Round(ganancia, 2, MidpointRounding.AwayFromZero).ToString();
            lblIVANro.Text = Math.Round(iva, 2, MidpointRounding.AwayFromZero).ToString();
            txtContadoSIVA.Text = "$" + Math.Round(precioContado, 2, MidpointRounding.AwayFromZero);
            txtContadoConIVA.Text = "$" + Math.Round(precioContado + iva, 2, MidpointRounding.AwayFromZero);
        }

        private bool Validaciones()
        {
            bool ok = true;
            if (txtPrecioBase.Text == "" || Convert.ToDecimal(txtPrecioBase.Text) == 0)
            {
                MessageBox.Show(txtPrecioBase, "Ingrese precio base");
                ok = false;
            }


            return ok;
        }

        private void LlenarComboIVA()
        {
            var rep = new AuxiliaresNegocio();
            cmbIVA.DisplayMember = "PorcentajeIVA";
            cmbIVA.ValueMember = "PorcentajeIVA";
            cmbIVA.DataSource = rep.ObtenerIVA();
        }
    }
}
