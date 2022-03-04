using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Serilog.Events;
using Microsoft.AspNetCore.Builder;
using SISST.API.Gateway.Middlewares;

namespace SISST.API.Gateway
{
    public static class Program
    {
        public static IWebHost BuildWebHost(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args);
            // Ocelot configuration file
            builder.ConfigureAppConfiguration(
                          ic => ic.AddJsonFile(Path.Combine("configuration",
                                                            "configuration.json")))
                    //.ConfigureServices(s =>
                    //{
                    //    s.AddSingleton(builder);

                    //})
                    .UseStartup<Startup>()
                    .UseSerilog((_, config) =>
                    {
                        config
                            .MinimumLevel.Information()
                            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                            .Enrich.FromLogContext()
                            .WriteTo.File(@"Logs\log.txt", rollingInterval: RollingInterval.Day);
                    });
                    //.Configure(app =>
                    //{
                    //    app.UseMiddleware<RequestResponseLoggingMiddleware>();
                        
                    //});
            var host = builder.Build();
            return host;
        }
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }
    }
}
