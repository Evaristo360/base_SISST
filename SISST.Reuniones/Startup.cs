using SISST.Reuniones.Data;
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
using Microsoft.Extensions.Logging;
using SISST.Reuniones.Services;


namespace SISST.Reuniones
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
           //services.AddSingleton(new ApiGatewayUrl(Configuration.GetValue<string>("ApiGatewayUrl")));
           //services.AddHttpContextAccessor();

            //para que jale pues jaja la expresion lambda es para conservar nombred e migracion + el schema
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
             m => m.MigrationsHistoryTable("_EFMigrationHistory", "Reuniones")));

          
           // services.AddLocalization();

            //la clase IReunionesServices pertenece a ReunionesServices esto se hace para
            // que este a nivel de los controladores
            services.AddTransient<IReunionesServices, ReunionesServices>();
            services.AddTransient<IDocumentosService, DocumentosService>();
            services.AddTransient<IParticipantesService, ParticipantesService>();
            //para el mediator
            // services.AddMediatR(Assembly.Load("ReunionCreateEventHandler"));


            // API Controllers
            services.AddControllers()
                .AddNewtonsoftJson();

            var secretKey = Encoding.ASCII.GetBytes(
             Configuration.GetValue<string>("SecretKey")
         );

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
                    Title = "Catálogo de Reuniones API ",
                    Description = "Servicio para la gestión de reuniones del sistema SISST",
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

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath, false);
            });

           
            // services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {

           


                if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            

            app.UseRouting();

            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
              //  endpoints.MapHealthChecks("SISST Catalog WebAPI Availability");

            });

           app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catálogo de Reuniones API (CdC)");
                c.DocumentTitle = "Catálogo de Reuniones API (CdC)";
                c.DocExpansion(DocExpansion.List); // Muestra la primera lista expandida por omisión
                //c.RoutePrefix = string.Empty; // Hace que no se requiere "/swagger" en el URL
            });



        }
    }
}
