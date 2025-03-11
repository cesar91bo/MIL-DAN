using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;

namespace CapaNegocio
{
    public class FacturacionNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public FacturasVenta ObtenerFactura(int idFact)
        {
            return db.FacturasVenta.SingleOrDefault(c => c.IdFacturaVenta == idFact);
        }

        public FacturasVenta ObtenerFacturasXNumFact(string NBVFact, string NroCompFact, short tipoFact) 
        { 
            return db.FacturasVenta.SingleOrDefault(c => c.BVFact == NBVFact && c.NCompFact == NroCompFact && c.IdTipoFactura == tipoFact); 
        }

        public string ObtenerUltimoNroCompRemitoX(short IdEmp)
        {
            var f = from v in db.FacturasVenta where v.IdEmpresa == IdEmp && v.IdTipoDocumento == 8 select v;
            if (f.Any())
            {
                FacturasVenta Ultimo = db.FacturasVenta.SingleOrDefault(c => c.IdFacturaVenta == f.Max(d => d.IdFacturaVenta));
                if (Ultimo.NCompFact == "99999999") return (Convert.ToInt64(Ultimo.BVFact) + 1).ToString().PadLeft(4, '0') + "-" + "00000001";
                return Ultimo.BVFact + "-" + (Convert.ToInt64(Ultimo.NCompFact) + 1).ToString().PadLeft(8, '0');
            }

            return "0001-00000001";
        }

