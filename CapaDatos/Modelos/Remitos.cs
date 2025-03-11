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
    
    public partial class Remitos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Remitos()
        {
            this.RemitosDetalle = new HashSet<RemitosDetalle>();
        }
    
        public int IdRemito { get; set; }
        public string NroRemito { get; set; }
        public System.DateTime FechaRemito { get; set; }
        public int IdCliente { get; set; }
        public string Observaciones { get; set; }
        public Nullable<int> IdFactura { get; set; }
        public byte IdEmpresa { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public System.DateTime FechaAcceso { get; set; }
        public string UsrAcceso { get; set; }
        public Nullable<decimal> Total { get; set; }
        public Nullable<decimal> TotalDescuento { get; set; }
        public Nullable<decimal> PorcDescuento { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual FacturasVenta FacturasVenta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RemitosDetalle> RemitosDetalle { get; set; }
    }
}
