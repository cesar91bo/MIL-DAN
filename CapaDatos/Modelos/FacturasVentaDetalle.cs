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
    
    public partial class FacturasVentaDetalle
    {
        public long IdFacturaVentaDetalle { get; set; }
        public int IdFacturaVenta { get; set; }
        public Nullable<int> IdProducto { get; set; }
        public string Producto { get; set; }
        public string UMedida { get; set; }
        public decimal Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public byte IdTipoIva { get; set; }
        public decimal TotalArt { get; set; }
        public bool DesdeRemito { get; set; }
        public string UsrAcceso { get; set; }
        public System.DateTime FechaAcceso { get; set; }
        public Nullable<bool> PrecioManual { get; set; }
    
        public virtual FacturasVenta FacturasVenta { get; set; }
        public virtual Productos Productos { get; set; }
        public virtual TiposIva TiposIva { get; set; }
    }
}
