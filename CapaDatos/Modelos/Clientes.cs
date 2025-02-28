//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos.Modelos
{
    using System;
    using System.Collections.Generic;
    
    public partial class Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Clientes()
        {
            this.FacturasVenta = new HashSet<FacturasVenta>();
        }
    
        public int IdCliente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public Nullable<long> Documento { get; set; }
        public string TipoDocumento { get; set; }
        public string Email { get; set; }
        public string Cuit0 { get; set; }
        public string Cuit1 { get; set; }
        public string Cuit2 { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public short CodigoPostal { get; set; }
        public byte SubCodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public Nullable<System.DateTime> FechaBaja { get; set; }
        public Nullable<int> IdRegimenImpositivo { get; set; }
        public string Observaciones { get; set; }
    
        public virtual RegimenesImpositivos RegimenesImpositivos { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasVenta> FacturasVenta { get; set; }
    }
}
