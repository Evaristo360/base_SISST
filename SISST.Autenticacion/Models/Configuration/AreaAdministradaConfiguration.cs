using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models.Configuration
{
    public class AreaAdministradaConfiguration : IEntityTypeConfiguration<AreaAdministrada>
    {
        public void Configure(EntityTypeBuilder<AreaAdministrada> builder)
        {
            builder.ToTable("AreaAdministrada");

            builder.HasKey(e => new { e.IdUsuario, e.IdRol, e.IdArea });

            builder.Property(d => d.IdUsuario).IsRequired();
            builder.Property(d => d.IdRol).IsRequired();
            builder.Property(d => d.IdArea).IsRequired();
        }
    }
}
