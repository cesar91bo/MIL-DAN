using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class RemitosNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        public bool EditarNroFact(int idrem, int nrofact, short IdEmp)
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


    }
}
