﻿using CapaDatos.Modelos;
using CapaNegocio;
using Microsoft.VisualBasic;
using SistemaFacturacionInventario.Auxiliares;
using SistemaFacturacionInventario.Cajas;
using SistemaFacturacionInventario.Principal;
using SistemaFacturacionInventario.Productos;
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
    public partial class frmFacturacion : FormBase
    {
        public string Accion;
        public Int16 IdTipoDoc;
        public Int32 IdFact;
        public bool siload;
        public List<Int32> lrem, ListPre;
        private string cuit;
        private decimal SaldoCtaCte;
        private bool artdesc, Autorizar;
        private List<Int64> lint;
        public Int32 IdCliente;
        CajaNegocio cajaNegocio = new CajaNegocio();
        CapaDatos.Modelos.Cajas caja = new CapaDatos.Modelos.Cajas();

        private AuxiliaresNegocio auxiliaresNegocio = new AuxiliaresNegocio();

        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                SaldoCtaCte = 0;
                LlenarCombos();

                txtNroCliente.Text = "1";
                if (IdCliente == 0)
                {
                    IdCliente = 1;
                    BuscarCliente(IdCliente);
                }
                else
                {
                    BuscarCliente(IdCliente);
                }

                Seteos seteos = auxiliaresNegocio.ObtenerSeteos();

                if (seteos.DiasVtoFact > 0) dtpFechaVto.Value = DateTime.Today.AddDays(Convert.ToInt32(seteos.DiasVtoFact));

                if (Accion.ToUpper() == "VER")
                {
                    if (IdFact > 0) ConsultarFact(IdFact);
                    dgrDetalle.Enabled = false;
                    cmboFormaPago.Enabled = false;
                    cmbTipoFac.Enabled = false;
                    txtNroCliente.Enabled = false;
                    btnBuscar.Enabled = false;
                    btnListado.Enabled = false;
                    brnAnonimo.Enabled = false;
                    cmbConcepto.Enabled = false;
                    //if (Accion.ToUpper() == "MOD") lint = new List<Int64>();
                }

                if (IdTipoDoc == 8)
                {
                    txtBV.Visible = false;
                    txtNroComp.Visible = false;
                    cmbTipoFac.Visible = false;
                    lblTipoFact.Visible = false;
                }

            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void ConsultarFact(int idFact)
        {
            try
            {
                var repv = new FacturacionNegocio();
                FacturasVenta fv = repv.ObtenerFactura(idFact);
                int f = 0;


                txtNroCliente.Text = fv.IdCliente.ToString();
                chkMoverStock.Checked = fv.MoverStock;
                BuscarCliente(fv.IdCliente);
                cmboFormaPago.SelectedValue = fv.IdFormaPago;

                if (!string.IsNullOrEmpty(fv.BVFact) && IdTipoDoc != 8) { txtBV.Text = fv.BVFact; }
                if (IdTipoDoc == 2 || IdTipoDoc == 3)
                {
                    txtBVNC.Text = fv.BVReferencia;
                    txtNroFactNC.Text = fv.NroCompFactReferencia;
                }
                if (IdTipoDoc == 8)
                {
                    txtNroComp.Text = fv.NCompFact;
                }
                //FacturasVenta fact = repv.ObtenerFactura(lrem[0]);//agregado
                //foreach (Int32 r in lrem)
                //{
                List<FacturasVentaDetalle> detrem = repv.ObtenerDetalledeFacturaVta(fv.IdFacturaVenta);
                //FacturasVenta rem = repv.ObtenerFactura(r);
                txtDto.Text = fv.Descuento.ToString();
                dgrDetalle.Rows.Add(detrem.Count);


                if (fv.Impresa)
                {
                    lblImpresa.Text = "La factura ya fue impresa";
                    lblImpresa.Visible = true;
                    txtNroComp.Text = fv.NCompFact;
                    txtBV.Text = fv.BVFact;
                    txtNroComp.Visible = true;
                    txtBV.Visible = true;
                }
                else if (IdTipoDoc != 8)
                {
                    lblImpresa.Visible = true;
                    lblImpresa.Text = "La factura está pendiente de impresión";
                }

                if (cmbTipoFac.Text == "B")
                {
                    lbllblIVA21.Visible = false;
                    lbllblSubtDto.Visible = false;
                    lbllblSubTotaldto105.Visible = false;
                    lbllblSubTotaldto21.Visible = false;
                    lbllblSubTotal21.Visible = false;
                    lbllblSubTotal105.Visible = false;
                    lbllblIVA105.Visible = false;
                    lbllblIVA.Visible = false;
                    lblSubtDto105.Visible = false;
                    lblSubtDto21.Visible = false;
                    lblSubTotal105.Visible = false;
                    lblSubTotal21.Visible = false;
                    lblSubtDto.Visible = false;
                    lblTotalIva21.Visible = false;
                    lblTotalIVA.Visible = false;
                    lblTotalIva105.Visible = false;
                }
                else
                {
                    lblSubtDto.Text = Math.Round(Convert.ToDecimal(lblSubtDto105.Text) + Convert.ToDecimal(lblSubtDto21.Text), 2, MidpointRounding.AwayFromZero).ToString();
                    lblTotalIVA.Text = Math.Round(Convert.ToDecimal(lblTotalIva21.Text) + Convert.ToDecimal(lblTotalIva105.Text), 2, MidpointRounding.AwayFromZero).ToString();
                }
                if (Accion.ToUpper() == "VER") btnGuardar.Visible = false;

                List<FacturasVentaDetalle> det = repv.ObtenerDetalledeFacturaVta(IdFact);
                int i = 0;
                foreach (FacturasVentaDetalle fvd in det)
                {

                    var cmb = dgrDetalle["Precio", i] as DataGridViewComboBoxCell;
                    var dt = new DataTable();
                    if (fvd.IdProducto != null)
                    {
                        var productoNegocio = new ProductoNegocio();
                        CapaDatos.Modelos.Productos producto = productoNegocio.ObtenerProductoPorId(Convert.ToInt32(fvd.IdProducto));
                        dgrDetalle.Rows[i].Cells[3].Value = producto.IdProducto.ToString();
                        dgrDetalle.Rows[i].Cells[4].Value = producto.DescCorta;
                        dgrDetalle.Rows[i].Cells[5].Value = fvd.Cantidad;
                        dgrDetalle.Rows[i].Cells[6].Value = producto.UnidadesMedida;

                        dt = productoNegocio.CargarComboPrecios(producto.IdProducto, cmbTipoFac.Text);

                        cmb.DataSource = dt;
                        cmb.DisplayMember = "Desc";
                        cmb.ValueMember = "Precio";
                        dgrDetalle.Rows[i].Cells[12].Value = false;

                        if (Convert.ToBoolean(fvd.PrecioManual))
                        {
                            var rw = dt.NewRow();
                            rw[0] = "Manual: $" + fvd.PrecioUnitario.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
                            rw[1] = fvd.PrecioUnitario.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
                            dt.Rows.Add(rw);
                            cmb.DataSource = dt;
                            cmb.DisplayMember = "Desc";
                            cmb.ValueMember = "Precio";
                        }

                        cmb.Value = fvd.PrecioManual == false ? dt.Rows[0]["Precio"] : dt.Rows[2]["Precio"];
                    }
                    else
                    {
                        dgrDetalle.Rows[i].Cells[5].Value = fvd.IdProducto;
                        dgrDetalle.Rows[i].Cells[7].Value = fvd.UMedida;
                        dt.Columns.Add("Desc");
                        dt.Columns.Add("Precio");
                        DataRow rw = dt.NewRow();
                        rw[0] = "$ " + fvd.PrecioUnitario;
                        rw[1] = fvd.PrecioUnitario;
                        dt.Rows.Add(rw);
                        cmb.DataSource = dt;
                        cmb.DisplayMember = "Desc";
                        cmb.ValueMember = "Precio";
                        cmb.Value = dt.Rows[0]["Precio"];
                        dgrDetalle.Rows[i].Cells[12].Value = true;
                        artdesc = true;
                    }

                    dgrDetalle.Rows[i].Cells[6].Value = fvd.Cantidad;
                    dgrDetalle["Total", i].Value = Math.Round(fvd.Cantidad * Convert.ToDecimal(cmb.Value), 2, MidpointRounding.AwayFromZero);
                    var repax = new AuxiliaresNegocio();
                    TiposIva ti = repax.ObtenerTipoIVAporId(fvd.IdTipoIva);
                    dgrDetalle.Rows[i].Cells[7].Value = ti.PorcentajeIVA;
                    dgrDetalle.Rows[i].Cells[11].Value = false;
                    dgrDetalle.Rows[i].Cells["IdFactVtaDetalle"].Value = fvd.IdFacturaVentaDetalle;
                    i += 1;
                    artdesc = false;
                }

                IdTipoDoc = fv.IdTipoDocumento;
                //if (IdTipoDoc == 8) btnImprimir.Visible = true;
                CalcularTotales(true);
                //}
            }
            catch (Exception ex) { throw ex; }
        }

        private void btnListado_Click(object sender, EventArgs e)
        {
            try
            {
                var frm = new frmListaClientes { Seleccion = true };
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK || frm.IdCLiente <= 0) return;
                BuscarCliente(frm.IdCLiente);

            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void brnAnonimo_Click(object sender, EventArgs e)
        {
            try
            {
                txtNroCliente.Text = "1";
                BuscarCliente(1);
                dgrDetalle.Enabled = true;
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNroCliente.Text != "")
                {
                    IdCliente = Convert.ToInt32(txtNroCliente.Text);
                    BuscarCliente(IdCliente);
                    dgrDetalle.Enabled = true;
                }
                else
                {
                    IdCliente = 0;
                    lblNomreCliente.Visible = false;
                    dgrDetalle.Enabled = false;
                    MessageBox.Show("Ingrese Nro. de Cliente para realizar la búsqueda", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void dgrDetalle_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0) e.Value = new System.Drawing.Bitmap(imageList1.Images[1]);
                if (e.ColumnIndex == 1) e.Value = new System.Drawing.Bitmap(imageList1.Images[0]);
                if (e.ColumnIndex == 2) e.Value = new System.Drawing.Bitmap(imageList1.Images[2]);
                if (e.ColumnIndex == 13) e.Value = new System.Drawing.Bitmap(imageList1.Images[3]);
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void dgrDetalle_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (e.ColumnIndex)
                {
                    case 0:
                        EliminarFila();
                        break;

                    case 1:
                        if (dgrDetalle.Rows.Count > 15)
                        {
                            MessageBox.Show("El máximo de líneas por factura es 15. Por favor elimine los restantes y haga una factura nueva", "CANTIDAD MAXIMA ALCANZADA", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                            BuscarArtDgr();
                        break;

                    case 2:
                        if (dgrDetalle.Rows.Count > 15)
                        {
                            MessageBox.Show("El máximo de líneas por factura es 15. Por favor elimine los restantes y haga una factura nueva", "CANTIDAD MAXIMA ALCANZADA", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
                        }
                        else
                            IngresarProdDesconocido();
                        break;

                    case 13:
                        IngresarPcioManual(e.RowIndex);
                        break;
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void IngresarPcioManual(int fila)
        {
            try
            {
                var frma3 = new frmIngPrecioManual();
                frma3.ShowDialog();
                var cmb = dgrDetalle.Rows[fila].Cells[8] as DataGridViewComboBoxCell;
                if (frma3.DialogResult == DialogResult.OK)
                {
                    var dt = new DataTable();
                    if (dgrDetalle["NroArt", fila].Value != null)
                    {
                        var productoNegocio = new ProductoNegocio();
                        dt = productoNegocio.CargarComboPrecios(Convert.ToInt32(dgrDetalle.Rows[fila].Cells[3].Value),
                                cmbTipoFac.Text);
                    }
                    else
                    {
                        dt.Columns.Add("Desc");
                        dt.Columns.Add("Precio");
                        DataRow rw2 = dt.NewRow();
                        rw2[0] = cmb.Value;
                        rw2[1] = cmb.Value;
                        dt.Rows.Add(rw2);
                    }
                    DataRow rw = dt.NewRow();
                    rw[0] = "Manual: $" + frma3.Pcio;
#pragma warning disable CS1690 // Accessing a member on 'frmIngPrecioManual.Pcio' may cause a runtime exception because it is a field of a marshal-by-reference class
                    rw[1] = frma3.Pcio.ToString();
#pragma warning restore CS1690 // Accessing a member on 'frmIngPrecioManual.Pcio' may cause a runtime exception because it is a field of a marshal-by-reference class
                    dt.Rows.Add(rw);
                    cmb.DataSource = dt;
                    cmb.DisplayMember = "Desc";
                    cmb.ValueMember = "Precio";
                    cmb.Value = dgrDetalle["NroArt", fila].Value != null ? dt.Rows[2]["Precio"] : dt.Rows[1]["Precio"];
                    dgrDetalle["PrecManual", fila].Value = 1;
                }
                else
                {
                    dgrDetalle["PrecManual", fila].Value = 0;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BuscarCliente(int nroCliente)
        {
            try
            {
                var clienteNegocio = new ClienteNegocio();
                VistaClientes cli = clienteNegocio.ObtenerVCliporNroCli(nroCliente);
                var aux = new AuxiliaresNegocio();
                if (cli != null)
                {
                    if (cli.FechaBaja == "")
                    {
                        IdCliente = cli.IdCliente;
                        lblNomreCliente.Text = cli.Nombre + " " + cli.Apellido;
                        lblNomreCliente.Visible = true;
                        txtNroCliente.Text = IdCliente.ToString();

                        if (cli.IdCliente == 1)
                        {
                            cmboFormaPago.SelectedValue = 1;
                            cmbCondPago.Enabled = false;
                        }
                        else
                        {
                            cmboFormaPago.SelectedValue = 2;
                            cmbCondPago.SelectedValue = 1;
                        }

                        dgrDetalle.Enabled = true;
                        txtNroCliente.Text = cli.IdCliente.ToString();
                        if (cli.Cuit != "")
                        {
                            lblNomreCliente.Text = "CUIT - " + cli.Cuit + " - " + cli.Nombre + " " + cli.Apellido + " (" + cli.Descripcion + ")";
                            cuit = cli.Cuit;
                        }
                        else
                        {
                            lblNomreCliente.Text = cli.TipoDocumento + " - " + cli.Nro_Doc + " - " + cli.Nombre + " " + cli.Apellido + " (" + cli.Descripcion + ")";
                            cuit = cli.Nro_Doc;
                        }
                        bool tipoA = false;
                        if (cli.Descripcion.ToUpper() != "RESPONSABLE INSCRIPTO") { cmbTipoFac.SelectedValue = "2"; } //tipo B
                        else
                        {
                            cmbTipoFac.SelectedValue = "1";
                            tipoA = true;
                        }
                        CambiarTipoFact();
                        if (dgrDetalle.Rows.Count > 1)
                        {
                            CambiarPrecios(true);
                            CalcularTotales(tipoA);
                        }
                        dgrDetalle.Enabled = true;
                    }
                    else { MessageBox.Show("El Cliente fue dado de baja", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); this.Close(); }
                }
                else
                {
                    MessageBox.Show("No se encontró el Cliente", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    IdCliente = 0;
                    lblNomreCliente.Visible = false;
                    dgrDetalle.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void CambiarPrecios(bool CambioCli)
        {
            try
            {
                foreach (DataGridViewRow rw in dgrDetalle.Rows)
                {
                    if (!rw.IsNewRow && rw.Cells["NroArt"].Value != null)
                    {
                        var cmb = rw.Cells["Precio"] as DataGridViewComboBoxCell;
                        var rep = new ProductoNegocio();
                        byte fPago = Convert.ToByte(cmboFormaPago.SelectedValue);
                        if (CambioCli)
                        {
                            DataTable dt = rep.CargarComboPrecios(Convert.ToInt32(rw.Cells["NroArt"].Value), cmbTipoFac.Text);
                            cmb.DataSource = dt;
                            //cmb.Value = fPago == 1 | chkSelContado.Checked ? dt.Rows[0]["Precio"] : dt.Rows[1]["Precio"];
                        }
                        else
                        {
                            PreciosVenta pv = rep.ObtenerUltPrecioVentaPorId(Convert.ToInt32(rw.Cells["NroArt"].Value));
                            cmb.Value = cmbTipoFac.Text == "A" ? Math.Round(pv.PrecioContado, 2, MidpointRounding.AwayFromZero) : Math.Round(pv.PrecioContadoIva, 2, MidpointRounding.AwayFromZero);
                        }
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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

        private void LlenarCombos()
        {
            var auxiliares = new AuxiliaresNegocio();
            Seteos seteos = auxiliares.ObtenerSeteo();
            cmbConcepto.DataSource = auxiliares.DtTiposConceptosFactura();
            cmbConcepto.DisplayMember = "Descripcion";
            cmbConcepto.ValueMember = "IdConceptoFactura";
            cmboFormaPago.DataSource = auxiliares.DtFormasPago();
            cmboFormaPago.DisplayMember = "Descripcion";
            cmboFormaPago.ValueMember = "IdFormaPago";
            cmboFormaPago.SelectedValue = 1;
            cmboFormaPago.Enabled = true;
            cmbTipoFac.DataSource = auxiliares.DtTiposFact();
            cmbTipoFac.DisplayMember = "Descripcion";
            cmbTipoFac.ValueMember = "IdTipoFactura";
            cmbTipoFac.SelectedValue = 2;
            dtpFechaVto.Value = DateTime.Now.AddDays((double)(seteos.DiasVtoFact ?? 15));
        }

        private void EliminarFila()
        {
            try
            {
                if (!dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex].IsNewRow)
                {
                    if (Accion.ToUpper() == "MOD")
                    {
                        if (dgrDetalle["IdFactVtaDetalle", dgrDetalle.SelectedCells[0].RowIndex].Value != null)
                        {
                            lint.Add(Convert.ToInt64(dgrDetalle["IdFactVtaDetalle", dgrDetalle.SelectedCells[0].RowIndex].Value));
                        }
                    }
                    dgrDetalle.Rows.RemoveAt(dgrDetalle.SelectedCells[0].RowIndex);
                    CalcularTotales(true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BuscarArtDgr()
        {
            try
            {
                if (dgrDetalle.Rows.Count > 15)
                {
                    MessageBox.Show("El máximo de líneas por factura es 15. Por favor elimine los restantes y haga una factura nueva", "CANTIDAD MAXIMA ALCANZADA", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                if (Convert.ToBoolean(dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex].Cells[12].Value) != false) return;
                var frm = new frmListaProductos { Seleccion = true };
                frm.ShowDialog();
                if (frm.DialogResult != DialogResult.OK || frm.IdProducto <= 0) return;
                BuscarArt(dgrDetalle.SelectedCells[0].RowIndex, frm.IdProducto, "");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void BuscarArt(int row, int idprod, string cb)
        {
            try
            {
                var productoNegocio = new ProductoNegocio();
                var prod = new VistaProducto();
                if (dgrDetalle.Rows.Count > 16)
                {
                    MessageBox.Show("El máximo de líneas por factura es 15. Por favor elimine los restantes y haga una factura nueva", "CANTIDAD MAXIMA ALCANZADA", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    if (idprod > 0)
                    {
                        prod = productoNegocio.ObtenerVistaProductoPorId(idprod);
                        if (prod == null)
                        {
                            MessageBox.Show("No se encontró el Producto", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                        if (prod.FechaBaja != "")
                        {
                            MessageBox.Show("El Producto fue dado de baja", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }

                    VistaPreciosVenta vpv = productoNegocio.ObtenerVistaUltVPV(prod.IdProducto);
                    if (vpv == null)
                    {
                        if (MessageBox.Show("El producto no tiene precios. Desea cargarlos?", "Producto sin Precios", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            var frmp = new frmPrecios(prod.IdProducto) { DeAfuera = true };
                            frmp.ShowDialog();
                            if (DialogResult != DialogResult.OK) { return; }
                            vpv = productoNegocio.ObtenerVistaUltVPV(prod.IdProducto);
                        }
                        else return;
                    }
                    foreach (DataGridViewRow rw in dgrDetalle.Rows)
                    {
                        if (rw.IsNewRow || row == rw.Index || Convert.ToInt32(rw.Cells[3].Value) != prod.IdProducto) continue;
                        MessageBox.Show("El producto ya fue ingresado al detalle", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                    dgrDetalle["NroArt", row].Value = prod.IdProducto.ToString();
                    dgrDetalle["DescCorta", row].Value = prod.DescCorta;
                    dgrDetalle["Cantidad", row].Selected = true;
                    dgrDetalle["UMedida", row].Value = prod.UnidadMedida;
                    dgrDetalle["Iva", row].Value = vpv.Iva;
                    var cmb = dgrDetalle["Precio", row] as DataGridViewComboBoxCell;
                    DataTable dt = productoNegocio.CargarComboPrecios(prod.IdProducto, cmbTipoFac.Text);
                    cmb.DataSource = dt;
                    cmb.DisplayMember = "Desc";
                    cmb.ValueMember = "Precio";
                    if (cmboFormaPago.SelectedValue.ToString() == "1") { cmb.Value = dt.Rows[0]["Precio"]; }
                    else { cmb.Value = dt.Rows[0]["Precio"]; }
                    if (Convert.ToDecimal(cmb.Value) == 0)
                    {
                        MessageBox.Show("El precio del producto es 0, modifíquelo antes de guardar el documento", "PRECIO CERO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dgrDetalle["Nueva", row].Value = true;
                    dgrDetalle["DesdeRem", row].Value = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void dgrDetalle_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (Accion == "VER" || siload || e.RowIndex <= -1) return;
                switch (e.ColumnIndex)
                {
                    case 3:
                        if (FuncionesForms.NroEneteroInt32(dgrDetalle[e.ColumnIndex, e.RowIndex].Value.ToString())) BuscarArt(e.RowIndex, Convert.ToInt32(dgrDetalle[e.ColumnIndex, e.RowIndex].Value), "");
                        else MessageBox.Show("Ingrese Nro.producto correcto", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;

                    case 5:
                        if (!artdesc)
                        {
                            if (!FuncionesForms.NroDecimal(dgrDetalle[e.ColumnIndex, e.RowIndex].Value.ToString()))
                            {
                                MessageBox.Show("Ingrese cantidad correcta", "Error de Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                dgrDetalle[e.ColumnIndex, e.RowIndex].Value = "";
                            }
                            else
                            {
                                var productoNegocio = new ProductoNegocio();
                                if (dgrDetalle[4, e.RowIndex].Value != null)
                                {
                                    CapaDatos.Modelos.Productos art = productoNegocio.ObtenerProductoPorId(Convert.ToInt32(dgrDetalle[3, e.RowIndex].Value));
                                    if (IdTipoDoc != 2)
                                    {
                                        if (art.LlevarStock)
                                        {
                                            if (Convert.ToDouble(dgrDetalle[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(".", ",")) > art.StockActual)
                                            {
                                                MessageBox.Show("No hay stock suficiente para este producto. ", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                            else if ((art.StockActual - Convert.ToDouble(dgrDetalle[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(".", ","))) < art.CantidadMinima)
                                            {
                                                MessageBox.Show("Se está superando la cantidad minima de Stock del producto", "ATENCIÓN!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                            }
                                        }
                                    }
                                }
                                var cmb = dgrDetalle.Rows[e.RowIndex].Cells[8] as DataGridViewComboBoxCell;
                                if (cmb.Value != null)
                                {
                                    if (FuncionesForms.NroDecimal(cmb.Value))
                                    {
                                        dgrDetalle[9, e.RowIndex].Value =
                                            Math.Round(Convert.ToDecimal(dgrDetalle[e.ColumnIndex, e.RowIndex].Value.ToString().Replace(".", ",")) * Convert.ToDecimal(cmb.Value), 2, MidpointRounding.AwayFromZero);
                                    }
                                }
                            }
                        }
                        break;

                    case 8:
                        var cmb2 = dgrDetalle.Rows[e.RowIndex].Cells[8] as DataGridViewComboBoxCell;
                        if (cmb2.Value != null)
                        {
                            if (dgrDetalle[5, e.RowIndex].Value != null)
                            {
                                if (FuncionesForms.NroDecimal(cmb2.Value) && FuncionesForms.NroDecimal(dgrDetalle[5, e.RowIndex].Value))
                                {
                                    dgrDetalle[9, e.RowIndex].Value = Math.Round(Convert.ToDecimal(dgrDetalle[5, e.RowIndex].Value.ToString().Replace(".", ",")) * Convert.ToDecimal(cmb2.Value), 2,
                                        MidpointRounding.AwayFromZero);
                                    // Se valida si se cambió el precio de manual a contado o fíado, para poner el valor de PrecManual en 0 (false).
                                    var formattedValue = dgrDetalle.Rows[e.RowIndex].Cells[9].FormattedValue;
                                    if (formattedValue != null && formattedValue.ToString().Substring(0, 1) != "M")
                                    {
                                        dgrDetalle["PrecManual", e.RowIndex].Value = 0;
                                    }
                                    else
                                    {
                                        dgrDetalle["PrecManual", e.RowIndex].Value = 1;
                                    }
                                }
                            }
                        }
                        break;

                    case 9:
                        if (FuncionesForms.NroDecimal(dgrDetalle[9, e.RowIndex].Value)) CalcularTotales(true);
                        break;
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void dgrDetalle_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    switch (dgrDetalle.SelectedCells[0].ColumnIndex)
                    {
                        case 0:
                            EliminarFila();
                            break;

                        case 1:
                            BuscarArtDgr();
                            break;

                        case 2:
                            if (dgrDetalle.Rows.Count > 15)
                            {
                                MessageBox.Show("El máximo de líneas por factura es 15. Por favor elimine los restantes y haga una factura nueva", "CANTIDAD MAXIMA ALCANZADA", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                            else IngresarProdDesconocido();

                            break;

                        case 13:
                            IngresarPcioManual(dgrDetalle.SelectedCells[0].RowIndex);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void dgrDetalle_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (dgrDetalle.SelectedCells[0].ColumnIndex - 1 == 6 && e.KeyCode == Keys.Tab &&
                    dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex].Cells["DescCorta"].Value != null && dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex].Cells["Cantidad"].Value != null)
                {
                    dgrDetalle[1, dgrDetalle.SelectedCells[0].RowIndex + 1].Selected = true;
                    BuscarArtDgr();
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }

        private void txtDto_Leave(object sender, EventArgs e)
        {
            try
            {
                if (FuncionesForms.NroDecimal(txtDto.Text)) CalcularTotales(false);
                else
                {
                    if (txtDto.Text == "") CalcularTotales(false);
                    else MessageBox.Show("Ingrese valor correcto para descuento", "Error de ingreso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDto.Text = 0.ToString();
                }
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

                FacturacionNegocio facturacionNegocio = new FacturacionNegocio();

                FacturasVenta fact = DatosCabecera();

                List<FacturasVentaDetalle> det = DatosDetalle();

                if (Accion.ToUpper() != "MOD")
                {
                    fact.TotalSaldado = fact.Total;
                    fact.UsrAcceso = "1";
                    if (IdTipoDoc == 2)
                    {
                        if (MessageBox.Show("¿Seguro que desea guardar una nota de crédito?", "GUARDAR NOTA DE CREDITO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            IdFact = facturacionNegocio.NuevaFact(fact, det, lrem, true, ListPre, auxiliaresNegocio.ObtenerEmpresa().IdEmpresa);
                        }
                    }
                    else if (Accion == "REMX") IdFact = facturacionNegocio.NuevaFactx(fact, det, lrem);
                    else
                    {
                        IdFact = facturacionNegocio.NuevaFact(fact, det, lrem, false, ListPre, auxiliaresNegocio.ObtenerEmpresa().IdEmpresa);

                    }

                    if (IdFact > 0)
                    {
                        if (IdTipoDoc == 8) //si es Remito X, imprimir
                        {
                            if (MessageBox.Show("Factura X cargado Correctamente, ¿desea imprimirlo?", "CARGA CORRECTA", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                ImpresionFacturaX();
                            }
                            string UltimoComp = facturacionNegocio.ObtenerUltimoNroCompRemitoX(auxiliaresNegocio.ObtenerEmpresa().IdEmpresa).PadLeft(8, '0');
                            txtBV.Text = UltimoComp.Substring(0, 4);
                            txtNroComp.Text = UltimoComp.Substring(5, 8);
                        }
                        else
                        {
                            if (GenerarFacturaElectronica())
                            {
                                if (MessageBox.Show("El Comprobante se ingresó correctamente." + Environment.NewLine + "Imprimir Comprobante?", "ALTA COMPROBANTE", MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Question) == DialogResult.Yes) ImprimirTicket();
                            }
                        }
                        Limpiar();
                        if (ListPre != null) ListPre.Clear();
                    }
                }
                else
                {
                    if (!facturacionNegocio.EditarFact(IdFact, fact, det, lint)) return;
                    if (MessageBox.Show("El Comprobante se actualizó correctamente." + Environment.NewLine + "Imprimir Comprobante?", "EDICIÓN COMPROBANTE", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question) == DialogResult.Yes) GenerarFacturaElectronica();
                    Close();
                }

                if (caja != null && fact.IdFormaPago == 1)
                {
                    var respuesta = MessageBox.Show("¿Tuvo que dar vuelto?", "Vuelto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    decimal vuelto = 0;
                    if (respuesta == DialogResult.Yes)
                    {
                        string input = Interaction.InputBox("Ingrese el monto de vuelto entregado:", "Vuelto", "0.00");

                        if (!decimal.TryParse(input, out vuelto))
                        {
                            MessageBox.Show("Monto de vuelto inválido.");
                            return;
                        }
                    }
                    decimal totalVenta = fact.Total;
                    decimal ingresoCaja = totalVenta;
                    cajaNegocio.EditarMontoCaja(totalVenta, vuelto, caja.IdCaja);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImpresionFacturaX()
        {
            try
            {
                var facturacionNegocio = new FacturacionNegocio();

                var factura = facturacionNegocio.ObtenerFactura(IdFact);
                if (factura != null)
                {
                    var factDetalle = facturacionNegocio.ObtenerDetalledeFacturaVta(IdFact);

                    if (factDetalle != null)
                    {
                        ImprimeFactura.ImprimeFacturaX(factura, factDetalle);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la factura.");
                }
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
                var ok = true;

                if (!FuncionesForms.NroEneteroInt32(txtNroCliente.Text))
                {
                    Error.SetError(txtNroCliente, "Seleccione un cliente");
                    ok = false;
                }
                else Error.SetError(txtNroCliente, "");

                if (IdCliente == 0)
                {
                    Error.SetError(txtNroCliente, "Seleccione un cliente");
                    ok = false;
                }
                else Error.SetError(txtNroCliente, "");


                if (dgrDetalle.Rows.Count > 21)
                {
                    MessageBox.Show(
                        @"El máximo de líneas por factura es 20. Por favor elimine los restantes y haga una factura nueva",
                        @"CANTIDAD MAXIMA ALCANZADA",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    ok = false;
                }

                var filasVacias = new List<DataGridViewRow>();
                foreach (DataGridViewRow r in dgrDetalle.Rows)
                {
                    if (r.IsNewRow) continue;
                    if (r.Cells["DescCorta"].Value == null) filasVacias.Add(r);
                }
                foreach (var r in filasVacias) dgrDetalle.Rows.Remove(r);

                if (dgrDetalle.RowCount == 1)
                {
                    MessageBox.Show("Debe ingresar al menos una fila en el detalle de la Factura", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }
                else Error.SetError(dgrDetalle, "");

                var HuboError = false;
                foreach (DataGridViewRow row in dgrDetalle.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (row.Cells["Total"].Value != null) continue;
                    Error.SetError(dgrDetalle, "Hay filas sin confirmar en el Detalle");
                    ok = false;
                    HuboError = true;
                }
                if (!HuboError) Error.SetError(dgrDetalle, "");

                foreach (DataGridViewRow row in dgrDetalle.Rows)
                {
                    if (row.IsNewRow) continue;
                    if (Convert.ToDecimal(row.Cells["Total"].Value) != 0) continue;
                    MessageBox.Show("Hay productos con monto total 0, modifíquelos o elimínelos", "ERROR TOTAL PRODUCTOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ok = false;
                }

                if (IdTipoDoc == 2)
                {
                    if (txtBVNC.Text != "" && txtNroFactNC.Text != "") return ok;
                    Error.SetError(txtNroFactNC, "Debe ingresar una factura asociada");
                    ok = false;
                }

                caja = cajaNegocio.ObtenerCajaActual();
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
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No se puede continuar sin abrir la caja. Operación cancelada.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                return ok;
            }
            catch (Exception ex) { throw new Exception($"Error : {ex.Message}", ex); }
        }

        private FacturasVenta DatosCabecera()
        {
            var facturacionNegocio = new FacturacionNegocio();

            var fact = new FacturasVenta
            {
                IdFormaPago = Convert.ToInt16(cmboFormaPago.SelectedValue),
                //IdCondicionPago = cmbFPago.SelectedValue.ToString() == "2" ? Convert.ToInt16(cmbCondPago.SelectedValue) : (Int16?)null,
                IdTipoDocumento = IdTipoDoc,
                IdTipoFactura = Convert.ToInt16(cmbTipoFac.SelectedValue),
                IdCliente = Convert.ToInt32(txtNroCliente.Text),
                //Observaciones = txtObservaciones.Text,
                Subtotal105 = decimal.Parse(lblSubTotal105.Text, CultureInfo.InvariantCulture),
                Subtotal21 = decimal.Parse(lblSubTotal21.Text, CultureInfo.InvariantCulture),
                SubTotal = decimal.Parse(lblSubTotal.Text, CultureInfo.InvariantCulture),
                Total = decimal.Parse(lblTotal.Text, CultureInfo.InvariantCulture),
                TotalDescuento = decimal.Parse(lblTotalDto.Text, CultureInfo.InvariantCulture),
                TotalDescuento105 = decimal.Parse(lblSubtDto105.Text, CultureInfo.InvariantCulture),
                TotalDescuento21 = decimal.Parse(lblSubtDto21.Text, CultureInfo.InvariantCulture),
                Descuento = decimal.Parse(txtDto.Text, CultureInfo.InvariantCulture),
                FechaEmision = dtpFecha.Value,
                FechaVencimiento = dtpFechaVto.Value,
                TotalIva105 = decimal.Parse(lblTotalIva105.Text, CultureInfo.InvariantCulture),
                TotalIva21 = decimal.Parse(lblTotalIva21.Text, CultureInfo.InvariantCulture),
                IdEmpresa = 1,
                IdConceptoFactura = Convert.ToInt32(cmbConcepto.SelectedValue),
                NroCompFactReferencia = txtNroFactNC.Text == "" ? null : txtNroFactNC.Text,
                BVReferencia = txtBVNC.Text == "" ? null : txtBVNC.Text,
                BVFact = txtBV.Text == "" ? null : txtBV.Text,
                Cobrador = false,
            };

            if (IdTipoDoc == 2 || IdTipoDoc == 3)
            {
                FacturasVenta factV = facturacionNegocio.ObtenerFacturasXNumFact(txtBVNC.Text, txtNroFactNC.Text, Convert.ToInt16(cmbTipoFac.SelectedValue));
                if (factV != null) fact.MoverStock = factV.MoverStock;
            }
            else fact.MoverStock = chkMoverStock.Checked;

            if (IdTipoDoc == 8 && Accion.ToUpper() == "ALTA")
            {
                string UltimoComp = facturacionNegocio.ObtenerUltimoNroCompRemitoX(auxiliaresNegocio.ObtenerEmpresa().IdEmpresa).PadLeft(8, '0');
                txtBV.Text = UltimoComp.Substring(0, 4);
                txtNroComp.Text = UltimoComp.Substring(5, 8);
                fact.BVFact = txtBV.Text.PadLeft(4, '0');
                fact.NCompFact = txtNroComp.Text.PadLeft(8, '0');
            }
            return fact;
        }

        private List<FacturasVentaDetalle> DatosDetalle()
        {
            var det = new List<FacturasVentaDetalle>();
            foreach (DataGridViewRow a in dgrDetalle.Rows)
            {
                if (!a.IsNewRow)
                {
                    var factdet = new FacturasVentaDetalle();
                    if (a.Cells["NroArt"].Value == null)
                    {
                        factdet.IdProducto = 0;
                        factdet.Producto = a.Cells[4].Value.ToString();
                        factdet.UMedida = a.Cells[6].Value.ToString();
                    }
                    else
                    {
                        factdet.IdProducto = Convert.ToInt32(a.Cells[3].Value);
                        factdet.Producto = a.Cells[4].Value.ToString();
                        factdet.UMedida = a.Cells[6].Value.ToString();
                    }
                    factdet.PrecioManual = Convert.ToBoolean(a.Cells[15].Value);
                    if (Convert.ToDecimal(a.Cells[7].Value) == 21) factdet.IdTipoIva = 1;
                    else if (Convert.ToDecimal(a.Cells[7].Value) == 0) factdet.IdTipoIva = 3;
                    else factdet.IdTipoIva = 2;

                    factdet.Cantidad = Convert.ToDecimal(a.Cells[5].Value.ToString().Replace(".", ","));
                    var cmb = a.Cells[8] as DataGridViewComboBoxCell;
                    factdet.PrecioUnitario = Math.Round(Convert.ToDecimal(cmb.Value), 2, MidpointRounding.AwayFromZero);
                    factdet.TotalArt = Convert.ToDecimal(a.Cells[9].Value);
                    factdet.DesdeRemito = Convert.ToBoolean(a.Cells[12].Value);
                    factdet.UsrAcceso = "maas";
                    if (a.Cells["IdFactVtaDetalle"].Value != null) factdet.IdFacturaVentaDetalle = Convert.ToInt64(a.Cells["IdFactVtaDetalle"].Value);
                    det.Add(factdet);
                }
            }
            return det;
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

        private void IngresarProdDesconocido()
        {
            try
            {
                var frma = new frmIngProdDesconocido { Compra = false };
                frma.ShowDialog();
                if (frma.DialogResult == DialogResult.OK)
                {
                    dgrDetalle.Rows.Add();
                    artdesc = true;
                    var auxiliares = new AuxiliaresNegocio();
                    TiposIva ti = auxiliares.ObtenerTipoIVAporId(frma.IdTipoIVa);
                    dgrDetalle["DescCorta", dgrDetalle.CurrentRow.Index - 1].Value = frma.Descripcion;
                    dgrDetalle["Cantidad", dgrDetalle.CurrentRow.Index - 1].Value = frma.Cantidad;
                    dgrDetalle["UMedida", dgrDetalle.CurrentRow.Index - 1].Value = frma.UMedida;
                    dgrDetalle["SiDesc", dgrDetalle.CurrentRow.Index - 1].Value = true;
                    dgrDetalle["Iva", dgrDetalle.CurrentRow.Index - 1].Value = ti.PorcentajeIVA;
                    var cmb = dgrDetalle["Precio", dgrDetalle.CurrentRow.Index - 1] as DataGridViewComboBoxCell;
                    var dt = new DataTable();
                    dt.Columns.Add("Desc");
                    dt.Columns.Add("Precio");
                    DataRow rw = dt.NewRow();
                    decimal PorcIva = Convert.ToDecimal(ti.PorcentajeIVA) / 100;
                    decimal precio;
                    if (cmbTipoFac.SelectedValue.ToString() == "1")
                    {
                        if (frma.PrecioFinal)
                        {
                            precio = Math.Round(frma.Precio / (PorcIva + 1), 2);

                        }
                        else precio = frma.Precio;
                    }
                    else
                    {
                        if (frma.PrecioFinal) precio = frma.Precio;
                        else
                        {
                            precio = Math.Round(frma.Precio + (frma.Precio * PorcIva), 2);
                        }
                    }
                    rw[0] = precio;
                    rw[1] = precio;
                    dt.Rows.Add(rw);
                    cmb.DataSource = dt;
                    cmb.DisplayMember = "Desc";
                    cmb.ValueMember = "Precio";
                    cmb.Value = dt.Rows[0]["Precio"];
                    dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex - 1].Cells[1].ReadOnly = true;
                    dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex - 1].Cells[2].ReadOnly = true;
                    dgrDetalle.Rows[dgrDetalle.SelectedCells[0].RowIndex - 1].Cells[4].ReadOnly = true;
                    artdesc = false;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
                this.Close();
                childForm.TopLevel = false;
                childForm.FormBorderStyle = FormBorderStyle.None;
                childForm.Dock = DockStyle.Fill;
                principal.pnlContenedorPrincipal.Controls.Add(childForm);
                principal.pnlContenedorPrincipal.Tag = childForm;
                childForm.BringToFront();
                childForm.Show();
            }


        }
        private void Limpiar()
        {
            cmbCondPago.SelectedValue = 1;
            cmbCondPago.Enabled = false;
            txtNroCliente.Text = "";
            lblNomreCliente.Text = "";
            cmboFormaPago.SelectedValue = 1;
            lblSubTotal.Text = "0";
            lblSubtDto.Text = "0";
            lblTotal.Text = "0";
            lblTotalDto.Text = "0";
            lblTotalIva105.Text = "0";
            lblTotalIva21.Text = "0";
            lblSubtDto105.Text = "0";
            lblSubtDto21.Text = "0";
            lblSubTotal105.Text = "0";
            lblSubTotal21.Text = "0";
            txtDto.Text = "0";
            lblTotalIVA.Text = "0";
            dgrDetalle.Rows.Clear();
            IdCliente = 1;
            chkMoverStock.Checked = false;

            BuscarCliente(IdCliente);

        }

        private bool GenerarFacturaElectronica()
        {
            bool resp = false;
            if (IdFact > 0)
            {
                var listado = new List<int>();

                listado.Add(Convert.ToInt32(IdFact));

                var frmc = new frmFacturaElectronica() { ListFacturas = listado, bocaVenta = "008" };

                frmc.ShowDialog();

                resp = true;
                //ImprimirTicket();
            }
            return resp;
        }

        private void ImprimirTicket()
        {
            try
            {
                var facturacionNegocio = new FacturacionNegocio();

                var factura = facturacionNegocio.ObtenerFactura(IdFact);
                if (factura != null)
                {
                    var factDetalle = facturacionNegocio.ObtenerDetalledeFacturaVta(IdFact);

                    if (factDetalle != null)
                    {
                        ImprimeFactura.ImprimeFacturaElec(factura, factDetalle);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la factura.");
                }
            }
            catch (Exception ex)
            {
                string mensajeError = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show(mensajeError);
            }
        }
    }
}
