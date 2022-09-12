
using Microsoft.EntityFrameworkCore;
using SISST.Trabajores.Data.Configuration;
using SISST.Trabajores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Trabajores.Data
{
    public class ApplicationDbContext : DbContext
    {
        //constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        // base la clase del modelo y elnombre de tabla
        public DbSet<Trabajador> TTrabajadores { get; set; }

        // creacion del modelo para la base de datos 
        protected override void OnModelCreating(ModelBuilder builder)
        {
            //instanciamos el modelo
            base.OnModelCreating(builder);

            //creamos el schema
            // Catalog.TTrabajadores
            builder.HasDefaultSchema("Catalog");

            //guardamos configuraciones del modelo
            ModelConfig(builder);
        }

        //comportamiento de configuraciones de la tabla en base de datos
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            //instaciar una clase que tiene las configuraciones 
            //entidad que hace referencia al modelo
            new TrabajadoresConfiguration(modelBuilder.Entity<Trabajador>());
        }

    }
}
