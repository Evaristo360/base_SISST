using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using SISST.Servicios.Configuration;
using SISST.Servicios.Daemons;
using SISST.Servicios.Proxy;
using SISST.Servicios.Services;
using SISST.Servicios.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace SISST.DatosBasicos.EnvioArchivos
{
    class Program //: IDesignTimeDbContextFactory<WTCContext>
    {
        public static async Task Main(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            Log.Logger = new LoggerConfiguration()
               .ReadFrom.Configuration(configuration)
               .WriteTo.Console()
               .CreateLogger();

            try
            {
                Log.Logger.Information("Preparing SISST.Servicios");

                var builder = new HostBuilder().ConfigureAppConfiguration(
                    ConfigAppConfiguration
                ).ConfigureServices((hostContext, services) =>
                {
                    services.AddOptions();
                    services.Configure<ServiceConfig>(hostContext.Configuration.GetSection("Daemon"));

                    services.AddHttpContextAccessor();
                    services.AddHttpClient<IDatosBasicosProxy, DatosBasicosProxy>();
                    services.AddHttpClient<IIdentityProxy, IdentityProxy>();
                    services.AddHttpClient<ICatalogoProxy, CatalogoProxy>();
                    services.AddHttpClient<IProgramasProxy, ProgramasProxy>();
                    services.AddHttpClient<IAreaProxy, AreaProxy>();

                    services.AddSingleton<IGeneracionFileSendService, GeneracionFileSendService>();
                    services.AddSingleton<IGeneracionFileService, GeneracionFileService>();
                    services.AddSingleton<IFTPService, FTPService>();
                    services.AddHostedService<GeneracionDaemon>();
                    services.AddHostedService<ProgramasAvanceMensualDaemon>();


                }
                )
                .UseSerilog()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                    logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.None);
                }
                )
#if DEBUG
                .Build();

                await builder.StartAsync();
#else
                .RunAsServiceAsync();
#endif
                Log.Logger.Information("SISST.Servicios has started");
            }
            catch (Exception ex)
            {
                Log.Logger.Fatal(ex, "SISST.Servicios start-up failed");
            }
        }

        private static void ConfigAppConfiguration(HostBuilderContext context, IConfigurationBuilder config)
        {
            config.AddEnvironmentVariables();
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }
    }
}
