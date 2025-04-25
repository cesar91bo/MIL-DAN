using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using SistemaFacturacionInventario.Productos;
using SistemaFacturacionInventario.Rubros;
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
    public partial class frmConsultaFacturas : FormBase
    {
        private List<VistaCabFactVenta> vistaCabFactVentas;
        private FacturacionNegocio facturacionNegocio = new FacturacionNegocio();
        private int selectedFacturaId;
        public frmConsultaFacturas()
        {
            InitializeComponent();
        }

        private void frmConsultaFacturas_Load(object sender, EventArgs e)
        {
            CrearColumnasLv();
            LlenarLv(true);
        }

        private void CrearColumnasLv()
        {
            try
            {
                listViewFactura.Columns.Add("Nro.Factura", 85, HorizontalAlignment.Center);
                listViewFactura.Columns.Add("Tipo Doc.", 110, HorizontalAlignment.Center);
                listViewFactura.Columns.Add("F.Pago", 85, HorizontalAlignment.Right);
                listViewFactura.Columns.Add("Fecha Fact.", 100, HorizontalAlignment.Center);
                listViewFactura.Columns.Add("Cliente", 250, HorizontalAlignment.Left);
                listViewFactura.Columns.Add("Subtotal", 90, HorizontalAlignment.Center);
                listViewFactura.Columns.Add("IVA 10.5%", 85, HorizontalAlignment.Right);
                listViewFactura.Columns.Add("IVA 21%", 85, HorizontalAlignment.Right);
                listViewFactura.Columns.Add("Total", 85, HorizontalAlignment.Right);
            }
            catch (Exception ex) { throw ex; }
        }

        private void LlenarLv(bool isLoad)
        {
            try
            {
                listViewFactura.Items.Clear();
                if (isLoad)
                {
                    List<VistaCabFactVenta> Lista = FiltrarBusqueda();
                    foreach (VistaCabFactVenta l in Lista)
                    {
                        var item = new ListViewItem { Tag = l, Text = l.IdFacturaVenta.ToString() };
                        item.SubItems.Add(l.TipoDoc);
                        item.SubItems.Add(l.FPago);
                        item.SubItems.Add(l.FechaEmision.ToShortDateString());
                        item.SubItems.Add(l.Cliente);
                        item.SubItems.Add(l.SubTotal.ToString());
                        item.SubItems.Add(l.TotalIva105.ToString());
                        item.SubItems.Add(l.TotalIva21.ToString());
                        item.SubItems.Add(l.Total.ToString());
                        listViewFactura.Items.Add(item);
                    }
                }
                else
                {
                    vistaCabFactVentas = FiltrarBusqueda();
                }

                if (vistaCabFactVentas == null) return;
                foreach (CapaDatos.Modelos.VistaCabFactVenta fact in vistaCabFactVentas)
                {
                    var item = new ListViewItem { Tag = fact, Text = fact.IdFacturaVenta.ToString() };
                    item.SubItems.Add(fact.TipoDoc);
                    item.SubItems.Add(fact.FPago);
                    item.SubItems.Add(fact.FechaEmision.ToShortDateString());
                    item.SubItems.Add(fact.Cliente);
                    item.SubItems.Add(fact.SubTotal.ToString());
                    item.SubItems.Add(fact.TotalIva105.ToString());
                    item.SubItems.Add(fact.TotalIva21.ToString());
                    item.SubItems.Add(fact.Total.ToString());
                    listViewFactura.Items.Add(item);
                    listViewFactura.Focus();
                }
            }
            catch (Exception ex) { throw ex; }
        }

        //private List<VistaCabFactVenta> BuscarFacturas()
        //{
        //    return facturacionNegocio.ObtenerListCabFactPorCliente(txtFiltro.Text);
        //}

        private List<VistaCabFactVenta> FiltrarBusqueda()
        {
            try
            {
                string fechadf = chkFechaFactura.Checked ? dtpFechaDesdeFact.Value.ToShortDateString() + " 00:00:00" : "";
                string fechahf = chkFechaFactura.Checked ? dtpFechaHastaFact.Value.ToShortDateString() + " 23:59:59" : "";
                string clientefact = chkClienteFactura.Checked ? txtFiltro.Text : "";

                return facturacionNegocio.ObtenerListaFacturas(fechadf, fechahf, clientefact);
            }
            catch (Exception ex) { throw ex; }
        }

        private void chkClienteFactura_CheckedChanged(object sender, EventArgs e)
        {
            txtFiltro.Enabled = chkClienteFactura.Checked;
        }

        private void chkFechaFactura_CheckedChanged(object sender, EventArgs e)
        {
            dtpFechaDesdeFact.Enabled = chkFechaFactura.Checked;
            dtpFechaHastaFact.Enabled = chkFechaFactura.Checked;
        }

        private void txtFiltro_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) { LlenarLv(false); }
                txtFiltro.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                LlenarLv(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDetalle_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmFacturacion { IdFact = selectedFacturaId, Accion = "VER" };
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.Cancel) return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listViewFactura_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (listViewFactura.SelectedItems.Count > 0)
            {
                var item = listViewFactura.SelectedItems[0];
                int id = Convert.ToInt32(item.SubItems[0].Text);

                // Guardás el ID para usar después si querés
                selectedFacturaId = id;

                // Habilitás el botón
                btnDetalle.Enabled = true;
                btnImprimir.Enabled = true;
                btnAnular.Enabled = true;
            }
            else
            {
                btnDetalle.Enabled = false;
                btnImprimir.Enabled = false;
                btnAnular.Enabled = false;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {

            if (selectedFacturaId > 0)
            {
                FacturasVenta fact = facturacionNegocio.ObtenerFactura(selectedFacturaId);
                List<FacturasVentaDetalle> ventaDetalle = facturacionNegocio.ObtenerDetalledeFacturaVta(selectedFacturaId);
                FacturasElectronicas electronicas = facturacionNegocio.ObtenerFacturaElec(selectedFacturaId);

                if (electronicas != null)
                {
                    ImprimeFactura.ImprimeFacturaElec(fact, ventaDetalle);
                }
                else
                {
                    ImprimeFactura.ImprimeFacturaX(fact, ventaDetalle);
                }
                
            }
            else
            {
                MessageBox.Show("Debes seleccionar una factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            if (selectedFacturaId > 0)
            {
                var frm = new frmAnularFactura { idFactura = selectedFacturaId };
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    LlenarLv(true);
                    MessageBox.Show("Factura anulada correctamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar una factura", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
