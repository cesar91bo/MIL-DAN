﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SistemaGestionPymeBDEntities : DbContext
    {
        public SistemaGestionPymeBDEntities()
            : base("name=SistemaGestionPymeBDEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<RegimenesImpositivos> RegimenesImpositivos { get; set; }
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Rubros> Rubros { get; set; }
        public virtual DbSet<UnidadesMedida> UnidadesMedida { get; set; }
        public virtual DbSet<AjustesStock> AjustesStock { get; set; }
        public virtual DbSet<VistaProducto> VistaProducto { get; set; }
        public virtual DbSet<VistaPreciosVenta> VistaPreciosVenta { get; set; }
        public virtual DbSet<PreciosVenta> PreciosVenta { get; set; }
        public virtual DbSet<CPostales> CPostales { get; set; }
        public virtual DbSet<Provincias> Provincias { get; set; }
        public virtual DbSet<VistaCPostales> VistaCPostales { get; set; }
        public virtual DbSet<TiposDocumento> TiposDocumento { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<VistaClientes> VistaClientes { get; set; }
        public virtual DbSet<FormasPago> FormasPago { get; set; }
        public virtual DbSet<TiposConceptoFactura> TiposConceptoFactura { get; set; }
        public virtual DbSet<TiposFactura> TiposFactura { get; set; }
        public virtual DbSet<Seteos> Seteos { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<FacturasVenta> FacturasVenta { get; set; }
        public virtual DbSet<FacturasVentaDetalle> FacturasVentaDetalle { get; set; }
        public virtual DbSet<TiposDocFact> TiposDocFact { get; set; }
        public virtual DbSet<TiposIva> TiposIva { get; set; }
        public virtual DbSet<Remitos> Remitos { get; set; }
        public virtual DbSet<RemitosDetalle> RemitosDetalle { get; set; }
        public virtual DbSet<RemitosXfacturados> RemitosXfacturados { get; set; }
        public virtual DbSet<VistaCabFactVenta> VistaCabFactVenta { get; set; }
        public virtual DbSet<VistaDetalleFactVenta> VistaDetalleFactVenta { get; set; }
    }
}
