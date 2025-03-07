using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Facturacion
{
    public partial class frmIngProdDesconocido : FormBase
    {
        public decimal Precio, Cantidad;
        public string UMedida, Descripcion;
        public Int32 IdTipoIVa;
        public bool PrecioFinal, Compra, Rem, Presupuesto;

        private void txtCant_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            var isDec = false;
            var nroDec = 0;

            for (var i = 0; i < txtCant.Text.Length; i++)
            {
                if (txtCant.Text[i] == '.' || txtCant.Text[i] == ';')
                    isDec = true;

                if (!isDec || nroDec++ < 4) continue;
                e.Handled = true;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 59) e.Handled = false;
            else if (e.KeyChar == 46 || e.KeyChar == 59) e.Handled = (isDec);
            else e.Handled = true;
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            var isDec = false;
            var nroDec = 0;

            for (var i = 0; i < txtPrecio.Text.Length; i++)
            {
                if (txtPrecio.Text[i] == '.' || txtPrecio.Text[i] == ';')
                    isDec = true;

                if (!isDec || nroDec++ < 4) continue;
                e.Handled = true;
                return;
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 59) e.Handled = false;
            else if (e.KeyChar == 46 || e.KeyChar == 59) e.Handled = (isDec);
            else e.Handled = true;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public frmIngProdDesconocido()
        {
            InitializeComponent();
        }

        private void frmIngProdDesconocido_Load(object sender, EventArgs e)
        {
            try
            {
                if (Compra) chkPrecioFinal.Visible = false;
                if (Rem)
                {
                    chkPrecioFinal.Visible = false;
                    chkPrecioFinal.Checked = false;
                }
                //Si viene de un presupuesto, no se muestra el checkbox, caso contrario sí.
                chkPrecioFinal.Visible = Presupuesto;

                var auxiliaresNegocio = new AuxiliaresNegocio();
                cmbIVA.DataSource = auxiliaresNegocio.ListTiposIva();
                cmbIVA.ValueMember = "IdTipoIva";
                cmbIVA.DisplayMember = "PorcentajeIVA";
                if (Descripcion == null) return;
                txtCant.Text = Cantidad.ToString(CultureInfo.InvariantCulture);
                txtDesc.Text = Descripcion;
                txtPrecio.Text = Precio.ToString(CultureInfo.InvariantCulture);
                txtUMedida.Text = UMedida;
                cmbIVA.SelectedValue = IdTipoIVa;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones()) return;
                Descripcion = txtDesc.Text;
                UMedida = txtUMedida.Text;
                Precio = Convert.ToDecimal(txtPrecio.Text.Replace(".", ","));
                PrecioFinal = chkPrecioFinal.Checked;
                Cantidad = Convert.ToDecimal(txtCant.Text.Replace(".", ","));
                IdTipoIVa = Convert.ToInt32(cmbIVA.SelectedValue);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private bool Validaciones()
        {
            try
            {
                bool ok = true;
                if (txtDesc.Text == "")
                {
                    Error.SetError(txtDesc, "Ingrese descripción del Artículo");
                    ok = false;
                }
                else Error.SetError(txtDesc, "");

                if (!SiesDecimal(txtCant.Text))
                {
                    Error.SetError(txtCant, "Ingrese cantidad correcta");
                    ok = false;
                }
                else Error.SetError(txtCant, "");

                if (txtUMedida.Text == "")
                {
                    Error.SetError(txtUMedida, "Ingrese U.Medida del Artículo");
                    ok = false;
                }
                else Error.SetError(txtUMedida, "");

                if (!SiesDecimal(txtPrecio.Text))
                {
                    Error.SetError(txtPrecio, "Ingrese precio correcto");
                    ok = false;
                }
                else Error.SetError(txtPrecio, "");

                return ok;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool SiesDecimal(object valor)
        {
            decimal i;
            if (decimal.TryParse(valor.ToString(), out i) == false)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
