﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Notch.Data.EntityFramework.Entity
{
    using System.Data.Entity;
    
    public partial class NotchContext : DbContext
    {
        public NotchContext()
            : base("name=NotchConnection")
        {
        }
    
        public virtual DbSet<Producer> Producer { get; set; }
        public virtual DbSet<ProducerTrack> ProducerTrack { get; set; }
        public virtual DbSet<Track> Track { get; set; }
    }
}
