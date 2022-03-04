using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace SISST.Autenticacion.Models.Configuration
{

	class DepartamentoConfiguration : IEntityTypeConfiguration<Departamento>
	{
		public void Configure(EntityTypeBuilder<Departamento> builder)
		{
			builder.ToTable("Departamento");
			builder.HasKey(m => m.Id);
			builder.Property(m => m.IdCT).IsRequired();
			builder.Property(m => m.Clave).IsRequired().HasMaxLength(3);
			builder.Property(m => m.Descripcion).IsRequired().HasMaxLength(50);

			List<Departamento> deptos = new List<Departamento>();
			deptos.Add(new Departamento{Id=1, IdCT = 1,  Clave="AAA", Descripcion="Asesores", IdDepartamentoSicacyp=0});
			deptos.Add(new Departamento { Id = 2, IdCT = 1, Clave = "PPP", Descripcion = "Publicidad", IdDepartamentoSicacyp=0 });
			builder.HasData(deptos);
		}
	}
}

