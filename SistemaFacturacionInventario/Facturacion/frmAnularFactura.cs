using CapaDatos.Modelos;
using CapaNegocio;
using SistemaFacturacionInventario.Auxiliares;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SistemaFacturacionInventario.Facturacion
{
    public partial class frmAnularFactura : FormBase
    {
        public int idFactura = 0;
        private FacturacionNegocio facturacionNegocio = new FacturacionNegocio();
        private FacturasVenta facturaVenta = new FacturasVenta();
        private List<FacturasVentaDetalle> facturaVentaDetalle = new List<FacturasVentaDetalle>();
        private FacturasElectronicas facturasElectronicas = new FacturasElectronicas();
        private ClienteNegocio clienteNegocio = new ClienteNegocio();
        private bool artdesc;
        private AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();
        public frmAnularFactura()
        {
            InitializeComponent();
        }

        private void frmAnularFactura_Load(object sender, EventArgs e)
        {
            LLenarCampos();
        }

        private void LLenarCampos()
        {
            facturaVenta = facturacionNegocio.ObtenerFactura(idFactura);


            if (facturaVenta != null)
            {
                facturasElectronicas = facturacionNegocio.ObtenerFacturaElec(idFactura);
                if (facturasElectronicas != null)
                {
                    txtNroCAE.Text = facturasElectronicas.CAE.ToString();
                    txtNroCAE.Enabled = false;
                    txtNroCAE.Visible = true;
                    lblCAE.Visible = true;
                }

                txtNroCliente.Text = facturaVenta.IdCliente.ToString();
                var cliente = clienteNegocio.ObtenerCliporNroCli(facturaVenta.IdCliente);
                lblNombreCliente.Text = cliente.Nombre + " " + cliente.Apellido;
                if (facturaVenta.IdTipoFactura == 1)
                {
                    cmbTipoFac.SelectedText = "A";
                    cmbTipoFac.SelectedValue = 1;
                }
                else
                {
                    cmbTipoFac.SelectedText = "B";
                    cmbTipoFac.SelectedValue = 2;
                }

                switch (facturaVenta.IdFormaPago)
                {
                    case 1:
                        cmboFormaPago.SelectedText = "Efectivo";
                        cmboFormaPago.SelectedValue = 1;
                        break;
                    case 2:
                        cmboFormaPago.SelectedText = "Tarjeta de Crédito";
                        cmboFormaPago.SelectedValue = 2;
                        break;
                    case 3:
                        cmboFormaPago.SelectedText = "Tarjeta de Débito";
                        cmboFormaPago.SelectedValue = 3;
                        break;
                    case 4:
                        cmboFormaPago.SelectedText = "Transferencia";
                        cmboFormaPago.SelectedValue = 4;
                        break;
                    case 5:
                        cmboFormaPago.SelectedText = "Mercado Pago";
                        cmboFormaPago.SelectedValue = 5;
                        break;
                    default:
                        break;
                }

                switch (facturaVenta.IdConceptoFactura)
                {
                    case 1:
                        cmbConcepto.SelectedText = "Productos";
                        cmbConcepto.SelectedValue = 1;
                        break;
                    case 2:
                        cmbConcepto.SelectedText = "Servicios";
                        cmbConcepto.SelectedValue = 2;
                        break;
                    case 3:
                        cmbConcepto.SelectedText = "Productos y Servicios";
                        cmbConcepto.SelectedValue = 3;
                        break;
                    default:
                        break;

                }

                txtBV.Text = facturaVenta.BVFact;
                txtNroComp.Text = facturaVenta.NCompFact;
                dtpFecha.Value = facturaVenta.FechaEmision;
                dtpFechaVto.Value = facturaVenta.FechaVencimiento;
                chkMoverStock.Checked = facturaVenta.MoverStock;

                dgrDetalle.Rows.Clear();
                List<FacturasVentaDetalle> lista = facturacionNegocio.ObtenerDetalledeFacturaVta(facturaVenta.IdFacturaVenta);
                dgrDetalle.Rows.Add(lista.Count);

                int i = 0;

                foreach (FacturasVentaDetalle fvd in lista)
                {

                    var dt = new DataTable();
                    var comboCell = new DataGridViewComboBoxCell();

                    if (fvd.IdProducto != null)
                    {
                        var productoNegocio = new ProductoNegocio();
                        var producto = productoNegocio.ObtenerProductoPorId(Convert.ToInt32(fvd.IdProducto));

                        dgrDetalle.Rows[i].Cells[3].Value = producto.IdProducto.ToString();
                        dgrDetalle.Rows[i].Cells[4].Value = producto.DescCorta;
                        dgrDetalle.Rows[i].Cells[5].Value = fvd.Cantidad;
                        dgrDetalle.Rows[i].Cells[6].Value = producto.UnidadesMedida;

                        dt = productoNegocio.CargarComboPrecios(producto.IdProducto, cmbTipoFac.Text);

                        if (Convert.ToBoolean(fvd.PrecioManual))
                        {
                            var rw = dt.NewRow();
                            rw["Desc"] = "Manual: $" + fvd.PrecioUnitario.ToString("N2");
                            rw["Precio"] = fvd.PrecioUnitario;
                            dt.Rows.Add(rw);
                        }

                        comboCell.DataSource = dt;
                        comboCell.DisplayMember = "Desc";
                        comboCell.ValueMember = "Precio";

                        // Verificamos si el valor existe en la lista
                        var valorSeleccionado = fvd.PrecioManual == false ? dt.Rows[0]["Precio"] : dt.Rows[dt.Rows.Count - 1]["Precio"];
                        if (dt.AsEnumerable().Any(r => r["Precio"].ToString() == valorSeleccionado.ToString()))
                        {
                            comboCell.Value = valorSeleccionado;
                        }

                        dgrDetalle.Rows[i].Cells["Precio"] = comboCell;
                        dgrDetalle.Rows[i].Cells[11].Value = false;
                    }
                    else
                    {
                        dgrDetalle.Rows[i].Cells[4].Value = fvd.Producto;
                        dgrDetalle.Rows[i].Cells[5].Value = fvd.Cantidad;
                        dgrDetalle.Rows[i].Cells[6].Value = fvd.UMedida;

                        dt.Columns.Add("Desc");
                        dt.Columns.Add("Precio");

                        var rw = dt.NewRow();
                        rw["Desc"] = "$ " + fvd.PrecioUnitario.ToString("N2");
                        rw["Precio"] = fvd.PrecioUnitario;
                        dt.Rows.Add(rw);

                        comboCell.DataSource = dt;
                        comboCell.DisplayMember = "Desc";
                        comboCell.ValueMember = "Precio";
                        comboCell.Value = dt.Rows[0]["Precio"];

                        dgrDetalle.Rows[i].Cells["Precio"] = comboCell;
                        dgrDetalle.Rows[i].Cells[12].Value = true;
                        artdesc = true;
                    }

                    dgrDetalle.Rows[i].Cells[6].Value = fvd.Cantidad;

                    // Aseguramos que el valor esté convertido correctamente
                    decimal valorUnitario;
                    decimal.TryParse(comboCell.Value?.ToString(), out valorUnitario);
                    dgrDetalle["Total", i].Value = Math.Round(fvd.Cantidad * valorUnitario, 2, MidpointRounding.AwayFromZero);

                    var repax = new AuxiliaresNegocio();
                    var ti = repax.ObtenerTipoIVAporId(fvd.IdTipoIva);
                    dgrDetalle.Rows[i].Cells[7].Value = ti.PorcentajeIVA;
                    dgrDetalle.Rows[i].Cells[11].Value = false;
                    dgrDetalle.Rows[i].Cells["IdFactVtaDetalle"].Value = fvd.IdFacturaVentaDetalle;

                    i++;
                    artdesc = false;
                }

                txtBV.Text = facturaVenta.BVFact;
                txtNroComp.Text = facturaVenta.NCompFact;

                lblTotal.Text = facturaVenta.Total.ToString(CultureInfo.InvariantCulture);
                lblSubTotal21.Text = facturaVenta.Subtotal21.ToString(CultureInfo.InvariantCulture);
                lblSubTotal105.Text = facturaVenta.Subtotal105.ToString(CultureInfo.InvariantCulture);
                lblTotalDto.Text = facturaVenta.TotalDescuento.ToString(CultureInfo.InvariantCulture);
                lblSubTotal.Text = (Convert.ToDecimal(lblSubTotal21.Text) + Convert.ToDecimal(lblSubTotal105.Text) + Convert.ToDecimal(lblSubTotal0.Text)).ToString(CultureInfo.InvariantCulture);
                lblSubTotal0.Text = (Convert.ToDecimal(lblSubTotal.Text) - Convert.ToDecimal(lblSubTotal21.Text) - Convert.ToDecimal(lblSubTotal105.Text)).ToString(CultureInfo.InvariantCulture);
                lblSubtDto0.Text = (Convert.ToDecimal(lblSubTotal0.Text) - Convert.ToDecimal(facturaVenta.TotalDescuento)).ToString(CultureInfo.InvariantCulture);
                lblSubtDto105.Text = (Convert.ToDecimal(lblSubTotal105.Text) - Convert.ToDecimal(facturaVenta.TotalDescuento105)).ToString(CultureInfo.InvariantCulture);
                lblSubtDto21.Text = (Convert.ToDecimal(lblSubTotal21.Text) - Convert.ToDecimal(facturaVenta.TotalDescuento21)).ToString(CultureInfo.InvariantCulture);
                lblSubtDto.Text = (Convert.ToDecimal(lblSubtDto0.Text) + Convert.ToDecimal(lblSubtDto105.Text) + Convert.ToDecimal(lblSubtDto21.Text)).ToString(CultureInfo.InvariantCulture);
                lblTotalIva105.Text = Math.Round(Convert.ToDecimal(lblSubtDto105.Text) * Convert.ToDecimal(0.105), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
                lblTotalIva21.Text = Math.Round(Convert.ToDecimal(lblSubtDto21.Text) * Convert.ToDecimal(0.21), 2, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
                lblTotalIva0.Text = "0";

                CambiarTipoFact();
                //CalcularTotales(false);
            }
        }

        private void CambiarTipoFact()
        {
            try
            {
                lbllblIVA21.Visible = cmbTipoFac.Text == "A";
                lbllblSubtDto.Visible = cmbTipoFac.Text == "A";
                lbllblSubTotaldto105.Visible = cmbTipoFac.Text == "A";
                lbllblSubTotaldto21.Visible = cmbTipoFac.Text == "A";
                lbllblSubTotal21.Visible = cmbTipoFac.Text == "A";
                lbllblSubTotal105.Visible = cmbTipoFac.Text == "A";
                lbllblIVA105.Visible = cmbTipoFac.Text == "A";
                lbllblIVA.Visible = cmbTipoFac.Text == "A";
                lblSubtDto105.Visible = cmbTipoFac.Text == "A";
                lblSubtDto21.Visible = cmbTipoFac.Text == "A";
                lblSubTotal105.Visible = cmbTipoFac.Text == "A";
                lblSubTotal21.Visible = cmbTipoFac.Text == "A";
                lblSubtDto.Visible = cmbTipoFac.Text == "A";
                lblTotalIva21.Visible = cmbTipoFac.Text == "A";
                lblTotalIVA.Visible = cmbTipoFac.Text == "A";
                lblTotalIva105.Visible = cmbTipoFac.Text == "A";
                lbllblIVA0.Visible = cmbTipoFac.Text == "A";
                lbllblSubTotal0.Visible = cmbTipoFac.Text == "A";
                lbllblSubTotaldto0.Visible = cmbTipoFac.Text == "A";
                lblSubtDto0.Visible = cmbTipoFac.Text == "A";
                lblSubTotal0.Visible = cmbTipoFac.Text == "A";
                lblTotalIva0.Visible = cmbTipoFac.Text == "A";
            }
            catch (Exception ex) { throw ex; }
        }


        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Validaciones()) return;


                bool estado = facturacionNegocio.AnularFactura(facturaVenta);
                if (estado)
                {
                    MessageBox.Show("Factura anulada correctamente", "Sistema de Facturación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    facturaVentaDetalle = facturacionNegocio.ObtenerDetalledeFacturaVta(idFactura);
                    ImprimeFactura.ImprimeAnulacion(facturaVenta, facturaVentaDetalle);

                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al anular la factura", "Sistema de Facturación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool Validaciones()
        {
            try
            {
                var ok = true;

                if (!FuncionesForms.NroEneteroInt32(txtNroCliente.Text))
                {
                    Error.SetError(txtNroCliente, "Seleccione un cliente");
                    ok = false;
                }
                else Error.SetError(txtNroCliente, "");

                if (idFactura == 0)
                {
                    Error.SetError(txtNroCliente, "No tiene factura para dar de baja");
                    ok = false;
                }
                else Error.SetError(txtNroCliente, "");


                return ok;
            }
            catch (Exception ex) { throw new Exception($"Error : {ex.Message}", ex); }
        }
    }
}
