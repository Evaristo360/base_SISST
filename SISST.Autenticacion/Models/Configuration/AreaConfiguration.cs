using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models.Configuration
{
    public class AreaConfiguration : IEntityTypeConfiguration<Area>
    {
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.ToTable("Area");

            builder.Property(d => d.Id).IsRequired();
            // PRME Se ajustaron propiedades de los campos
            builder.Property(d => d.IdProceso).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasColumnType("VARCHAR").HasMaxLength(175);
            builder.Property(x => x.Clave).IsRequired().HasColumnType("VARCHAR").HasMaxLength(5);
            builder.Property(x => x.Direccion).HasColumnType("VARCHAR").HasMaxLength(250);
            builder.Property(x => x.CentroGestor).HasColumnType("VARCHAR").HasMaxLength(5);
            builder.Property(x => x.ClaveControlGestion).HasColumnType("VARCHAR").HasMaxLength(7);
            builder.Property(x => x.Telefono).HasColumnType("VARCHAR").HasMaxLength(150);

            var areas = new List<Area>();
            //PRME Se ajustaron identificadores de catálogos
            areas.Add(
                 new Area
                 {
                     Id = 1,                    
                     Activo = true,
                     Nombre = "Comisión Federal de Electricidad",
                     IdAreaSuperior =null,
                     IdAreaVerificacion = null,
                     Clave = "A0000",
                     Direccion = "",
                     IdProceso = 102,
                     IdNivelJerarquico=3287,
                     IdEntidadFederativa=1,
                     IdMunicipio=1,
                     CentroGestor ="",
                     Telefono="",
                     GeneraDatosBasicos = false
                     
                 }
                );

            builder.HasData(areas);
        }
    }
}
