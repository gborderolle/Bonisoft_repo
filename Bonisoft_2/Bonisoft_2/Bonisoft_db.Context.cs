﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Bonisoft_2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class bonisoft_dbEntities : DbContext
    {
        public bonisoft_dbEntities()
            : base("name=bonisoft_dbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<chofer> choferes { get; set; }
        public virtual DbSet<cuadrilla_descarga> cuadrilla_descarga { get; set; }
        public virtual DbSet<descarga_viaje> descarga_viaje { get; set; }
        public virtual DbSet<forma_de_pago> forma_de_pago { get; set; }
        public virtual DbSet<interno> internos { get; set; }
        public virtual DbSet<lena_tipo> lena_tipo { get; set; }
        public virtual DbSet<preferencias_cliente> preferencias_cliente { get; set; }
        public virtual DbSet<proveedor_carga> proveedor_carga { get; set; }
        public virtual DbSet<proveedor_mercaderia> proveedor_mercaderia { get; set; }
        public virtual DbSet<usuario> usuarios { get; set; }
        public virtual DbSet<cliente_preferencias_cliente> cliente_preferencias_cliente { get; set; }
        public virtual DbSet<roles_usuario> roles_usuario { get; set; }
        public virtual DbSet<variedad> variedad { get; set; }
        public virtual DbSet<fletero> fleteros { get; set; }
        public virtual DbSet<mercaderia_comprada> mercaderia_comprada { get; set; }
        public virtual DbSet<cliente> clientes { get; set; }
        public virtual DbSet<camion> camiones { get; set; }
        public virtual DbSet<pesada> pesadas { get; set; }
        public virtual DbSet<proveedor> proveedores { get; set; }
        public virtual DbSet<viaje> viajes { get; set; }
        public virtual DbSet<viaje_mercaderia> viaje_mercaderia { get; set; }
        public virtual DbSet<cargador> cargadores { get; set; }
        public virtual DbSet<procesador> procesadores { get; set; }
        public virtual DbSet<log> logs { get; set; }
    }
}
