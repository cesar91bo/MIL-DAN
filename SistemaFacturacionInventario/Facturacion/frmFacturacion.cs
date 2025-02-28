using CapaDatos.Modelos;
using CapaNegocio;
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
        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {
            try
            {
                SaldoCtaCte = 0;
                //LlenarCombos();

                AuxiliaresNegocio auxiliares = new AuxiliaresNegocio();
                Seteos seteos = auxiliares.ObtenerSeteos();

                if (seteos.DiasVtoFact > 0) dtpFechaVto.Value = DateTime.Today.AddDays(Convert.ToInt32(seteos.DiasVtoFact));

                if (Accion.ToUpper() == "MOD")
                {
                   // if (IdFact > 0) ConsultarFact(IdFact);
                    if (Accion.ToUpper() == "MOD") lint = new List<Int64>();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //    private void ConsultarFact(int idFact)
        //    {
        //        try
        //        {
        //            var facturacionNegocio = new FacturacionNegocio();
        //            FacturasVenta fv = facturacionNegocio .ObtenerFactura(idFact);
        //            int f = 0;

        //            txtNroCliente.Text = fv.IdCliente.ToString();
        //            BuscarCli(fv.IdCliente);
        //            cmboFormaPago.SelectedValue = fv.IdFormaPago;
        //            if (cmboFormaPago.SelectedValue.ToString() == "2")
        //            {
        //                cmbCondPago.Visible = true;
        //                LlenarComboCond();
        //                cmbCondPago.SelectedValue = fv.IdCondicionPago;
        //            }
        //            if (!string.IsNullOrEmpty(fv.BVFact) && IdTipoDoc != 8) { txtBV.Text = fv.BVFact; }
        //            if (IdTipoDoc == 2 || IdTipoDoc == 3)
        //            {
        //                txtBVNC.Text = fv.BVReferencia;
        //                txtNroFactNC.Text = fv.NroCompFactReferencia;
        //            }
        //            if (IdTipoDoc == 8)
        //            {
        //                txtNroComp.Text = fv.NCompFact;
        //                btnImprimir.Visible = true;
        //            }
        //            FacturasVenta fact = repv.ObtenerFactura(lrem[0]);//agregado
        //            txtObservaciones.Text = fact.Observaciones;
        //            foreach (Int32 r in lrem)
        //            {
        //                List<VistaDetalleFactVenta> detrem = repv.ObtenerVistaDetalledeFacturaVta(r);
        //                FacturasVenta rem = repv.ObtenerFactura(r);
        //                txtDto.Text = rem.Descuento.ToString();
        //                dgrDetalle.Rows.Add(detrem.Count);

        //                if (!set.UsarCF)
        //                {
        //                    txtNroComp.Visible = true;
        //                    txtBV.Visible = true;
        //                    txtBV.Text = fv.BVFact;
        //                    txtNroComp.Text = fv.NCompFact;
        //                }
        //                else
        //                {
        //                    if (fv.Impresa)
        //                    {
        //                        lblImpresa.Text = "La factura ya fue impresa";
        //                        txtNroComp.Text = fv.NCompFact;
        //                        txtBV.Text = fv.BVFact;
        //                        txtNroComp.Visible = true;
        //                        txtBV.Visible = true;
        //                    }
        //                    else if (IdTipoDoc != 8) lblImpresa.Text = "La factura está pendiente de impresión";
        //                }

        //                if (cmbTipoFact.Text == "B")
        //                {
        //                    lbllblIVA21.Visible = false;
        //                    lbllblSubtDto.Visible = false;
        //                    lbllblSubTotaldto105.Visible = false;
        //                    lbllblSubTotaldto21.Visible = false;
        //                    lbllblSubTotal21.Visible = false;
        //                    lbllblSubTotal105.Visible = false;
        //                    lbllblIVA105.Visible = false;
        //                    lbllblIVA.Visible = false;
        //                    lblSubtDto105.Visible = false;
        //                    lblSubtDto21.Visible = false;
        //                    lblSubTotal105.Visible = false;
        //                    lblSubTotal21.Visible = false;
        //                    lblSubtDto.Visible = false;
        //                    lblTotalIva21.Visible = false;
        //                    lblTotalIVA.Visible = false;
        //                    lblTotalIva105.Visible = false;
        //                }
        //                else
        //                {
        //                    lblSubtDto.Text = Math.Round(Convert.ToDecimal(lblSubtDto105.Text) + Convert.ToDecimal(lblSubtDto21.Text), 2, MidpointRounding.AwayFromZero).ToString();
        //                    lblTotalIVA.Text = Math.Round(Convert.ToDecimal(lblTotalIva21.Text) + Convert.ToDecimal(lblTotalIva105.Text), 2, MidpointRounding.AwayFromZero).ToString();
        //                }
        //                if (Accion.ToUpper() == "VER") btnGuardar.Visible = false;

        //                List<FacturasVentaDetalle> det = repv.ObtenerDetalledeFacturaVta(Id);
        //                int i = 0;
        //                foreach (FacturasVentaDetalle fvd in det)
        //                {

        //                    var cmb = dgrDetalle["Precio", i] as DataGridViewComboBoxCell;
        //                    var dt = new DataTable();
        //                    if (fvd.IdArticulo != null)
        //                    {
        //                        var repa = new RepositorioArticulos();
        //                        VistaArticulos art = repa.ObtenerVArtporId(Convert.ToInt64(fvd.IdArticulo));
        //                        dgrDetalle.Rows[i].Cells[3].Value = art.CodigoBarra;
        //                        dgrDetalle.Rows[i].Cells[4].Value = art.IdArticulo.ToString();
        //                        dgrDetalle.Rows[i].Cells[5].Value = art.DescCorta;
        //                        dgrDetalle.Rows[i].Cells[7].Value = art.UnidadMedida;

        //                        dt = SeteosStatic.Usar4DigitosPrecios ? repa.CargarComboPrecios4digitos(art.IdArticulo, cmbTipoFact.Text) : repa.CargarComboPrecios2digitos(art.IdArticulo, cmbTipoFact.Text);

        //                        cmb.DataSource = dt;
        //                        cmb.DisplayMember = "Desc";
        //                        cmb.ValueMember = "Precio";
        //                        dgrDetalle.Rows[i].Cells[12].Value = false;

        //                        if (Convert.ToBoolean(fvd.PrecioManual))
        //                        {
        //                            var rw = dt.NewRow();
        //                            rw[0] = "Manual: $" + fvd.PrecioUnitario.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
        //                            rw[1] = fvd.PrecioUnitario.ToString(CultureInfo.InvariantCulture).Replace(".", ",");
        //                            dt.Rows.Add(rw);
        //                            cmb.DataSource = dt;
        //                            cmb.DisplayMember = "Desc";
        //                            cmb.ValueMember = "Precio";
        //                        }

        //                        cmb.Value = fvd.PrecioManual == false ? dt.Rows[0]["Precio"] : dt.Rows[2]["Precio"];
        //                    }
        //                    else
        //                    {
        //                        dgrDetalle.Rows[i].Cells[5].Value = fvd.Articulo;
        //                        dgrDetalle.Rows[i].Cells[7].Value = fvd.UMedida;
        //                        dt.Columns.Add("Desc");
        //                        dt.Columns.Add("Precio");
        //                        DataRow rw = dt.NewRow();
        //                        rw[0] = "$ " + fvd.PrecioUnitario;
        //                        rw[1] = fvd.PrecioUnitario;
        //                        dt.Rows.Add(rw);
        //                        cmb.DataSource = dt;
        //                        cmb.DisplayMember = "Desc";
        //                        cmb.ValueMember = "Precio";
        //                        cmb.Value = dt.Rows[0]["Precio"];
        //                        dgrDetalle.Rows[i].Cells[12].Value = true;
        //                        artdesc = true;
        //                    }

        //                    dgrDetalle.Rows[i].Cells[6].Value = fvd.Cantidad;
        //                    dgrDetalle["Total", i].Value = Math.Round(fvd.Cantidad * Convert.ToDecimal(cmb.Value), 2, MidpointRounding.AwayFromZero);
        //                    var repax = new RepositorioAuxiliares();
        //                    TiposIva ti = repax.ObtenerTipoIVAporId(fvd.IdTipoIva);
        //                    dgrDetalle.Rows[i].Cells[8].Value = ti.PorcentajeIVA;
        //                    dgrDetalle.Rows[i].Cells[11].Value = false;
        //                    dgrDetalle.Rows[i].Cells["IdFactVtaDetalle"].Value = fvd.IdFacturaVentaDetalle;
        //                    i += 1;
        //                    artdesc = false;

        //                IdTipoDoc = fv.IdTipoDocumento;
        //                if (IdTipoDoc == 8) btnImprimir.Visible = true;
        //                CalcularTotales(true);
        //            }
        //        }
        //        catch (Exception ex) { throw ex; }
        //    }

        //    private void BuscarCli(object nroCliente)
        //    {
        //        var repc = new RepositorioClientes();
        //        try
        //        {
        //            VistaClientes cli = repc.ObtenerVCliporNroCli(IdCliente);
        //            if (cli != null)
        //            {
        //                Activar(true);
        //                if (cli.FechaBaja == "")
        //                {
        //                    //List<VistaFacturasSinSaldar> Lista = repv.ObtenerListFacturasVencidas30DiasxNroCli(SeteosStatic.IdEmpresa, idcli);
        //                    if (cli.IdCliente == 1)
        //                    {
        //                        cmboFormaPago.SelectedValue = 1;
        //                        cmbCondPago.Enabled = false;
        //                    }
        //                    else
        //                    {
        //                        cmbFPago.SelectedValue = 2;
        //                        cmbCondPago.SelectedValue = 1;
        //                    }
        //                    var Lista = new List<Clientes>();
        //                    if (Lista.Count > 0 && Accion.ToUpper() == "ALTA" && idcli > 1)
        //                    {
        //                        if (MessageBox.Show("El Cliente posee facturas impagas de más de 30 días, ¿Desea facturar igual?", "AVISO IMPORTANTE", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //                        {
        //                            dgrDetalle.Enabled = true;
        //                            txtNroCli.Text = cli.NroCliente.ToString();
        //                            if (cli.Cuit != "")
        //                            {
        //                                lblCliente.Text = "CUIT - " + cli.Cuit + " - " + cli.ApellidoyNombre + " (" + cli.Descripcion + ")";
        //                                cuit = cli.Cuit;
        //                            }
        //                            else
        //                            {
        //                                lblCliente.Text = cli.TipoDocumento + " - " + cli.Nro_Doc + " - " + cli.ApellidoyNombre + " (" + cli.Descripcion + ")";
        //                                cuit = cli.Nro_Doc;
        //                            }
        //                            bool tipoA = false;
        //                            if (cli.Descripcion.ToUpper() != "RESPONSABLE INSCRIPTO") { cmbTipoFact.SelectedValue = "2"; } //tipo B
        //                            else
        //                            {
        //                                cmbTipoFact.SelectedValue = "1";
        //                                tipoA = true;
        //                            }
        //                            CambiarTipoFact();
        //                            if (dgrDetalle.Rows.Count > 1)
        //                            {
        //                                CambiarPrecios(true);
        //                                CalcularTotales(tipoA);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            idcli = 0;
        //                            txtNroCli.Text = "0";
        //                            lblCliente.Text = "";
        //                        }
        //                    }
        //                    else
        //                    {
        //                        dgrDetalle.Enabled = true;
        //                        txtNroCli.Text = cli.NroCliente.ToString();
        //                        if (cli.Cuit != "")
        //                        {
        //                            lblCliente.Text = "CUIT - " + cli.Cuit + " - " + cli.ApellidoyNombre + " (" + cli.Descripcion + ")";
        //                            cuit = cli.Cuit;
        //                        }
        //                        else
        //                        {
        //                            lblCliente.Text = cli.TipoDocumento + " - " + cli.Nro_Doc + " - " + cli.ApellidoyNombre + " (" + cli.Descripcion + ")";
        //                            cuit = cli.Nro_Doc;
        //                        }
        //                        bool tipoA = false;
        //                        if (cli.Descripcion.ToUpper() != "RESPONSABLE INSCRIPTO") { cmbTipoFact.SelectedValue = "2"; } //tipo B
        //                        else
        //                        {
        //                            cmbTipoFact.SelectedValue = "1";
        //                            tipoA = true;
        //                        }
        //                        CambiarTipoFact();
        //                        if (dgrDetalle.Rows.Count > 1)
        //                        {
        //                            CambiarPrecios(true);
        //                            CalcularTotales(tipoA);
        //                        }
        //                    }
        //                }
        //                else
        //                {
        //                    MessageBox.Show("El cliente fue dado de baja", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                    Activar(false);
        //                }
        //            }
        //            else
        //            {
        //                MessageBox.Show("No se encontró el Cliente", "Error de Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //                Activar(false);
        //            }
        //        }
        //        catch (Exception ex) { throw ex; }
        //    }

        //    private void LlenarCombos()
        //    {
        //        var auxiliares = new AuxiliaresNegocio();
        //        cmbConcepto.DataSource = auxiliares.DtTiposConceptosFactura();
        //        cmbConcepto.DisplayMember = "Descripcion";
        //        cmbConcepto.ValueMember = "IdConceptoFactura";
        //        cmboFormaPago.DataSource = auxiliares.DtFormasPago();
        //        cmboFormaPago.DisplayMember = "Descripcion";
        //        cmboFormaPago.ValueMember = "IdFormaPago";
        //        cmboFormaPago.SelectedValue = 2;
        //        cmboFormaPago.Enabled = true;
        //        cmbCondPago.SelectedValue = 1;
        //        cmbCondPago.Enabled = true;
        //        cmbTipoFac.DataSource = auxiliares.DtTiposFact();
        //        cmbTipoFac.DisplayMember = "Descripcion";
        //        cmbTipoFac.ValueMember = "IdTipoFactura";
        //        cmbCondPago.Enabled = false;
        //    }

        //    private void LlenarComboCond()
        //    {
        //        try
        //        {
        //            var rep = new AuxiliaresNegocio();
        //            cmbCondPago.DisplayMember = "Descripcion";
        //            cmbCondPago.ValueMember = "IdCondicionPago";
        //            cmbCondPago.DataSource = rep.DtCondPago();
        //            cmbCondPago.Enabled = true;
        //        }
        //        catch (Exception ex) { throw ex; }
        //    }
    }
}
