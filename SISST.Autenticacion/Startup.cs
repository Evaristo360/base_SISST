using System;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using SISST.Autenticacion.Data;
using SISST.Autenticacion.Models;
using SISST.Autenticacion.Services;
using SISST.Autenticacion.Services.Interfaces;
//using SISST.Autenticacion.Services.Commands;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.OpenApi.Models;
using System.IO;
using SISST.Autenticacion.Repositories;
using AutoMapper;
using SISST.Autenticacion.Proxy.Config;
using SISST.Autenticacion.Proxy;
using SISST.Autenticacion.DataTransferObjects;

namespace SISST.Autenticacion
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
            //estas lineas se usan para mandar llamar el API de catalogos
            services.AddSingleton(new ApiGatewayUrl(Configuration.GetValue<string>("ApiGatewayUrl")));
            services.AddHttpContextAccessor();


            //var dataAssemblyName = typeof(ApplicationDbContext).Assembly.GetName().Name;
            //services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), x =>x.MigrationsAssembly(dataAssemblyName)));

            // DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection"),
                   x => x.MigrationsHistoryTable("__EFMigrationsAutenticacionHistory", "Autenticacion")
               )
            );

            // Identity
            services.AddIdentity<ApplicationUser, ApplicationRol>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

          
            // Identity configuration
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequiredUniqueChars = 0;
            });

            services.AddLocalization();
        

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            //services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IUserService, UserService>();                     
            
            services.AddTransient<IPrivilegioService, PrivilegioService>();
            services.AddTransient<IAreaService, AreaService>();
            services.AddTransient<IAreaAdministradaService, AreaAdministradaService>();
            services.AddTransient<IRolService, RolService>();
            services.AddTransient<IDepartamentoService, DepartamentoService>();

            //estas lineas se usan para mandar llamar el API de catalogos
            services.AddHttpClient<ICatalogoProxy, CatalogoProxy>();


            // API Controllers
            services.AddControllers()
                .AddNewtonsoftJson(); 

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Usuarios Web API",
                    Description = "Servicio para la gestión de usuarios del sistema SISST",
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
                // 20210826 PRME La siguiente línea resolvió el problema de 
                // Can't use schemaId "$PaginationAuth" for type "$Comunes.DTOs.pagination.PaginationAuth". 
                // The same schemaId is already used for type "$SISST.Autenticacion.DataTransferObjects.PaginationAuth.PaginationAuth"
                //c.CustomSchemaIds(type => type.ToString()); 

                // Esto debe conincidir con Properties>>Compilation>>Salida >> Archivos de documentos XML
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, true);
            });

            services.AddAutoMapper(typeof(AutoMapping));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        /// <param name="loggerFactory"></param>
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // The localization middleware must be configured before
            // any middleware which might check the request culture.
            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("bs")
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                // Formatting numbers, dates, etc.
                SupportedCultures = supportedCultures,
                // UI strings that we have localized.
                SupportedUICultures = supportedCultures
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Usuarios Web API");
                c.DocumentTitle = "Usuarios Web API";
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List); // Muestra la primera lista expandida por omisión
                //c.RoutePrefix = string.Empty; // Hace que no se requiere "/swagger" en el URL
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapCustomHealthChecks("SISST Autenticacion WebAPI Availability"); //adds the custom health check endpoint
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SISST V2");
                c.DisplayRequestDuration();
            });

            //Crear archivo log
            loggerFactory.AddFile("Logs/autenticacion-{Date}.txt");
        }
    }
}
