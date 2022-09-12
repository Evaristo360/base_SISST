using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using SISST.Proxies.Config;
using Microsoft.AspNetCore.Mvc;
using SISST.Proxies;
using SISST.Proxies.Comunes;
using SISST.Utils;
using SISST.Services;
using SISST.AutoMapper;
using Microsoft.Extensions.Logging;
using SISST.config;
using SISST.Extensions;

namespace SISST
{
    public class Startup
    {
        public static IConfiguration _configuration { get; private set; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureTransientServices(services);
            ConfigureRepositories(services);
            ConfigureEntityFramework(services);

            services.AddSingleton(new AliasWeb(_configuration.GetValue<string>("AliasWeb")));
            // Proxies
            services.AddSingleton(new ApiGatewayUrl(_configuration.GetValue<string>("ApiGatewayUrl")));
            services.AddHttpContextAccessor();

            services.AddHttpClient<IUsuarioProxy, UsuarioProxy>();
            services.AddHttpClient<IIdentityProxy, IdentityProxy>();
            services.AddHttpClient<IPrivilegiosProxy, PrivilegiosProxy>();
            services.AddHttpClient<ICatalogoProxy, CatalogoProxy>();
            services.AddHttpClient<IConfiguracionProxy, ConfiguracionProxy>();
            services.AddHttpClient<IDepartamentoProxy, DepartamentoProxy>();

            services.AddHttpClient<IRolesProxy, RolesProxy>();
            services.AddHttpClient<IAreasProxy, AreasProxy>();
            services.AddHttpClient<IAreasAdministradasProxy, AreasAdministradasProxy>();

            services.AddHttpClient<IArchivoAdjuntoCatalogoProxy, ArchivoAdjuntoCatalogoProxy>();

            //aqui van a ir losmios proxies
            services.AddHttpClient<IReunionesProxy, ReunionesProxy>();

            //fin de los mios

            services.AddScoped<IServicios, Servicios>();
            services.AddScoped<IArchivosAdjuntosService, ArchivosAdjuntosService>();
            services.AddScoped<IArchivoAyudaService, ArchivoAyudaService>();
            services.AddScoped<IArchivoDocumentosOficialesService, ArchivoDocumentosOficialesService>();


            // Razor Pages & MVC
            services.AddRazorPages(o => o.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()));
            services.AddControllers();

            // Add Cookie Authentication
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/home/index/";
                        options.SessionStore = new MemoryCacheTicketStore();
                    });

            //automapper
            services.AddAutoMapperService();
            services.AddControllersWithViews();

            //variables de sesión
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = System.TimeSpan.FromHours(10);
            });

          

        }


        private static void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient<IArchivoAyudaService, ArchivoAyudaService>();
            services.AddTransient<IArchivoDocumentosOficialesService, ArchivoDocumentosOficialesService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            //services.AddSingleton<IArchivoAyudaRepository, ArchivoAyudaRepository>();
        }

        private static void ConfigureEntityFramework(IServiceCollection services)
        {
            var databaseName = _configuration["EntityFramework:DatabaseName"];
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage();                
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            var supportedCultures = new[] { "es-MX"};
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);
            app.UseRouting();

            app.UseAuthorization();
           
            app.UseAuthentication();

            // IMPORTANT: This session call MUST go before UseMvc()
            app.UseSession();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute("Comunes", "Comunes",
                    "Comunes/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("Incidentes", "Incidentes",
                   "Incidentes/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("Laboratorio", "Laboratorio",
                   "Laboratorio/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("Gestion", "Gestion",
                    "Gestion/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("GestionIP", "GestionIP",
                    "GestionIP/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("GestionRL", "GestionRL",
                    "GestionRL/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("GestionUI", "GestionUI",
                  "GestionUI/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute("Admin", "Admin",
                    "Admin/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapAreaControllerRoute("Diagnostico", "Diagnostico",
                   "Diagnostico/{controller}/{action}/{id?}");

                endpoints.MapAreaControllerRoute(
                    name: "Incidentes",
                    areaName: "Incidentes",
                    pattern: "Incidentes/{controller}/{action}/{id?}");

                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                
            });
            Rotativa.AspNetCore.RotativaConfiguration.Setup(env.ContentRootPath, "Rotativa");

            //Crear archivo log
            loggerFactory.AddFile("Logs/sisstFrontEnd-{Date}.txt");
        }
    }
}
