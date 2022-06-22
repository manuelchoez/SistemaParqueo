using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API.Controllers
{
    [Route("api/vehiculo")]
    [ApiController]
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService _vehiculoService;

        public VehiculoController(IVehiculoService vehiculoService)
        {
            _vehiculoService = vehiculoService;
        }

        [HttpGet]
        [Route("ConsutarVehiculo")]
        public async Task<Vehiculo> ConsutarVehiculo(int IdVehiculo)
        {
            return await _vehiculoService.ConsutarVehiculo(IdVehiculo);
        }

        [HttpGet]
        [Route("ConsutarVehiculos")]
        public async Task<IEnumerable<Vehiculo>> ConsutarVehiculos()
        {
            return await _vehiculoService.ConsutarVehiculos();
        }

        [HttpPost]
        [Route("CrearVehiculo")]
        public async Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo)
        {
            return await _vehiculoService.CrearVehiculo(vehiculo);
        }

        [HttpPut]
        [Route("ActualizarVehiculo")]
        public async Task<Vehiculo> ActualizarVehiculo(Vehiculo vehiculo)
        {
            return await _vehiculoService.ActualizarVehiculo(vehiculo);
        }

        [HttpDelete]
        [Route("EliminarVehiculo")]
        public async Task<bool> EliminarVehiculo(int idVehiculo)
        {
            return await _vehiculoService.EliminarVehiculo(idVehiculo);
        }
    }
}
