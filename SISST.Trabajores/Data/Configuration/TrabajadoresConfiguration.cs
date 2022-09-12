
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISST.Trabajores.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Trabajores.Data.Configuration
{
    public class TrabajadoresConfiguration
    {
        public TrabajadoresConfiguration(EntityTypeBuilder<Trabajador> entityBuilder)
        {
            //hace referencia al campo Id que existe en nuestro modelo
            entityBuilder.HasIndex(m => m.TrabajadorId);
            //hace referercia con la propuedad que es requerida y el tamaño
            entityBuilder.Property(m => m.Nombre).IsRequired().HasMaxLength(20);
            entityBuilder.Property(m => m.Apellido).IsRequired().HasMaxLength(20);
        }
    }
}
