using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Models.Configuration;

namespace SISST.Autenticacion.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRol, int>
    {


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);                
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            
            builder.HasDefaultSchema("Autenticacion");
            builder.ApplyConfiguration(new AreaConfiguration());

            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new RolConfiguration());

            builder.ApplyConfiguration(new DepartamentoConfiguration());
            builder.ApplyConfiguration(new DepartamentoDetConfiguration());

            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("UsuarioRoles");
                var ur = new System.Collections.Generic.List<IdentityUserRole<int>>();
                ur.Add(new IdentityUserRole<int>
                {
                    UserId=1,
                    RoleId=1
                });
                // PRME Se agregaron otros roles a usuarios
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 2
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 2
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 2
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 5,
                    RoleId = 2
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 6,
                    RoleId = 2
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 3,
                    RoleId = 7
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 7
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 5,
                    RoleId = 7
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 4,
                    RoleId = 8
                });
                ur.Add(new IdentityUserRole<int>
                {
                    UserId = 5,
                    RoleId = 8
                });
                entity.HasData(ur);
            });

            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("UsuarioClaims");
            });

            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("UsuarioLogins");
            });

            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("RolClaims");

            });

            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("UsuarioTokens");
            });

            //nuevos modelos
            builder
            .ApplyConfiguration(new PrivilegioConfiguration());

            builder
               .ApplyConfiguration(new RolPrivilegioConfiguration());


            builder
               .ApplyConfiguration(new UsuarioPrivilegioConfiguration());
                  


            builder.Entity<UsuarioPrivilegio>()
                .HasOne(up => up.usuario)
                .WithMany(p => p.usuarioPrivilegios)
                .HasForeignKey(up => up.usuarioId);

            builder
                .ApplyConfiguration(new AreaAdministradaConfiguration());
            
            builder.Entity<AreaAdministrada>()    
                .HasOne(u => u.Usuario).WithMany(u => u.areaAdministrada).HasForeignKey(p=>p.IdUsuario)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AreaAdministrada>()
                .HasOne(u => u.Rol).WithMany(u => u.areaAdministrada).HasForeignKey(p => p.IdRol)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<AreaAdministrada>()
                .HasOne(u => u.Area).WithMany(u => u.areaAdministrada).HasForeignKey(p => p.IdArea)
                .OnDelete(DeleteBehavior.NoAction);


        }

        public DbSet<UsuarioPrivilegio> usuarioPrivilegio { get; set; }
        public DbSet<Privilegio> privilegio { get; set; }
        public DbSet<RolPrivilegio> rolPrivilegio { get; set; }
        public DbSet<Area> area { get; set; }
        public DbSet<AreaAdministrada> areaAdministrada { get; set; }
        public DbSet<Departamento> departamento { get; set; }
        public DbSet<DepartamentoDet> departamentoDet { get; set; }

        
    }
}
