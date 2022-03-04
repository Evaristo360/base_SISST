
using SISST.Catalog.Data.Configuration;
using SISST.Catalog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using SISST.Catalog.Models.Configuration;

namespace SISST.Catalog.Data
{
    public class ApplicationDbContext : DbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {  }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Database schema
            builder.HasDefaultSchema("Catalogo");

            // Model Contraints
            ModelConfig(builder);
        }

      
        public DbSet<Catalogo> Catalogo { get; set; }
        public DbSet<ArchivoAdjunto> ArchivoAdjuntos { get; set; }
        public DbSet<Configuracion> Configuracion { get; set; }
        public DbSet<FechaCorte> FechaCorte { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new CatalogoConfiguration(modelBuilder.Entity<Catalogo>());
            new ArchivoAdjuntoConfiguration(modelBuilder.Entity<ArchivoAdjunto>());
            new ConfiguracionConfiguration(modelBuilder.Entity<Configuracion>());
            new FechaCorteConfiguration(modelBuilder.Entity<FechaCorte>());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}

