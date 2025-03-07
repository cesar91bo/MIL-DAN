using SistemaFacturacionInventario.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Facturacion
{
    public partial class frmIngPrecioManual : FormBase
    {
        public Decimal Pcio = 0;
        public frmIngPrecioManual()
        {
            InitializeComponent();
        }

        private void frmIngPrecioManual_Load(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtCB.Text != "")
                {
                    if (SiesDecimal(txtCB.Text.Replace(".", ",")))
                    {
                        Pcio = Convert.ToDecimal(txtCB.Text.Replace(".", ","));
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("Ingrese Precio correcto");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese Precio correcto");
                }
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

        private void txtCB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8)
            {
                e.Handled = false;
                return;
            }
            bool IsDec = false;
            int nroDec = 0;

            for (int i = 0; i < txtCB.Text.Length; i++)
            {
                if (txtCB.Text[i] == '.' || txtCB.Text[i] == ';')
                    IsDec = true;

                if (IsDec && nroDec++ >= 4)
                {
                    e.Handled = true;
                    return;
                }
            }
            if (e.KeyChar >= 48 && e.KeyChar <= 59)
                e.Handled = false;
            else if (e.KeyChar == 46 || e.KeyChar == 59)
                e.Handled = (IsDec) ? true : false;
            else
                e.Handled = true;
        }
    }
}
