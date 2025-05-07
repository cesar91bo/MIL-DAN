using CapaDatos.Modelos;
using CapaNegocio;
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
        private ClienteNegocio clienteNegocio = new ClienteNegocio();
        private bool artdesc;
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

        private void CalcularTotales(bool CalcSubT)
        {
            try
            {
                if (CalcSubT)
                {
                    lblSubTotal.Text = "0"; //en cero los subtotales
                    lblSubTotal105.Text = "0";
                    lblSubTotal21.Text = "0";
                    lblSubTotal0.Text = "0";
                    foreach (DataGridViewRow rw in dgrDetalle.Rows)
                    {
                        decimal subt = rw.Cells[9].Value == null ? 0 : Convert.ToDecimal(rw.Cells[9].Value);
                        if (cmbTipoFac.Text == "A") //Si es "A" se calculan los subtotales correspondientes al IVA del producto y se suman
                        {
                            if (Convert.ToDecimal(rw.Cells[7].Value) == 21) //IVA 21%
                            {
                                lblSubTotal21.Text = Math.Round(Convert.ToDecimal(lblSubTotal21.Text) + subt, 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            else if (Convert.ToDecimal(rw.Cells[7].Value) == 10.5M) //IVA 10,5%
                            {
                                lblSubTotal105.Text = Math.Round(Convert.ToDecimal(lblSubTotal105.Text) + subt, 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            else //IVA 0%
                            {
                                lblSubTotal0.Text = Math.Round(Convert.ToDecimal(lblSubTotal0.Text) + subt, 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            lblSubTotal.Text = Math.Round(Convert.ToDecimal(lblSubTotal0.Text) + Convert.ToDecimal(lblSubTotal21.Text) + Convert.ToDecimal(lblSubTotal105.Text), 2,
                                MidpointRounding.AwayFromZero).ToString();
                        }
                        else //Si es B solo subtotal sin IVA
                        {
                            if (Convert.ToDecimal(rw.Cells[7].Value) == 21) //IVA 21%
                            {
                                lblSubTotal21.Text = Math.Round((Convert.ToDecimal(lblSubTotal21.Text) + subt), 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            else if (Convert.ToDecimal(rw.Cells[7].Value) == 10.5M) //IVA 10,5%
                            {
                                lblSubTotal105.Text = Math.Round((Convert.ToDecimal(lblSubTotal105.Text) + subt), 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            else //IVA 0%
                            {
                                lblSubTotal0.Text = Math.Round(Convert.ToDecimal(lblSubTotal0.Text) + subt, 2, MidpointRounding.AwayFromZero).ToString();
                            }
                            lblSubTotal.Text = Math.Round(Convert.ToDecimal(lblSubTotal.Text) + subt, 2, MidpointRounding.AwayFromZero).ToString();
                        }
                    }
                }

                if (cmbTipoFac.Text == "A")
                {
                    lblTotalDto.Text = (Math.Round(Convert.ToDecimal(lblSubTotal0.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100), 2, MidpointRounding.AwayFromZero) +
                                        Math.Round(Convert.ToDecimal(lblSubTotal105.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100), 2, MidpointRounding.AwayFromZero) +
                                        Math.Round(Convert.ToDecimal(lblSubTotal21.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100), 2, MidpointRounding.AwayFromZero)).ToString();
                    //Esta porción de código es para que cuando el cálculo de abajo de -0.01 se sume 0.01 al campo de TotalDescuento.
                    //De esta forma se evita el error a la hora de actualizar algunas facturas que usan descuento.
                    if (Convert.ToDecimal(lblSubTotal.Text.Replace(".", ",")) -
                        Convert.ToDecimal(lblTotalDto.Text.Replace(".", ",")) -
                        Convert.ToDecimal(lblSubtDto21.Text.Replace(".", ",")) -
                        Convert.ToDecimal(lblSubtDto105.Text.Replace(".", ",")) == Convert.ToDecimal(-0.01))
                    {
                        lblTotalDto.Text = Convert.ToString(Convert.ToDecimal(lblTotalDto.Text.Replace(".", ",")) - Convert.ToDecimal(0.01), CultureInfo.InvariantCulture);
                    }
                    //Fin de la porción de código de validación del campo TotalDescuento.
                    lblSubtDto0.Text = Math.Round(Convert.ToDecimal(lblSubTotal0.Text) - (Convert.ToDecimal(lblSubTotal0.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblSubtDto105.Text = Math.Round(Convert.ToDecimal(lblSubTotal105.Text) - (Convert.ToDecimal(lblSubTotal105.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblSubtDto21.Text = Math.Round(Convert.ToDecimal(lblSubTotal21.Text) - (Convert.ToDecimal(lblSubTotal21.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblSubtDto.Text = Math.Round(Convert.ToDecimal(lblSubtDto0.Text) + Convert.ToDecimal(lblSubtDto105.Text) + Convert.ToDecimal(lblSubtDto21.Text), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblTotalIva105.Text = Math.Round(Convert.ToDecimal(lblSubtDto105.Text) * Convert.ToDecimal(0.105), 2, MidpointRounding.AwayFromZero).ToString();
                    lblTotalIva21.Text = Math.Round(Convert.ToDecimal(lblSubtDto21.Text) * Convert.ToDecimal(0.21), 2, MidpointRounding.AwayFromZero).ToString();
                    lblTotalIva0.Text = "0";
                    lblTotalIVA.Text = Math.Round(Convert.ToDecimal(lblTotalIva105.Text) + Convert.ToDecimal(lblTotalIva21.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    lblTotal.Text = Math.Round(Convert.ToDecimal(lblSubtDto.Text) + Convert.ToDecimal(lblTotalIva105.Text) + Convert.ToDecimal(lblTotalIva21.Text), 2,
                        MidpointRounding.AwayFromZero).ToString();
                }
                else
                {
                    lblTotalDto.Text = Math.Round(Convert.ToDecimal(lblSubTotal.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100), 2, MidpointRounding.AwayFromZero).ToString();
                    //Esta porción de código es para que cuando el cálculo de abajo de -0.01 se sume 0.01 al campo de TotalDescuento.
                    //De esta forma se evita el error a la hora de actualizar algunas facturas que usan descuento.
                    if (Convert.ToDecimal(lblSubTotal.Text.Replace(".", ",")) -
                        Convert.ToDecimal(lblTotalDto.Text.Replace(".", ",")) -
                        Convert.ToDecimal(lblSubtDto21.Text.Replace(".", ",")) -
                        Convert.ToDecimal(lblSubtDto105.Text.Replace(".", ",")) == Convert.ToDecimal(-0.01))
                    {
                        lblTotalDto.Text = Convert.ToString(Convert.ToDecimal(lblTotalDto.Text.Replace(".", ",")) - Convert.ToDecimal(0.01), CultureInfo.InvariantCulture);
                    }
                    //Fin de la porción de código de validación del campo TotalDescuento.
                    lblSubtDto.Text = Math.Round(Convert.ToDecimal(lblSubTotal.Text) - Convert.ToDecimal(lblTotalDto.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    lblTotal.Text = Convert.ToString(Math.Round(Decimal.Parse(lblSubTotal.Text) - (Decimal.Parse(lblSubTotal.Text) * (Decimal.Parse(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero));
                    lblSubtDto0.Text = Math.Round(Convert.ToDecimal(lblSubTotal0.Text) - (Convert.ToDecimal(lblSubTotal0.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblSubtDto105.Text = Math.Round(Convert.ToDecimal(lblSubTotal105.Text) - (Convert.ToDecimal(lblSubTotal105.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblSubtDto21.Text = Math.Round(Convert.ToDecimal(lblSubTotal21.Text) - (Convert.ToDecimal(lblSubTotal21.Text) * (Convert.ToDecimal(txtDto.Text.Replace(".", ",")) / 100)), 2,
                        MidpointRounding.AwayFromZero).ToString();
                    lblSubtDto.Text = Math.Round(Convert.ToDecimal(lblSubtDto0.Text) + Convert.ToDecimal(lblSubtDto105.Text) + Convert.ToDecimal(lblSubtDto21.Text), 2,
                        MidpointRounding.AwayFromZero).ToString();

                }

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {

        }
    }
}
