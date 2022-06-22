using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Rest.MicroServicioParqueo.Application.Services;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Repository;
using Rest.MicroServicioParqueo.Infraestructure.Data;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API
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
            services.AddDbContext<BDParqueoContext>(options =>
             options.UseSqlServer(
                 Configuration.GetConnectionString("DefaultConnection")));

            services.AddCors();
            services.AddControllers();
            services.AddSingleton(Log.Logger);
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<IParametroService, ParametroService>();
            services.AddScoped<IPagoService, PagoService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IVehiculoService, VehiculoService>();
            services.AddScoped<IVehiculoRepository, VehiculoRepository>();
            services.AddScoped<IPagoRepository, PagoRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rest.MicroServicioParqueo.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rest.MicroServicioParqueo.API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

