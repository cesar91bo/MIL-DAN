using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class ProductoNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();
        public Productos ObtenerProductoPorId(int idProducto)
        {
            return db.Productos.SingleOrDefault(c => c.NroProducto == idProducto);
        }
    }
}
