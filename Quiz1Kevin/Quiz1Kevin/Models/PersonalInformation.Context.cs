﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Quiz1Kevin.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class quiz1Entities : DbContext
    {
        public quiz1Entities()
            : base("name=quiz1Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Degree> Degree { get; set; }
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<PersonalInfo> PersonalInfo { get; set; }
    }
}