using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace SISST.Autenticacion.Models.Configuration
{
	class UsuarioPrivilegioConfiguration : IEntityTypeConfiguration<UsuarioPrivilegio>
	{
		public void Configure(EntityTypeBuilder<UsuarioPrivilegio> builder)
		{
			builder.ToTable("UsuarioPrivilegio");
			builder.HasKey(d => d.id);
			builder
			   .Property(m => m.id)
			   .UseIdentityColumn();
			builder.Property(d => d.usuarioId).IsRequired();
			builder.Property(d => d.privilegioId).IsRequired();

			List<UsuarioPrivilegio> usuarioprivilegio = new List<UsuarioPrivilegio>();
			// PRME
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 1, usuarioId = 6, privilegioId = 16 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 2, usuarioId = 6, privilegioId = 17 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 3, usuarioId = 6, privilegioId = 42 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 4, usuarioId = 6, privilegioId = 43 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 5, usuarioId = 6, privilegioId = 44 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 6, usuarioId = 6, privilegioId = 51 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 7, usuarioId = 6, privilegioId = 55 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 8, usuarioId = 6, privilegioId = 64 });

			// OMAR
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 9, usuarioId = 7, privilegioId = 16 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 10, usuarioId = 7, privilegioId = 17 });
			usuarioprivilegio.Add(new UsuarioPrivilegio { id = 11, usuarioId = 7, privilegioId = 64 }); 
			 
			builder.HasData(usuarioprivilegio);
		}
	}
}

