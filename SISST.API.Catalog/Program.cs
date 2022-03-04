using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace SISST.Catalog
{
    public class Program
    {
        public static void Main(string[] args)
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
                Log.Information("Preparing SISST.Catalog");
                var host = CreateHostBuilder(args).Build();

                Log.Information("Deploying DB migrations for SISST.Catalog");
                using (var scope = host.Services.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<Data.ApplicationDbContext>();
                    db.Database.Migrate();
                }

                Log.Information("Starting SISST.Catalog");
                host.Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Application start-up failed");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
