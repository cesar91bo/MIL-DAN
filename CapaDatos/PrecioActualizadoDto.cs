using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class PrecioActualizadoDto
    {
        public int IdProducto { get; set; }
        public decimal PrecioBase { get; set; }
        public decimal PrecioContado { get; set; }
        public decimal PrecioContadoIva { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public DateTime FechaPrecio { get; set; }
    }
}
