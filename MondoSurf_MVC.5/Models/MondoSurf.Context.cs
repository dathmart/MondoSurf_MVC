﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MondoSurf_MVC._5.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MondoSurfDBEntities2 : DbContext
    {
        public MondoSurfDBEntities2()
            : base("name=MondoSurfDBEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Spot_Details> Spot_Details { get; set; }
        public virtual DbSet<Spot_Forecast> Spot_Forecast { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
    }
}
