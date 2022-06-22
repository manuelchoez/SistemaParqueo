using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rest.MicroServicioParqueo.Application.Constantes;
using Rest.MicroServicioParqueo.Infraestructure.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API
{
    public class Program
    {
        public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
       .SetBasePath(Directory.GetCurrentDirectory())
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
       .Build();

        public static void Main(string[] args)
        {
            Log.Logger = new SerilogHelper(Configuration).SerilogConfiguracion(Assembly.GetExecutingAssembly().GetName().Name, ConstantesRestMicroServicioParqueo.CadenaConexion).CreateBootstrapLogger();
            try
            {
                Log.Information("Inicio Aplicacion");
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "fatal");
            }
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                }).UseSerilog();
    }
}
