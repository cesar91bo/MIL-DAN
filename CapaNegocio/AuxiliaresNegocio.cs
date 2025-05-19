using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CapaNegocio
{
    public class AuxiliaresNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();
        private Logger logger = new Logger();
        public bool EditarUMedida(UnidadesMedida umed)
        {
            try
            {
                EditarUmedida(umed);
                return true;
            }
            catch (Exception ex)
            {
                // Registrar error en la base de datos
                logger.RegistrarError("AuxiliaresNegocio", "EditarUMedida", ex);

                // Lanzar una nueva excepción con un mensaje más claro sin perder la información original
                throw new Exception("Ocurrió un error al editar la unidad de medida. Contacte al soporte técnico.", ex);
            }
        }

        private void EditarUmedida(UnidadesMedida umed)
        {
            var unidad = db.UnidadesMedida.SingleOrDefault(c => c.IdUnidadMedida == umed.IdUnidadMedida);
            unidad.Descripcion = umed.Descripcion;
            db.SaveChanges();
        }

        public bool EditarRubro(Rubros rubro)
        {
            try
            {
                var rubroBase = db.Rubros.SingleOrDefault(c => c.IdRubro == rubro.IdRubro);
                rubroBase.Descripcion = rubro.Descripcion;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.RegistrarError("AuxiliaresNegocio", "EditarRubro", ex);
                throw new Exception("Ocurrió un error al editar rubro. Contacte al soporte técnico.", ex);
            }
        }

        public bool EditarProveedor(Proveedores proveedor)
        {
            try
            {
                var proveedorBase = db.Proveedores.SingleOrDefault(c => c.IdProveedor == proveedor.IdProveedor);
                proveedorBase.Descripcion = proveedor.Descripcion;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                logger.RegistrarError("AuxiliaresNegocio", "EditarProveedor", ex);
                throw new Exception("Ocurrió un error al editar proveedor. Contacte al soporte técnico.", ex);
            }
        }

        public bool NuevaUMedida(UnidadesMedida umed)
        {
            try
            {
                AgregarUmedida(umed);
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("AuxiliaresNegocio", "NuevaUMedida", ex);
                throw new Exception("Ocurrió un error al insertar unidad de medida. Contacte al soporte técnico.", ex);
            }
        }

        public void AgregarUmedida(UnidadesMedida um)
        {
            db.UnidadesMedida.Add(um);
            db.SaveChanges(); 
        }

        public void AgregarRubro(Rubros rubro)
        {
            db.Rubros.Add(rubro);
            db.SaveChanges();
        }

        #region Consultas
        public List<Rubros> ObtenerRubros()
        {
            return db.Rubros.OrderBy(c => c.IdRubro).ToList();
        }

        public Seteos ObtenerSeteo()
        {
            var ultimoSeteo = db.Seteos.OrderByDescending(s => s.IdSeteo).FirstOrDefault() ?? new Seteos();
            return ultimoSeteo;
        }

        public List<UnidadesMedida> ObtenerUMedida()
        {
            return db.UnidadesMedida.OrderBy(c=>c.IdUnidadMedida).ToList();
        }

        public UnidadesMedida ObtenerUMedidaPorId(int idUMed)
        {
            return db.UnidadesMedida.SingleOrDefault(c => c.IdUnidadMedida == idUMed);
        }

        public bool BorrarUMedida(int idUnidadMedida)
        {
            try
            {
                var productoNegocio = new ProductoNegocio();
                if (productoNegocio.ObtenerTodo().Any(c => c.IdUnidadMedida == idUnidadMedida))
                {
                    return false;
                }
                else
                {
                    var unidad = db.UnidadesMedida.SingleOrDefault(u => u.IdUnidadMedida == idUnidadMedida);
                    if (unidad != null)
                    {
                        db.UnidadesMedida.Remove(unidad);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.RegistrarError("AuxiliaresNegocio", "BorrarUMedida", ex);
                throw new Exception("Ocurrió un error al borrar unidad de medida. Contacte al soporte técnico.", ex);
            }
        }

        public List<Proveedores> ObtenerProveedores()
        {
            return db.Proveedores.OrderBy(x => x.IdProveedor).ToList();
        }

        public Proveedores ObtenerProveedorPorId(int idproveedor)
        {
            return db.Proveedores.SingleOrDefault(c => c.IdProveedor == idproveedor);
        }

        public bool BorrarProveedor(int idProveedor)
        {
            try
            {
                var productoNegocio = new ProductoNegocio();
                if (productoNegocio.ObtenerTodo().Any(c => c.IdProveedor == idProveedor))
                {
                    return false;
                }
                else
                {
                    var proveedor = db.Proveedores.SingleOrDefault(u => u.IdProveedor == idProveedor);
                    if (proveedor != null)
                    {
                        db.Proveedores.Remove(proveedor);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                logger.RegistrarError("AuxiliaresNegocio", "BorrarProveedor", ex);
                throw new Exception("Ocurrió un error al borrar proveedor. Contacte al soporte técnico.", ex);
            }
        }

        public bool BorrarRubro(int idRubro)
        {
            try
            {
                var productoNegocio = new ProductoNegocio();
                if (productoNegocio.ObtenerTodo().Any(c => c.IdRubro == idRubro))
                {
                    return false;
                }
                else
                {
                    var rubro = db.Rubros.SingleOrDefault(u => u.IdRubro == idRubro);
                    if (rubro != null)
                    {
                        db.Rubros.Remove(rubro);
                        db.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("AuxiliaresNegocio", "BorrarRubro", ex);
                throw new Exception("Ocurrió un error al borrar rubro. Contacte al soporte técnico.", ex);
            }
        }

        public bool NuevoRubro(Rubros rubro)
        {
            try
            {
                AgregarRubro(rubro);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public bool NuevoProveedor(Proveedores proveedores)
        {
            try
            {
                AgregarProveedor(proveedores);
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        private void AgregarProveedor(Proveedores proveedores)
        {
            db.Proveedores.Add(proveedores);
            db.SaveChanges();
        }

        public List<Provincias> ObtenerProvincias() { return db.Provincias.ToList(); }
        public List<VistaCPostales> ObtenerCPs() { return db.VistaCPostales.ToList(); }
        public List<RegimenesImpositivos> ObtenerRegimenes() { return db.RegimenesImpositivos.ToList(); }
        public List<TiposDocumento> ObtenerTiposDoc()
        {
            List<TiposDocumento> ltd = db.TiposDocumento.ToList();
            TiposDocumento ItemEmpty = new TiposDocumento { TipoDocumento = "-", Descripcion = "-" };
            ltd.Add(ItemEmpty);
            return ltd;
        }

        public CPostales ObtenerDatosCP(short codigoPostal, byte subCodigoPostal)
        {
            return db.CPostales.SingleOrDefault(c => c.CodigoPostal == codigoPostal && c.SubCodigoPostal == subCodigoPostal);
        }

        public DataTable DTCP(short idProv)
        {
            var cps = from c in ObtenerCPs()
                      where c.IdProvincia == idProv
                      orderby c.Localidad
                      select c;
            DataTable dt = ConvertToDataTable(cps.ToList());
            return dt;
        }
        #endregion

        public DataTable ConvertToDataTable<T>(List<T> list)
        {
            DataTable dt = new DataTable();

            if (list.Count == 0) return dt; // Si la lista está vacía, retorna un DataTable vacío.

            // Crear las columnas en base a las propiedades de la clase
            foreach (var prop in typeof(T).GetProperties())
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            // Llenar las filas con los datos de la lista
            foreach (var item in list)
            {
                DataRow row = dt.NewRow();
                foreach (var prop in typeof(T).GetProperties())
                {
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }

        public DataTable DtTiposConceptosFactura()
        {
            DataTable dt = ConvertToDataTable(ObtenerTiposConceptosFactura().ToList());
            return dt;
        }

        public DataTable DtFormasPago()
        {
            DataTable dt = ConvertToDataTable(ObtenerFormasPago().ToList());
            return dt;
        }

        private IQueryable<FormasPago> ObtenerFormasPago()
        {
            return db.FormasPago;
        }

        public DataTable DtTiposFact()
        {
            DataTable dt = ConvertToDataTable(ObtenerTiposFact().ToList());
            return dt;
        }

        public IQueryable<TiposFactura> ObtenerTiposFact()
        {
            return db.TiposFactura;
        }

        public IQueryable<TiposConceptoFactura> ObtenerTiposConceptosFactura()
        {
            return db.TiposConceptoFactura;
        }

        public Seteos ObtenerSeteos()
        {
            return db.Seteos.OrderByDescending(s => s.IdSeteo).FirstOrDefault();
        }

        public List<TiposIva> ObtenerIVA()
        {
            return db.TiposIva.ToList();
        }

        public bool NuevoSeteos(Seteos seteos)
        {
            try
            {
                AgregarSeteos(seteos);
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("AuxiliaresNegocio", "NuevoSeteos", ex);
                throw new Exception("Ocurrió un error al insertar seteos. Contacte al soporte técnico.", ex);
            }
        }

        private void AgregarSeteos(Seteos seteos)
        {
            db.Seteos.Add(seteos);
            db.SaveChanges();
        }

        public bool NuevaEmpresa(Empresa empresa)
        {
            try
            {
                AgregarEmpresa(empresa);
                return true;
            }
            catch (Exception ex) 
            {
                logger.RegistrarError("AuxiliaresNegocio", "NuevaEmpresa", ex);
                throw new Exception("Ocurrió un error al insertar empresa. Contacte al soporte técnico.", ex);
            }
        }

        private void AgregarEmpresa(Empresa empresa)
        {
            db.Empresa.Add(empresa);
            db.SaveChanges();
        }

        public Empresa ObtenerEmpresa()
        {
            return db.Empresa.OrderByDescending(s => s.IdEmpresa).FirstOrDefault();
        }

        public List<TiposIva> ListTiposIva() { return db.TiposIva.ToList(); }

        public TiposIva ObtenerTipoIVAporId(int idTipoIVa)
        {
            return db.TiposIva.SingleOrDefault(c => c.IdTipoIva == idTipoIVa);
        }
        public static Empresa GetEmpresa()
        {
            return db.Empresa.OrderByDescending(s => s.IdEmpresa).FirstOrDefault();
        }

        public bool ActualizarEmpresa(Empresa empresa)
        {
            var empresaExistente = db.Empresa.Find(empresa.IdEmpresa);
            if (empresaExistente != null)
            {
                empresaExistente.RazonSocial = empresa.RazonSocial;
                empresaExistente.NFantasia = empresa.NFantasia;
                empresaExistente.Direccion = empresa.Direccion;
                empresaExistente.InicioActividades = empresa.InicioActividades;
                empresaExistente.CUIT = empresa.CUIT;
                empresaExistente.Telefono = empresa.Telefono;
                empresaExistente.Correo = empresa.Correo;
                empresaExistente.IIBB = empresa.IIBB;
                empresaExistente.CondicionIva = empresa.CondicionIva;
                empresaExistente.CodigoPostal = empresa.CodigoPostal;
                empresaExistente.SubCodigoPostal = empresa.SubCodigoPostal;
                empresaExistente.RutaCertificado = empresa.RutaCertificado;
                empresaExistente.SerialCertificado = empresa.SerialCertificado;
                db.SaveChanges();
                return true;
            }
            else
            {
                return false; // Empresa no encontrada
            }
        }

        public void ActualizarSeteos(Seteos seteos)
        {
            var seteoExistente = db.Seteos.Find(seteos.IdSeteo);
            if (seteoExistente != null)
            {
                seteoExistente.PorcentajeGcia = seteos.PorcentajeGcia;
                seteoExistente.DiasVtoFact = seteos.DiasVtoFact;
                seteoExistente.ToleranciaDiferencia = seteos.ToleranciaDiferencia;
                db.SaveChanges();
            }
            else
            {
                throw new Exception("Seteo no encontrado.");
            }
        }
    }
}
