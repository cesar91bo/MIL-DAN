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

namespace SistemaFacturacionInventario.Facturacion
{
    public partial class frmConsultaFacturas : FormBase
    {
        public frmConsultaFacturas()
        {
            InitializeComponent();
        }

        private void frmConsultaFacturas_Load(object sender, EventArgs e)
        {
            CrearColumnasLv();
            LlenarLv();
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

        private void LlenarLv()
        {
            try
            {
                listViewFactura.Items.Clear();
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
            catch (Exception ex) { throw ex; }
        }

        private List<VistaCabFactVenta> FiltrarBusqueda()
        {
            try
            {
                string fechadf = chkFechaFactura.Checked ? dtpFechaDesdeFact.Value.ToShortDateString() + " 00:00:00" : "";
                string fechahf = chkFechaFactura.Checked ? dtpFechaHastaFact.Value.ToShortDateString() + " 23:59:59" : "";
                string clientefact = chkClienteFactura.Checked ? txtFiltro.Text : "";
                var facturacionNegocio = new FacturacionNegocio();
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
    }
}
