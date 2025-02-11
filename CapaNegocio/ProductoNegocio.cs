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

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public int AgregarNroProducto()
        {
            return (db.Productos.OrderByDescending(p => p.NroProducto).FirstOrDefault()?.NroProducto ?? 0) + 1;

        }

        public bool EditarProducto(Productos producto, int idProducto)
        {
            try
            {
                Productos productoBD = ObtenerProductoPorId(idProducto);
                productoBD.CodigoBarra = producto.CodigoBarra;
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
            catch (Exception ex) { throw ex; }
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
                    IdProducto = producto.NroProducto,
                    Motivo = "Stock Inicial del Producto",
                    FechaAcceso = DateTime.Now
                };
                NuevoAjuste(aj);
                return producto.IdProducto;
            }
            catch (Exception ex) { throw ex; }
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
                            throw;
                        }
                    }
                }
                return true;

            }
            catch (Exception ex) { throw ex; }
        }

        private void AgregarProducto(Productos producto)
        {
            db.Productos.Add(producto);
        }

        public Productos ObtenerProductoPorId(int idProducto)
        {
            return db.Productos.SingleOrDefault(c => c.IdProducto == idProducto);
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
            catch (Exception ex) { throw ex; }
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
            catch (Exception ex) { throw ex; }
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
            catch (Exception ex) { throw ex; }
        }

        public List<VistaProducto> ObtenerTodo()
        {
            var productos = from prod in db.VistaProducto
                            select prod;
            return productos.OrderBy(c => c.DescCorta).ToList();

        }
    }
}
