using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SISST.Reuniones.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Reuniones.Data.Configuration
{
    public class ParticipantesConfiguration
    {
        public ParticipantesConfiguration(EntityTypeBuilder<Participante> entityBuilder)
        {
            entityBuilder.HasIndex(m => m.Id);
            entityBuilder.Property(m => m.IdReunion).IsRequired().HasColumnType("INT").HasMaxLength(10);
            entityBuilder.Property(m => m.IdTrabajador).IsRequired().HasColumnType("INT").HasMaxLength(10);

        }
    }
}
