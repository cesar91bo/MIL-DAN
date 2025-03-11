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
    
    public partial class FacturasVenta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FacturasVenta()
        {
            this.FacturasVentaDetalle = new HashSet<FacturasVentaDetalle>();
            this.Remitos = new HashSet<Remitos>();
        }
    
        public int IdFacturaVenta { get; set; }
        public short IdTipoDocumento { get; set; }
        public Nullable<short> IdTipoFactura { get; set; }
        public string BVFact { get; set; }
        public string NCompFact { get; set; }
        public System.DateTime FechaEmision { get; set; }
        public short IdFormaPago { get; set; }
        public int IdCliente { get; set; }
        public bool Impresa { get; set; }
        public string Observaciones { get; set; }
        public decimal Subtotal105 { get; set; }
        public decimal Subtotal21 { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Descuento { get; set; }
        public decimal TotalDescuento105 { get; set; }
        public decimal TotalDescuento21 { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalIva105 { get; set; }
        public decimal TotalIva21 { get; set; }
        public decimal Total { get; set; }
        public System.DateTime FechaVencimiento { get; set; }
        public Nullable<System.DateTime> FechaAnulacion { get; set; }
        public decimal TotalSaldado { get; set; }
        public decimal TotalInteres { get; set; }
        public decimal TotalSaldadoInteres { get; set; }
        public byte IdEmpresa { get; set; }
        public string UsrAcceso { get; set; }
        public System.DateTime FechaAcceso { get; set; }
        public string BVReferencia { get; set; }
        public string NroCompFactReferencia { get; set; }
        public int IdConceptoFactura { get; set; }
        public System.DateTime FechaAlta { get; set; }
        public bool Cobrador { get; set; }
        public bool MoverStock { get; set; }
        public string NombreMaquina { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual TiposConceptoFactura TiposConceptoFactura { get; set; }
        public virtual FormasPago FormasPago { get; set; }
        public virtual TiposDocFact TiposDocFact { get; set; }
        public virtual TiposFactura TiposFactura { get; set; }
        public virtual TiposConceptoFactura TiposConceptoFactura1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FacturasVentaDetalle> FacturasVentaDetalle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Remitos> Remitos { get; set; }
    }
}
