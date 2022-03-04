using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SISST.Autenticacion.Models.Configuration
{
   
	class DepartamentoDetConfiguration : IEntityTypeConfiguration<DepartamentoDet>
	{
		public void Configure(EntityTypeBuilder<DepartamentoDet> builder)
		{
			builder.ToTable("DepartamentoDet");
			builder.HasKey(m => m.Id);
			builder.Property(m => m.IdArea).IsRequired();
			builder.Property(m => m.ClaveDepto).HasMaxLength(5);			
			builder.Property(m => m.Descripcion).HasMaxLength(70);
			builder.Property(m => m.id_rama_actividad).HasMaxLength(3);
		}
	}


}
