﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VehicleSelector
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TransportSelectionDBEntities : DbContext
    {
        public TransportSelectionDBEntities()
            : base("name=TransportSelectionDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Car> Car { get; set; }
        public virtual DbSet<CarDescription> CarDescription { get; set; }
        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartImage> PartImage { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
    }
}