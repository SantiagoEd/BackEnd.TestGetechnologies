using Microsoft.EntityFrameworkCore;
using BackEnd.TestGetechnologies.Models;
using System;

namespace BackEnd.TestGetechnologies.Data
{
    public class DatabaseContext : DbContext 
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            :base(options) 
        {
        }

        public DbSet<Factura> facturas { get; set; }
        public DbSet<Persona> personas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Persona>().HasKey(a => a.id);
            modelBuilder.Entity<Factura>().HasKey(a => a.id);
        }
    }
}
