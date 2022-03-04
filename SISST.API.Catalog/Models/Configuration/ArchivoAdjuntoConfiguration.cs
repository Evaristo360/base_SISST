using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SISST.Catalog.Models.Configuration
{

	class ArchivoAdjuntoConfiguration : IEntityTypeConfiguration<ArchivoAdjunto>
	{
        public ArchivoAdjuntoConfiguration(EntityTypeBuilder<ArchivoAdjunto> builder)
		{
			Configure(builder);
        }
		public void Configure(EntityTypeBuilder<ArchivoAdjunto> builder)
		{
			builder.ToTable("ArchivoAdjunto");
			builder.HasKey(d => d.Id);
			builder
			   .Property(m => m.Id)
			   .UseIdentityColumn();
			builder.Property(d => d.IdReferencia).IsRequired();

			builder.Property(d => d.Tabla).HasMaxLength(50).HasColumnType("VARCHAR").IsRequired();

			builder.Property(d => d.RutaFisica).HasMaxLength(200).HasColumnType("VARCHAR").IsRequired();
			builder.Property(d => d.NombreArchivo).HasMaxLength(100).HasColumnType("VARCHAR").IsRequired();
			builder.Property(d => d.CategoriaArchivo).HasMaxLength(30).HasColumnType("VARCHAR");
			builder.Property(d => d.Titulo).HasMaxLength(50).HasColumnType("VARCHAR");
			builder.Property(d => d.Descripcion).HasColumnType("VARCHAR(MAX)");
		}
	}
}
