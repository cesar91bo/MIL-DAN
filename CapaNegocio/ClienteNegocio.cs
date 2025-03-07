using CapaDatos;
using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace CapaNegocio
{
    public class ClienteNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public int EditarCliente(Clientes cli, int nroCliente)
        {
            try
            {
                Clientes clienteBD = ObtenerCliporNroCli(nroCliente);
                clienteBD.Nombre = cli.Nombre;
                clienteBD.Apellido = cli.Apellido;
                clienteBD.Documento = cli.Documento;
                clienteBD.TipoDocumento = cli.TipoDocumento;
                clienteBD.Email = cli.Email;
                clienteBD.Cuit0 = cli.Cuit0;
                clienteBD.Cuit1 = cli.Cuit1;
                clienteBD.Cuit2 = cli.Cuit2;
                clienteBD.Telefono = cli.Telefono;
                clienteBD.Direccion = cli.Direccion;
                clienteBD.CodigoPostal = cli.CodigoPostal;
                clienteBD.SubCodigoPostal = cli.SubCodigoPostal;
                clienteBD.Ciudad = cli.Ciudad;
                clienteBD.Provincia = cli.Provincia;
                clienteBD.FechaNacimiento = cli.FechaNacimiento;
                clienteBD.Estado = cli.Estado;
                clienteBD.FechaBaja = cli.FechaBaja;
                clienteBD.IdRegimenImpositivo = cli.IdRegimenImpositivo;
                clienteBD.Observaciones = cli.Observaciones;
                db.SaveChanges();
                return clienteBD.IdCliente;
            }
            catch (Exception ex) { throw ex; }
        }


        public List<Clientes> ListaClientes()
        {
            var clientes = from cli in db.Clientes
                           select cli;
            return clientes.OrderBy(o => o.Apellido).ToList();
        }

        public int NuevoCliente(Clientes cli)
        {
            try
            {
                AgregarCliente(cli);
                db.SaveChanges();
                return cli.IdCliente;
            }
            catch  (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var validationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine($"Propiedad: {validationError.PropertyName}, Error: {validationError.ErrorMessage}");
                    }
                }
                throw; // Lanza la excepción nuevamente para depuración
            }
        }

        private void AgregarCliente(Clientes cliente)
        {
            db.Clientes.Add(cliente);
        }

        public List<Clientes> ObtenerClientesCargadosCUIT(long Numerodoc, string TipoDoc)
        {
            if (Numerodoc <= 0) return new List<Clientes>();

            var detalle = db.Clientes
                            .AsEnumerable()
                            .Where(d => long.TryParse(d.Cuit1, out long cuit) && cuit == Numerodoc)
                            .ToList();

            return detalle ?? new List<Clientes>();
        }

        public List<VistaClientes> ObtenerClientesCargadosDni(Int64 numerodoc, string tipoDoc)
        {
            var listC = from c in db.VistaClientes
                        where c.Nro_Doc == numerodoc.ToString() && c.TipoDocumento == tipoDoc
                        select c;

            return listC.ToList();
        }

        public Clientes ObtenerCliporNroCli(int nroCliente)
        {
            return db.Clientes.SingleOrDefault(c => c.IdCliente == nroCliente);
        }

        public bool BajaCliente(int idCliente)
        {
            try
            {
                var art = ObtenerCliporNroCli(idCliente);
                art.FechaBaja = DateTime.Now;
                art.Estado = "Dado de Baja";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public List<VistaClientes> ObtenerListaClientes()
        {
            var listC = db.VistaClientes.ToList();
            return listC;
        }

        public List<VistaClientes> ObtenerCliporNombreApellido(string nombreApellido, bool dadoBaja)
        {
            var palabras = nombreApellido.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<VistaClientes> clientes = null;
            if (dadoBaja)
            {
                clientes = ObtenerVClis().Where(cli =>
                    palabras.All(p => cli.Nombre.ToLower().Contains(p) || cli.Apellido.ToLower().Contains(p))
                ).ToList();
            }
            else
            {
                clientes = ObtenerVClis().Where(cli =>
                    palabras.All(p => cli.Nombre.ToLower().Contains(p) || cli.Apellido.ToLower().Contains(p))
                    && cli.FechaBaja == ""
                ).ToList();
            }

            return clientes;
        }

        private List<VistaClientes> ObtenerVClis()
        {
            return db.VistaClientes.ToList();
        }

        public bool ActivarCliente(int idCLiente)
        {
            try
            {
                var art = ObtenerCliporNroCli(idCLiente);
                art.FechaBaja = null;
                art.Estado = "Activo";
                db.SaveChanges();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        public VistaClientes ObtenerVCliporNroCli(int idCliente)
        {
            return db.VistaClientes.SingleOrDefault(c => c.IdCliente == idCliente);
        }

        public List<VistaClientes> ObtenerListaClientesActivos()
        {
            var listC = db.VistaClientes.Where(c => c.FechaBaja == "").ToList();
            return listC;
        }
    }
}
