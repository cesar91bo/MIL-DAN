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
    
    public partial class CPostales
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CPostales()
        {
            this.Empresa = new HashSet<Empresa>();
        }
    
        public short CodigoPostal { get; set; }
        public byte SubCodigoPostal { get; set; }
        public string Localidad { get; set; }
        public int IdProvincia { get; set; }
    
        public virtual Provincias Provincias { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Empresa> Empresa { get; set; }
    }
}
