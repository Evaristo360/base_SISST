using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISST.Reuniones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Data.Configuration
{
    public class DocumentosConfiguration
    {
        public DocumentosConfiguration(EntityTypeBuilder<Documento> entityBuilder)
        {
            entityBuilder.HasIndex(i => i.DocumentoId);
            entityBuilder.Property(i => i.ReunionId).IsRequired().HasColumnType("INT").HasMaxLength(10);
            entityBuilder.Property(i => i.Nombre).IsRequired().HasColumnType("VARCHAR").HasMaxLength(50);
            entityBuilder.Property(i => i.Ruta).HasColumnType("TEXT");
            
        }

        }
}
