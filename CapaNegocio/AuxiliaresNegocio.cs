using CapaDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class AuxiliaresNegocio
    {
        public static SistemaGestionPymeBDEntities db = new SistemaGestionPymeBDEntities();

        #region Consultas
        public List<Rubros> ObtenerRubros()
        {
            return db.Rubros.OrderBy(c => c.IdRubro).ToList();
        }

        public object ObtenerUMedida()
        {
            return db.UnidadesMedida.OrderBy(c=>c.IdUnidadMedida).ToList();
        }
        #endregion
    }
}
