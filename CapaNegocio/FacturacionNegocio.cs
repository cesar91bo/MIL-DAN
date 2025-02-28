using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class FacturacionNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public FacturasVenta ObtenerFactura(int idFact)
        {
            return db.FacturasVenta.SingleOrDefault(c => c.IdFacturaVenta == idFact);
        }
    }
}
