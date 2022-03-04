using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;


namespace SISST.Autenticacion.Models.Configuration
{
    public class RolConfiguration : IEntityTypeConfiguration<ApplicationRol>
    {
		public void Configure(EntityTypeBuilder<ApplicationRol> builder)
		{
			builder.ToTable("Rol");
			builder.HasKey(d => d.Id);
			builder
			   .Property(m => m.Id)
			   .UseIdentityColumn();
			builder.Property(d => d.Activo).IsRequired();
			builder.Property(d => d.Prioridad).IsRequired();
			builder.Property(x => x.Descripcion).IsRequired().HasColumnType("VARCHAR").HasMaxLength(150);
			builder.Property(x => x.NormalizedName).IsRequired().HasColumnType("VARCHAR").HasMaxLength(256);
			builder.Property(x => x.Name).IsRequired().HasColumnType("VARCHAR").HasMaxLength(256);

			var roles = new List<ApplicationRol>();

			//mayor prioriodad significa que se le dará preferencia al asignarse el rol activo
			roles.Add(new ApplicationRol
			{
				Id=1,
				Name = "Administrador",
				NormalizedName= "ADMIN",
				Descripcion = "El Administrador tiene acceso al Panel de control general del sistema.",
				Activo=true,
				Prioridad=5,
				IdNivelJerarquico = 3632
			});
			roles.Add(new ApplicationRol
			{
				Id = 2,
				Name = "Responsable local de SST",
				NormalizedName = "RSA",
				Descripcion = "Responsable local de SST",
				Activo = true,
				Prioridad = 2,
				IdNivelJerarquico = 3635
			});
			roles.Add(new ApplicationRol
			{
				Id = 3,
				Name = "Consulta",
				NormalizedName = "consulta",
				Descripcion = "Usuario que consulta información",
				Activo = true,
				Prioridad = 1,
				IdNivelJerarquico = 3635
			});
			roles.Add(new ApplicationRol
			{
				Id = 4,
				Name = "Responsable de proceso / área",
				NormalizedName = "JDT",
				Descripcion = "Responsable de proceso / área",
				Activo = true,
				Prioridad = 1,
				IdNivelJerarquico = 3635
			});
			roles.Add(new ApplicationRol
			{
				Id = 5,
				Name = "Integrante de la CSH",
				NormalizedName = "CSH",
				Descripcion = "Integrante de la CSH ",
				Activo = true,
				Prioridad = 1,
				IdNivelJerarquico = 3635
			});
			roles.Add(new ApplicationRol
			{
				Id = 6,
				Name = "Aprobador",
				NormalizedName = "AP",
				Descripcion = "Aprobador ",
				Activo = true,
				Prioridad = 1,
				IdNivelJerarquico = 3635
			});
			roles.Add(new ApplicationRol
			{
				Id = 7,
				Name = "Responsable regional de SST",
				NormalizedName = "RSR",
				Descripcion = "Responsable regional de SST",
				Activo = true,
				Prioridad = 3,
				IdNivelJerarquico = 3634
			});
			roles.Add(new ApplicationRol
			{
				Id = 8,
				Name = "Responsable nacional de SST",
				NormalizedName = "RSN",
				Descripcion = "Responsable nacional de SST",
				Activo = true,
				Prioridad = 4,
				IdNivelJerarquico = 3633
			});

            roles.Add(new ApplicationRol
            {
                Id = 9,
                Name = "GestionRL",
                NormalizedName = "GESTIONRL",
                Descripcion = "GestionRL",
                Activo = true,
                Prioridad = 1,
                IdNivelJerarquico = 3632
            });

			roles.Add(new ApplicationRol
			{
				Id = 10,
				Name = "Gerente Laboratorio",
				NormalizedName = "GERLAB",
				Descripcion = "Gerente Laboratorio",
				Activo = true,
				Prioridad = 2,
				IdNivelJerarquico = 3635
			});

			roles.Add(new ApplicationRol
			{
				Id = 11,
				Name = "Metrólogo",
				NormalizedName = "Metrólogo",
				Descripcion = "Metrólogo Laboratorio",
				Activo = true,
				Prioridad = 2,
				IdNivelJerarquico = 3635
			});

			builder.HasData(roles);

		}
	}
}