        public int NuevaFact(FacturasVenta fact, List<FacturasVentaDetalle> det, List<int> nrorem, bool NC, List<int> ListPres, short idEmp)
        {
            try
            {
                int id;

                using (var trans = db.Database.BeginTransaction()) // Corrección: Usar DbContextTransaction
                {
                    try
                    {
                        var f = new FacturasVenta
                        {
                            BVFact = fact.BVFact,
                            NCompFact = fact.NCompFact,
                            IdCliente = fact.IdCliente,
                            Observaciones = fact.Observaciones,
                            FechaEmision = fact.FechaEmision,
                            FechaVencimiento = fact.FechaVencimiento,
                            Descuento = fact.Descuento,
                            IdFormaPago = fact.IdFormaPago,
                            IdTipoDocumento = fact.IdTipoDocumento,
                            IdTipoFactura = fact.IdTipoFactura,
                            SubTotal = fact.SubTotal,
                            Subtotal105 = fact.Subtotal105,
                            Subtotal21 = fact.Subtotal21,
                            Total = fact.Total,
                            Impresa = false,
                            TotalDescuento105 = fact.TotalDescuento105,
                            TotalDescuento21 = fact.TotalDescuento21,
                            TotalDescuento = fact.TotalDescuento,
                            UsrAcceso = fact.UsrAcceso,
                            TotalIva21 = fact.TotalIva21,
                            TotalIva105 = fact.TotalIva105,
                            IdEmpresa = fact.IdEmpresa,
                            TotalSaldado = fact.TotalSaldado,
                            TotalInteres = 0,
                            TotalSaldadoInteres = 0,
                            IdConceptoFactura = fact.IdConceptoFactura,
                            FechaAlta = DateTime.Now,
                            Cobrador = false,
                            MoverStock = fact.MoverStock,
                            NombreMaquina = Environment.MachineName
                        };

                        if (f.IdTipoDocumento == 2 || f.IdTipoDocumento == 3)
                        {
                            f.BVReferencia = fact.BVReferencia;
                            f.NroCompFactReferencia = fact.NroCompFactReferencia;
                        }

                        AgregarFactura(f);
                        db.SaveChanges();

                        foreach (FacturasVentaDetalle a in det)
                        {
                            a.IdFacturaVenta = f.IdFacturaVenta;
                            if (string.IsNullOrEmpty(a.Producto)) a.Producto = null;
                            if (string.IsNullOrEmpty(a.UMedida)) a.UMedida = null;
                            if (a.IdProducto == 0) a.IdProducto = null;

                            AgregarFactDetalle(a);

                            if (a.IdProducto != null && nrorem == null && f.MoverStock == false)
                            {
                                var productoNegocio = new ProductoNegocio();
                                if (!NC)
                                {
                                    if (!productoNegocio.RestarStockArt(Convert.ToDouble(a.Cantidad), Convert.ToInt32(a.IdProducto)))
                                        throw new Exception("Error en la actualización de Stock");
                                }
                                else if (!productoNegocio.SumarStockArt(Convert.ToDouble(a.Cantidad), Convert.ToInt32(a.IdProducto)))
                                {
                                    throw new Exception("Error en la actualización de Stock");
                                }
                            }
                        }

                        if (nrorem != null && nrorem.Count > 0)
                        {
                            foreach (int r in nrorem)
                            {
                                var remitosNegocio = new RemitosNegocio();
                                if (!remitosNegocio.EditarNroFact(r, f.IdFacturaVenta, idEmp))
                                    throw new Exception("Error en la actualización de NroFact en Remito");
                            }
                        }

                        db.SaveChanges();
                        trans.Commit();
                        id = f.IdFacturaVenta;
                    }
                    catch (Exception)
                    {
                        trans.Rollback();
                        throw;
                    }
                }

                return id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool EditarFact(int IdFact, FacturasVenta Fact, List<FacturasVentaDetalle> det, List<long> Intartborrar)
        {
            try
            {
                db.Database.Connection.Open();
                DbTransaction trans = db.Database.Connection.BeginTransaction();
                try
                {
                    FacturasVenta fv = ObtenerFactura(IdFact);
                    fv.FechaEmision = Fact.FechaEmision;
                    fv.FechaVencimiento = Fact.FechaVencimiento;
                    fv.BVReferencia = Fact.BVReferencia;
                    fv.NroCompFactReferencia = Fact.NroCompFactReferencia;
                    fv.IdFormaPago = Fact.IdFormaPago;
                    fv.IdTipoFactura = Fact.IdTipoFactura;
                    fv.IdCliente = Fact.IdCliente;
                    fv.Observaciones = Fact.Observaciones;
                    fv.Descuento = Fact.Descuento;
                    fv.SubTotal = Fact.SubTotal;
                    fv.Subtotal105 = Fact.Subtotal105;
                    fv.Subtotal21 = Fact.Subtotal21;
                    fv.Total = Fact.Total;
                    fv.TotalDescuento = Fact.TotalDescuento;
                    fv.TotalDescuento105 = Fact.TotalDescuento105;
                    fv.TotalDescuento21 = Fact.TotalDescuento21;
                    fv.TotalIva21 = Fact.TotalIva21;
                    fv.TotalIva105 = Fact.TotalIva105;
                    fv.IdEmpresa = Fact.IdEmpresa;
                    fv.BVReferencia = Fact.BVReferencia;
                    fv.NroCompFactReferencia = Fact.NroCompFactReferencia;
                    fv.IdConceptoFactura = Fact.IdConceptoFactura;
                    fv.Cobrador = Fact.Cobrador;
                    fv.MoverStock = Fact.MoverStock;
                    //Pasamos el nombre de la máquina para saber desde cuál se cargó. Se agrega para detectar si los comprobantes repetidos vienen por
                    //un problema en una de las PC's que funcionaba mal.
                    fv.NombreMaquina = Environment.MachineName;
                    db.SaveChanges();

                    if (Intartborrar.Count > 0)
                        foreach (long id in Intartborrar)
                        {
                            FacturasVentaDetalle detalle = ObtenerFacturaVentaDetalle(id);
                            var productoNegocio = new ProductoNegocio();
                            if (detalle.IdProducto != null)
                                if (fv.MoverStock == false)
                                    if (productoNegocio.SumarStockArt(Convert.ToDouble(detalle.Cantidad), Convert.ToInt32(detalle.IdProducto)) == false)
                                        throw new Exception("Error en la actualización de Stock");
                            BorrarDetalle(detalle);
                        }

                    var anterior = ObtenerDetalledeFacturaVta(IdFact);
                    foreach (FacturasVentaDetalle d in det)
                    {
                        var linea = new FacturasVentaDetalle();
                        linea = d.IdFacturaVentaDetalle != 0 ? anterior.Find(c => c.IdFacturaVentaDetalle == d.IdFacturaVentaDetalle) : null;
                        if (d.IdProducto == 0) d.IdProducto = null;
                        if (linea != null)
                        {
                            FacturasVentaDetalle fvd = ObtenerFacturaVentaDetalle(linea.IdFacturaVentaDetalle);
                            if (linea.Cantidad != d.Cantidad)
                            {
                                if (d.IdProducto != null)
                                    if (fv.MoverStock == false)
                                    {
                                        var productoNegocio = new ProductoNegocio();
                                        if (productoNegocio.RestarStockArt(Convert.ToDouble(d.Cantidad - linea.Cantidad), Convert.ToInt32(linea.IdProducto)) == false) throw new Exception("Error en la actualización de Stock");
                                    }

                                fvd.Cantidad = linea.Cantidad + (d.Cantidad - linea.Cantidad);
                            }

                            fvd.PrecioUnitario = d.PrecioUnitario;
                            fvd.IdTipoIva = d.IdTipoIva;
                            fvd.TotalArt = d.TotalArt;
                            db.SaveChanges();

                            FacturasVentaDetalle fvde = ObtenerFacturaVentaDetalle(linea.IdFacturaVentaDetalle);
                            fvde.PrecioManual = d.PrecioManual;
                            db.SaveChanges();
                        }
                        else
                        {
                            d.IdFacturaVenta = IdFact;
                            AgregarFactDetalle(d);
                            if (d.IdProducto != null)
                                if (fv.MoverStock == false)
                                {
                                    var productoNegocio = new ProductoNegocio();
                                    if (productoNegocio.RestarStockArt(Convert.ToDouble(d.Cantidad), Convert.ToInt32(d.IdProducto)) == false) throw new Exception("Error en la actualización de Stock");
                                }

                            db.SaveChanges();
                        }
                    }
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
                finally
                {
                    if (db.Database.Connection.State == ConnectionState.Open) db.Database.Connection.Close();
                }

                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void AgregarFactura(FacturasVenta fact) { db.FacturasVenta.Add(fact); }

        private void AgregarFactDetalle(FacturasVentaDetalle detalle) { db.FacturasVentaDetalle.Add(detalle); }

        public bool EditarNroFact(int idrem, int nrofact, Int16 IdEmp)
        {
            try
            {
                Remitos rem = db.Remitos.FirstOrDefault(c => c.IdRemito == idrem && c.IdEmpresa == IdEmp);

                if (rem == null)
                {
                    return false; // No se encontró el remito
                }

                rem.IdFactura = nrofact == 0 ? (int?)null : nrofact; // Asigna null si nrofact es 0

                db.SaveChanges(); // Guarda los cambios en la base de datos

                return true;
            }
            catch (Exception)
            {
                throw; // Mantiene la pila de excepciones original
            }
        }

        public int NuevaFactx(FacturasVenta fact, List<FacturasVentaDetalle> det, List<int> lrem)
        {
            try
            {
                int id;
                db.Database.Connection.Open();
                DbTransaction trans = db.Database.Connection.BeginTransaction();
                try
                {
                    fact.Cobrador = false;
                    fact.FechaAlta = DateTime.Now;
                    //Pasamos el nombre de la máquina para saber desde cuál se cargó. Se agrega para detectar si los comprobantes repetidos vienen por
                    //un problema en una de las PC's que funcionaba mal.
                    fact.NombreMaquina = Environment.MachineName;
                    AgregarFactura(fact);
                    db.SaveChanges();
                    foreach (FacturasVentaDetalle a in det)
                    {
                        a.IdFacturaVenta = fact.IdFacturaVenta;
                        if (a.Producto == "") a.Producto = null;
                        if (a.UMedida == "") a.UMedida = null;
                        if (a.IdProducto == 0) a.IdProducto = null;
                        AgregarFactDetalle(a);
                        if (a.IdProducto == null || lrem != null) continue;
                        var productoNegocio = new ProductoNegocio();
                        if (productoNegocio.RestarStockArt(Convert.ToDouble(a.Cantidad), Convert.ToInt32(a.IdProducto)) == false) throw new Exception("Error en la actualización de Stock");
                    }

                    id = fact.IdFacturaVenta;
                    foreach (int r in lrem)
                    {
                        var repv = new FacturacionNegocio();
                        FacturasVenta remx = repv.ObtenerFactura(r);
                        var rem = new RemitosXfacturados { IdFacturaVenta = remx.IdFacturaVenta, IdFacturaFinal = id };
                        db.RemitosXfacturados.Add(rem);
                        db.SaveChanges();
                    }

                    db.SaveChanges();
                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
                finally
                {
                    if (db.Database.Connection.State == ConnectionState.Open) db.Database.Connection.Close();
                }

                return id;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<FacturasVentaDetalle> ObtenerFacturaVentaDetallexTipoIvayNroFact(int IdFact, int IdTipoIva)
        {
            var detalle = from f in db.FacturasVentaDetalle where IdFact == f.IdFacturaVenta && f.IdTipoIva == IdTipoIva select f;
            return detalle.ToList();
        }

        private FacturasVentaDetalle ObtenerFacturaVentaDetalle(long id) 
        { 
            return db.FacturasVentaDetalle.SingleOrDefault(c => c.IdFacturaVentaDetalle == id); 
        }

        private void BorrarDetalle(FacturasVentaDetalle det)
        {
            try
            {
                db.FacturasVentaDetalle.Remove(det);
                db.SaveChanges();
            }
            catch (Exception ex) { throw ex; }
        }

        public List<FacturasVentaDetalle> ObtenerDetalledeFacturaVta(int IdFact)
        {
            var det = from d in db.FacturasVentaDetalle where d.IdFacturaVenta == IdFact select d;
            return det.ToList();
        }

        public List<VistaCabFactVenta> ObtenerListaFacturas(string fechadf, string fechahf, string clientefact)
        {
            var facturas = db.VistaCabFactVenta.AsQueryable();

            if (!string.IsNullOrEmpty(fechadf) && DateTime.TryParse(fechadf, out DateTime fechaDesde))
            {
                facturas = facturas.Where(f => f.FechaEmision >= fechaDesde);
            }

            if (!string.IsNullOrEmpty(fechahf) && DateTime.TryParse(fechahf, out DateTime fechaHasta))
            {
                facturas = facturas.Where(f => f.FechaEmision <= fechaHasta);
            }

            if (!string.IsNullOrEmpty(clientefact))
            {
                facturas = facturas.Where(f => f.Cliente.Contains(clientefact));
            }

            return facturas.ToList();
        }
    }
}
