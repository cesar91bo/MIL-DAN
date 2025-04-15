using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Cryptography;

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();
        private Logger logger = new Logger();
        public int AgregarNroProducto()
        {
            return (db.Productos.OrderByDescending(p => p.NroProducto).FirstOrDefault()?.NroProducto ?? 0) + 1;

        }

        public bool EditarProducto(Productos producto, int idProducto)
        {
            try
            {
                Productos productoBD = ObtenerProductoPorId(idProducto);
                productoBD.DescCorta = producto.DescCorta;
                productoBD.DescLarga = producto.DescLarga;
                productoBD.CantidadMinima = producto.CantidadMinima;
                productoBD.IdRubro = producto.IdRubro;
                productoBD.IdUnidadMedida = producto.IdUnidadMedida;
                productoBD.LlevarStock = producto.LlevarStock;
                productoBD.StockActual = producto.StockActual;
                productoBD.Embalaje = producto.Embalaje;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "EditarProducto", ex);
                throw new Exception("Ocurrió un error al editar producto. Contacte al soporte técnico.", ex);
            }
        }

        public int NuevoProducto(Productos producto)
        {
            try
            {
                decimal cantidadDeStock = 0;
                if (producto.LlevarStock)
                {
                    //Se pone articulo.StockActual en 0 para poder agregar el ajuste de stock y que el stock real no se duplique
                    cantidadDeStock = Convert.ToDecimal(producto.StockActual);
                    producto.StockActual = 0;
                }
                AgregarProducto(producto);
                db.SaveChanges();
                if (producto.IdProducto <= 0 || !producto.LlevarStock) return producto.IdProducto;
                var aj = new AjustesStock
                {
                    Cantidad = Convert.ToDecimal(cantidadDeStock),
                    FechaAjuste = DateTime.Now,
                    IdProducto = producto.IdProducto,
                    Motivo = "Stock Inicial del Producto",
                    FechaAcceso = DateTime.Now
                };
                NuevoAjuste(aj);
                return producto.IdProducto;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "NuevoProducto", ex);
                throw new Exception("Ocurrió un error al insertar producto. Contacte al soporte técnico.", ex);
            }
        }

        public bool NuevoAjuste(AjustesStock aj)
        {
            try
            {
                using (var db = new SistemaGestionPymeBDEntities())
                {
                    using (var trans = db.Database.BeginTransaction())
                    {
                        try
                        {
                            db.AjustesStock.Add(aj);
                            db.SaveChanges();

                            if (aj.Cantidad > 0)
                            {
                                SumarStockArt(Convert.ToDouble(aj.Cantidad), aj.IdProducto);
                            }
                            else
                            {
                                RestarStockArt(Convert.ToDouble(-aj.Cantidad), aj.IdProducto);
                            }

                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }
                return true;

            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "NuevoAjuste", ex);
                throw new Exception("Ocurrió un error al insertar ajuste. Contacte al soporte técnico.", ex);
            }
        }

        private void AgregarProducto(Productos producto)
        {
            db.Productos.Add(producto);
        }

        public Productos ObtenerProductoPorId(int idProducto)
        {
            return db.Productos.SingleOrDefault(c => c.IdProducto == idProducto);
        }

        public VistaProducto ObtenerVistaProductoPorId(int idProducto)
        {
            return db.VistaProducto.SingleOrDefault(c => c.IdProducto == idProducto);
        }

        public bool SumarStockArt(double cantidad, int idProducto)
        {
            try
            {
                var producto = ObtenerProductoPorId(idProducto);
                if (producto.LlevarStock)
                {
                    producto.StockActual = producto.StockActual + cantidad;
                    producto.UltimaActStock = DateTime.Now;
                }
                else { return true; }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "SumarStockArt", ex);
                throw new Exception("Ocurrió un error al sumar stock de producto. Contacte al soporte técnico.", ex);
            }
        }

        public bool RestarStockArt(double cantidad, int idProducto)

        {
            try
            {
                var producto = ObtenerProductoPorId(idProducto);
                if (producto.LlevarStock)
                {
                    producto.StockActual = producto.StockActual - cantidad;
                    producto.UltimaActStock = DateTime.Now;
                }
                else { return true; }
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "RestarStockArt", ex);
                throw new Exception("Ocurrió un error al restar stock de producto. Contacte al soporte técnico.", ex);
            }
        }

        public bool BajaProducto(int idProducto)
        {
            try
            {
                var art = ObtenerProductoPorId(idProducto);
                art.FechaBaja = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "BajaProducto", ex);
                throw new Exception("Ocurrió un error al eliminar un producto. Contacte al soporte técnico.", ex);
            }
        }

        public List<VistaProducto> ObtenerTodo()
        {
            var productos = from prod in db.VistaProducto
                            select prod;
            return productos.OrderBy(c => c.IdProducto).ToList();

        }

        public List<VistaProducto> ObtenerProductosActivos()
        {
            var productos = from prod in db.VistaProducto
                            where prod.FechaBaja == ""
                            select prod;
            return productos.OrderBy(c => c.IdProducto).ToList();
        }

        public bool ActivarProducto(int idProducto)
        {
            try
            {
                var art = ObtenerProductoPorId(idProducto);
                art.FechaBaja = null;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "ActivarProducto", ex);
                throw new Exception("Ocurrió un error al activar un producto. Contacte al soporte técnico.", ex);
            }
        }

        public List<VistaProducto> ObtenerListProductosPorNro(int idProducto, bool prodBaja)
        {
            if (prodBaja)
            {
                if (idProducto.ToString() == "")
                {
                    return db.VistaProducto.OrderBy(c => c.DescCorta).ToList();
                }
                else
                {
                    var productos = from producto in db.VistaProducto
                                    where producto.IdProducto == idProducto
                                    select producto;
                    return productos.OrderBy(c => c.DescCorta).ToList();
                }

            }
            else
            {
                var productos = from producto in db.VistaProducto
                                where producto.IdProducto == idProducto && producto.FechaBaja == ""
                                select producto;
                return productos.OrderBy(c => c.DescCorta).ToList();
            }
        }

        public List<VistaProducto> ObtenerListProductosPorDesc(string descr, bool prodBaja)
        {
            if (prodBaja)
            {
                var productos = from prod in db.VistaProducto
                                where prod.DescCorta.Contains(descr)
                                select prod;
                return productos.OrderBy(c => c.DescCorta).ToList();
            }
            else
            {
                var productos = from prod in db.VistaProducto
                                where prod.DescCorta.Contains(descr) && prod.FechaBaja == ""
                                select prod;
                return productos.OrderBy(c => c.DescCorta).ToList();
            }
        }

        public List<VistaProducto> ObtenerListProductosPorRubro(string rubro, bool prodBaja)
        {
            if (prodBaja)
            {
                var productos = from prod in db.VistaProducto
                                where prod.Rubro.Contains(rubro)
                                select prod;
                return productos.OrderBy(c => c.DescCorta).ToList();
            }
            else
            {
                var productos = from prod in db.VistaProducto
                                where prod.Rubro.Contains(rubro) && prod.FechaBaja == ""
                                select prod;
                return productos.OrderBy(c => c.DescCorta).ToList();
            }
        }

        public bool ExistePrecio(int idProducto)
        {
            return db.PreciosVenta.Any(c => c.IdProducto == idProducto);
        }

        public VistaPreciosVenta ObtenerVistaUltVPV(int idProducto)
        {
            if (ExistePrecio(idProducto))
            {
                // Primero obtenemos la fecha máxima
                var maxFecha = ObtenerMaxFecha(idProducto);

                // Luego usamos esa fecha en la consulta LINQ
                return db.VistaPreciosVenta
                .Where(c => c.IdProducto == idProducto &&
                                  c.FechaPrecio.Year == maxFecha.Year &&
                                  c.FechaPrecio.Month == maxFecha.Month &&
                                  c.FechaPrecio.Day == maxFecha.Day)
                .OrderByDescending(c => c.FechaPrecio)
                .FirstOrDefault();
            }
            else {
                return null;
            }
        }

        private DateTime ObtenerMaxFecha(int idProd)
        {
            return db.PreciosVenta
                .Where(p => p.IdProducto == idProd)
                .AsEnumerable() // Convierte a consulta en memoria (Evita que LINQ to Entities falle)
                .Max(p => p.FechaPrecios);
        }



        public bool NuevoPrecioVenta(PreciosVenta pv)
        {
            try
            {
                db.PreciosVenta.Add(pv);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "NuevoPrecioVenta", ex);
                throw new Exception("Ocurrió un error al insertar precio. Contacte al soporte técnico.", ex);
            }
        }

        public List<VistaPreciosVenta> ObtenerUltPrecioVenta()
        {
            // Agrupar por ProductoId y seleccionar el último precio por fecha
            var ultimosPrecios = db.VistaPreciosVenta
                .GroupBy(p => p.IdProducto) // Agrupar por ProductoId
                .Select(g => g.OrderByDescending(p => p.FechaPrecio).FirstOrDefault()) // Seleccionar el último precio por fecha
                .ToList();

            return ultimosPrecios;
        }

        public List<VistaPreciosVenta> ObtenerListPreciosPorNro(int idProducto)
        {

            if (idProducto.ToString() == "")
            {
                // Obtener todos los productos con su último precio
                var ultimosPrecios = db.VistaPreciosVenta
                    .GroupBy(p => p.IdProducto) // Agrupar por IdProducto
                    .Select(g => g.OrderByDescending(p => p.FechaPrecio).FirstOrDefault()) // Seleccionar el último precio por fecha
                    .ToList();

                return ultimosPrecios;
            }
            else
            {
                // Obtener el último precio para un producto específico
                var ultimoPrecio = db.VistaPreciosVenta
                    .Where(p => p.IdProducto == idProducto) // Filtrar por IdProducto
                    .OrderByDescending(p => p.FechaPrecio) // Ordenar por FechaPrecio (el más reciente primero)
                    .FirstOrDefault(); // Seleccionar el primero (el más reciente)

                // Devolver una lista con un solo elemento (el último precio)
                return ultimoPrecio != null ? new List<VistaPreciosVenta> { ultimoPrecio } : new List<VistaPreciosVenta>();
            }

        }

        public List<VistaPreciosVenta> ObtenerListPreciosPorDesc(string descr)
        {

            return db.VistaPreciosVenta
             .Where(prod => prod.DescCorta.Contains(descr))
             .GroupBy(prod => prod.DescCorta) // Agrupa por descripción
             .Select(g => g.OrderByDescending(prod => prod.FechaPrecio).FirstOrDefault()) // Toma el más reciente
             .ToList();

        }

        public DataTable CargarComboPrecios(int idProducto, string tipofact)
        {
            try
            {
                PreciosVenta pre = ObtenerUltPrecioVentaPorId(idProducto);
                if (pre != null)
                {
                    var dt = new DataTable();
                    dt.Columns.Add("Desc", typeof(string));
                    dt.Columns.Add("Precio", typeof(decimal));
                    DataRow newRow = dt.NewRow();
                    if (tipofact == "A")
                    {
                        newRow["Desc"] = "Contado: $ " + Math.Round(pre.PrecioContado, 2, MidpointRounding.AwayFromZero);
                        newRow["Precio"] = Math.Round(pre.PrecioContado, 2, MidpointRounding.AwayFromZero);
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        //newRow["Desc"] = "Fiado: $ " + Math.Round(pre.PrecioFiado, 2, MidpointRounding.AwayFromZero);
                        //newRow["Precio"] = Math.Round(pre.PrecioFiado, 2, MidpointRounding.AwayFromZero);
                        dt.Rows.Add(newRow);
                    }
                    else
                    {
                        newRow["Desc"] = "Contado: $ " + Math.Round(pre.PrecioContadoIva, 2, MidpointRounding.AwayFromZero);
                        newRow["Precio"] = Math.Round(pre.PrecioContadoIva, 2, MidpointRounding.AwayFromZero);
                        dt.Rows.Add(newRow);
                        newRow = dt.NewRow();
                        //newRow["Desc"] = "Fiado: $ " + Math.Round(pre.PrecioFiadoIva, 2, MidpointRounding.AwayFromZero);
                        //newRow["Precio"] = Math.Round(pre.PrecioFiadoIva, 2, MidpointRounding.AwayFromZero);
                        dt.Rows.Add(newRow);
                    }
                    return dt;
                }
                return null;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("ProductoNegocio", "CargarComboPrecios", ex);
                throw new Exception("Ocurrió un error al cargar combo precio. Contacte al soporte técnico.", ex);
            }
        }

        public PreciosVenta ObtenerUltPrecioVentaPorId(int idProducto)
        {
            PreciosVenta preciosVenta = new PreciosVenta();
            if (ExistePrecio(idProducto))
            {
                preciosVenta = db.PreciosVenta
             .Where(prod => prod.IdProducto == idProducto)
             .OrderByDescending(ultPrecio => ultPrecio.FechaPrecios).FirstOrDefault();
            }

            return preciosVenta;
        }

    }
}
