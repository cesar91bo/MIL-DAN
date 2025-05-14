using CapaDatos.Modelos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Cajas
{
    public partial class frmCierreCaja : Form
    {
        private CajaNegocio cajaNegocio = new CajaNegocio();
        private CapaDatos.Modelos.Cajas caja = null;
        private FacturacionNegocio facturacionNegocio = new FacturacionNegocio();
        public frmCierreCaja()
        {
            InitializeComponent();
        }


        private void BuscarCaja()
        {
            caja = cajaNegocio.ObtenerCajaActual() ?? cajaNegocio.ObtenerUltimaCaja();

            if (caja == null)
            {
                DialogResult respuesta = MessageBox.Show("No se abrió ninguna caja para el día de hoy. ¿Desea hacerlo ahora?", "Caja no abierta",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (respuesta == DialogResult.Yes)
                {
                    frmAperturaCaja frm = new frmAperturaCaja();
                    frm.ShowDialog();

                    caja = cajaNegocio.ObtenerCajaActual();
                    if (caja == null || caja.IdCaja == 0)
                    {
                        MessageBox.Show("No se pudo abrir la caja. Operación cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe abrir una caja para continuar.", "Operación cancelada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Close();
                }
            }

            if (caja.Estado == "Cerrado")
            {
                if (caja.FechaCierre.HasValue)
                {
                    MessageBox.Show($"La caja del día de hoy ya fue cerrada a las {caja.FechaCierre.Value.ToLocalTime():HH:mm}");
                }
                else
                {
                    MessageBox.Show("La caja del día de hoy ya fue cerrada.");
                }
                Close();
            }
        }


        private bool Validaciones()
        {
            if (string.IsNullOrWhiteSpace(txtMontoFinal.Text))
            {
                error.SetError(txtMontoFinal, "Debe ingresar un monto.");
                txtMontoFinal.Focus();
                return false;
            }

            if (caja.MontoFinal == null)
            {
                caja.MontoFinal = caja.MontoInicial;
            }
            decimal montoFinalUsuario = Math.Round(Convert.ToDecimal(txtMontoFinal.Text), 2);
            if (caja.MontoFinal != montoFinalUsuario && txtObservaciones.Text == "")
            {
                error.SetError(txtObservaciones, "Monto final distinto al sistema. Justifique en observaciones.");
                txtObservaciones.Focus();
                return false;
            }
            return true;
        }


        private void frmCierreCaja_Load(object sender, EventArgs e)
        {
            BuscarCaja();

            List<VistaCabFactVenta> facturasVentas = facturacionNegocio.BuscarFacturasFechaDesdeFechaHasta(caja.FechaApertura, caja.FechaApertura);
            decimal montoTotalVentas = 0;
            if (facturasVentas != null && facturasVentas.Any())
            {
                montoTotalVentas = facturasVentas.Sum(f => f.Total);
                txtTotalVenta.Text = montoTotalVentas.ToString("N2");
            }

            List<CajasEgresos> cajasEgresos = cajaNegocio.ObtenerCajaEgresoPorFecha(caja.FechaApertura);
            decimal montoEgresos = 0;
            if (cajasEgresos != null && cajasEgresos.Any())
            {
                montoEgresos = cajasEgresos.Sum(m => m.Monto);
                txtMontoEgresado.Text = montoEgresos.ToString("N2");
            }

            List<CajasIngresos> cajasIngresos = cajaNegocio.ObtenerCajaIngresoPorFecha(caja.FechaApertura);
            decimal montoIngreso = 0;
            if (cajasIngresos != null && cajasIngresos.Any())
            {
                montoIngreso = cajasIngresos.Sum(m => m.Monto);
                txtMontoIngresos.Text = montoIngreso.ToString("N2");
            }

            txtMontoSistema.Text = (caja.MontoFinal ?? caja.MontoInicial).ToString("N2");
        }

        private void txtMontoFinal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // Solo permitir un punto decimal
            TextBox textBox = sender as TextBox;
            if (e.KeyChar == '.' && textBox.Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void btnCerrarCaja_Click(object sender, EventArgs e)
        {
            if (Validaciones())
            {
                if (caja != null)
                {
                    caja.MontoFinal = Convert.ToDecimal(txtMontoFinal.Text);
                    caja.FechaCierre = DateTime.Now;
                    caja.Estado = "Cerrado";
                    caja.Observaciones = txtObservaciones.Text;
                }
                ResultadoOperacion resultado = cajaNegocio.CerrarCaja(caja);

                if (resultado.EsExitoso)
                {
                    MessageBox.Show("Se cerró la caja correctamente.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(resultado.Mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Close();
            }
        }
    }
}
