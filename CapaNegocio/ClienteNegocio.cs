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
        public List<Clientes> ListaClientes()
        {
            var clientes = from cli in db.Clientes
                           select cli;
            return clientes.OrderBy(o => o.Apellido).ToList();
        }
    }
}
