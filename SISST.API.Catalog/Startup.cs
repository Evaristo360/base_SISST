using SISST.Catalog.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SISST.Catalog.Services;
using SISST.Catalog.DataTransferObjects.Catalogo;
using AutoMapper;
using Comunes.IocExtensions;
using Microsoft.Extensions.Logging;
using SISST.Catalog.Repositories;

namespace SISST.Catalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"),
                   x => x.MigrationsHistoryTable("__EFMigrationsHistoryCdC", "Catalogo")
               )
            );

            // Event handlers

            // Query services
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ICatalogoService, CatalogoService>();
            services.AddTransient<IConfiguracionService, ConfiguracionService>();
            services.AddTransient<IArchivoAdjuntoService, ArchivoAdjuntoService>();
            services.AddTransient<IFTPService, FTPService>();
            services.AddTransient<IFechasCorteService, FechasCorteService>();
            services.AddControllers()
                .AddNewtonsoftJson();

            // Sobre Swagger
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-3.1&tabs=visual-studio
            //
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Catálogo de Catálogos API",
                    Description = "Servicio para la gestión de catálogos \"simples\" del sistema SISST",
                    //TermsOfService = new Uri("https://example.com/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "INEEL",
                        Email = string.Empty,
                        Url = new Uri("https://ineel.mx"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Términos de uso",
                        Url = new Uri("https://ineel.mx/sisst/license"),
                    }
                });

                // Esto debe conincidir con Properties>>Compilation>>Salida >> Archivos de documentos XML
                var xmlFile =  $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });

            // Add Authentication
            var secretKey = Encoding.ASCII.GetBytes(
                Configuration.GetValue<string>("SecretKey")
            );

            //add health checks
            services.AddHealthChecks()
                .AddSqlServer(Configuration.GetConnectionString("DefaultConnection"));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddAutoMapper(typeof(AutoMapping));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseExceptionHandlerMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapCustomHealthChecks("SISST Catalog WebAPI Availability"); //adds the custom health check endpoint
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catálogo de Catálogos API (CdC)");
                c.DocumentTitle = "Catálogo de Catálogos API (CdC)";
                c.DocExpansion(DocExpansion.List); // Muestra la primera lista expandida por omisión
                //c.RoutePrefix = string.Empty; // Hace que no se requiere "/swagger" en el URL
            });

            //Crear archivo log
            loggerFactory.AddFile("Logs/catalogos-{Date}.txt");
        }
    }
}
