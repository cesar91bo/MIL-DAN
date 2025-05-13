using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CajaNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public bool ExisteCajaAnteriorSinCerrar()
        {
            var ultimaCaja = ObtenerUltimaCaja();

            if (ultimaCaja == null)
                return false;

            bool esCajaDeOtroDia = ultimaCaja.FechaApertura.Date < DateTime.Now.Date;
            bool noEstaCerrada = ultimaCaja.FechaCierre == null;

            return esCajaDeOtroDia && noEstaCerrada;
        }

        public bool NuevaCaja(Cajas caja)
        {
            try
            {
                db.Cajas.Add(caja);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Cajas ObtenerUltimaCaja()
        {
            return db.Cajas.OrderByDescending(c => c.FechaApertura).FirstOrDefault();

        }

        public Cajas ObtenerCajaActual()
        {
            try
            {
                DateTime hoy = DateTime.Today;
                DateTime mañana = hoy.AddDays(1);

                Cajas caja = db.Cajas
                    .Where(c => c.FechaApertura >= hoy && c.FechaApertura < mañana && c.FechaCierre == null)
                    .FirstOrDefault();
                return caja;
                //return db.Cajas.Where(c => c.FechaApertura.Date == DateTime.Now.Date && c.FechaCierre == null).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ResultadoOperacion GuardarEgreso(CajasEgresos cajasEgresos)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();

            try
            {
                cajasEgresos.Fecha = DateTime.Now;
                cajasEgresos.Usuario = 1;

                db.CajasEgresos.Add(cajasEgresos);
                db.SaveChanges();

                resultado.EsExitoso = true;
                resultado.Mensaje = "Egreso guardado correctamente.";
            }
            catch (Exception ex)
            {
                resultado.EsExitoso = false;
                resultado.Mensaje = "Ocurrió un error al guardar: " + ex.Message;
            }

            return resultado;
        }

        public ResultadoOperacion GuardarIngreso(CajasIngresos cajasIngreso)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();

            try
            {
                cajasIngreso.Fecha = DateTime.Now;
                cajasIngreso.Usuario = 1;

                db.CajasIngresos.Add(cajasIngreso);
                db.SaveChanges();

                resultado.EsExitoso = true;
                resultado.Mensaje = "Ingreso guardado correctamente.";
            }
            catch (Exception ex)
            {
                resultado.EsExitoso = false;
                resultado.Mensaje = "Ocurrió un error al guardar: " + ex.Message;
            }

            return resultado;
        }

        public ResultadoOperacion EditarMontocaja(decimal montoTotal, decimal vuelto, int IdCaja)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();
            try
            {
                Cajas getCaja = new Cajas();
                getCaja = db.Cajas.FirstOrDefault(c => c.IdCaja == IdCaja);

                if (getCaja != null)
                {
                    getCaja.MontoFinal = (getCaja.MontoFinal ?? getCaja.MontoInicial) + (montoTotal - vuelto);

                    db.SaveChanges();
                    resultado.EsExitoso = true;
                    resultado.Mensaje = "Edición guardado correctamente.";
                }
                else
                {
                    resultado.EsExitoso = false;
                    resultado.Mensaje = "No se encontró la caja a editar";
                }
            }
            catch (Exception ex)
            {
                resultado.EsExitoso = false;
                resultado.Mensaje = "Ocurrió un error al editar caja: " + ex.Message;
            }
            return resultado;
        }

        public ResultadoOperacion CerrarCaja(Cajas caja)
        {
            ResultadoOperacion resultado = new ResultadoOperacion();
            try
            {
                Cajas getCaja = new Cajas();
                getCaja = db.Cajas.OrderByDescending(c => c.IdCaja == caja.IdCaja).FirstOrDefault();



                if (getCaja != null)
                {
                    getCaja.MontoFinal = getCaja.MontoFinal;
                    getCaja.Estado = caja.Estado;
                    getCaja.FechaCierre = caja.FechaCierre;
                    getCaja.Observaciones = caja.Observaciones;

                    db.SaveChanges();
                    resultado.Mensaje = "Se cerró la caja correctamente.";
                    resultado.EsExitoso = true;
                }
                else
                {
                    resultado.Mensaje = "No se encontró la caja a cerrar.";
                    resultado.EsExitoso = false;
                }
            }
            catch (Exception ex)
            {

                resultado.EsExitoso = false;
                resultado.Mensaje = "Ocurrió un error al cerrar caja: " + ex.Message;
            }

            return resultado;
        }

        public List<CajasEgresos> ObtenerCajaEgresoPorFecha(DateTime fechaApertura)
        {
            try
            {
                DateTime desde = fechaApertura.Date;
                DateTime hasta = fechaApertura.Date.AddDays(1);
                return db.CajasEgresos
               .Where(c => c.Fecha >= desde && c.Fecha < hasta)
               .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Cajas> ObtenerCajas()
        {
            try
            {
                return db.Cajas
                    .OrderByDescending(c => c.FechaApertura)
                    .ThenByDescending(c => c.IdCaja)
                    .ToList();
            }
            catch (Exception ex)
            {

                return new List<Cajas>();
            }
        }

        public List<Cajas> ObtenerCajaPorFecha(DateTime desde, DateTime hasta)
        {
            try
            {
                DateTime fechaDesde = desde.Date;
                DateTime fechaHasta = hasta.Date.AddDays(1);
                return db.Cajas
                    .Where(c => c.FechaApertura >= fechaDesde && c.FechaApertura < fechaHasta)
                    .OrderByDescending(c => c.FechaApertura)
                    .ThenByDescending(c => c.IdCaja)
                    .ToList();
            }
            catch
            {
                return new List<Cajas>();
            }
        }


        public List<CajasEgresos> ObtenerCajaEgresoPorIdCaja(int IdCaja)
        {
            try
            {
                return db.CajasEgresos.Where(c => c.IdCaja == IdCaja).ToList();
            }
            catch (Exception)
            {

                return new List<CajasEgresos>();
            }
        }

        public List<CajasIngresos> ObtenerCajaIngresoPorFecha(DateTime fechaApertura)
        {
            try
            {
                DateTime desde = fechaApertura.Date;
                DateTime hasta = fechaApertura.Date.AddDays(1);
                return db.CajasIngresos
               .Where(c => c.Fecha >= desde && c.Fecha < hasta)
               .ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CajasIngresos> ObtenerCajasIngresosPorIdCaja(int IdCaja)
        {
            try
            {
                return db.CajasIngresos.Where(c => c.IdCaja == IdCaja).ToList();
            }
            catch (Exception)
            {

                return new List<CajasIngresos>();
            }
        }
    }
}
