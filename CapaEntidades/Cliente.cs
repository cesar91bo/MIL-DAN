using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidades
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public int NroCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; } = string.Empty;
        public string TipoDocumento { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public DateTime? FechaNacimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int IdRegimenImpositivo { get; set; }
        public string Observaciones { get; set; } = string.Empty;
    }
}
