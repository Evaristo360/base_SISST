using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISST.Reuniones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//aqui merengues para la exportacion.
namespace SISST.Reuniones.Data.Configuration
{
    public class ReunionesConfiguration
    {
        public ReunionesConfiguration(EntityTypeBuilder<Reunion> entityBuilder)
        {
            entityBuilder.HasIndex(m => m.ReunionId);
            entityBuilder.Property(m => m.Fecha).IsRequired().HasColumnType("DATETIME");
            entityBuilder.Property(m => m.Horario).IsRequired().HasColumnType("VARCHAR").HasMaxLength(20);
            entityBuilder.Property(m => m.NoParticipantes).HasColumnType("INT").HasMaxLength(10);
            entityBuilder.Property(m => m.Tema).IsRequired().HasColumnType("VARCHAR").HasMaxLength(100);
            entityBuilder.Property(m => m.Apoyo).HasColumnType("INT").HasMaxLength(10);
            entityBuilder.Property(m => m.Introduccion).IsRequired().HasColumnType("TEXT");
            entityBuilder.Property(m => m.Desarrollo).IsRequired().HasColumnType("TEXT");
            entityBuilder.Property(m => m.Conclusiones).IsRequired().HasColumnType("TEXT");
            entityBuilder.Property(m => m.Retroalimentacion).IsRequired().HasColumnType("TEXT");

        }
    }
}
