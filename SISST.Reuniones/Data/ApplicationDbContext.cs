using Microsoft.EntityFrameworkCore;
using SISST.Reuniones.Data.Configuration;
using SISST.Reuniones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Data
{
    public class ApplicationDbContext : DbContext 
    {
        //se establece la tabla de la base de datos 
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        //dbset tablas 
        public DbSet<Reunion> TReuniones { get; set; }
        public DbSet<Documento> TDocumentos { get; set; }
        public DbSet<Participante> TParticipantes { get; set; }
        //se crean los modelos
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //para establecer el esquema personalizado pero lo comento porque no se si lo ocupe jaja
            builder.HasDefaultSchema("Reunion");
            
            ModelConfig(builder);
        }
       // comportamiento personal sobre las configuraciones de la BD
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            //la configuracion reuinionesconfiguration trabaja con el modelo de reunion
            new ReunionesConfiguration(modelBuilder.Entity<Reunion>());
            new DocumentosConfiguration(modelBuilder.Entity<Documento>());
            new ParticipantesConfiguration(modelBuilder.Entity<Participante>());
        }
    }
}
