using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using Rest.MicroServicioParqueo.Dominio.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Application.Services
{
    public class VehiculoService : IVehiculoService
    {
        private readonly IVehiculoRepository _vehiculoRepository;
        private readonly ILogger _logger;

        public VehiculoService(IVehiculoRepository vehiculoRepository, ILogger logger)
        {
            _vehiculoRepository = vehiculoRepository;
            _logger = logger;
        }

        public async Task<Vehiculo> ActualizarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                await _vehiculoRepository.ActualizarVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ActualizarVehiculo");
                throw;
            }
            return vehiculo;
        }

        public async Task<Vehiculo> ConsutarVehiculo(int IdVehiculo)
        {
            Vehiculo vehiculo = new Vehiculo();
            try
            {
                vehiculo = await _vehiculoRepository.ConsutarVehiculo(IdVehiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsutarVehiculo");
                throw;
            }
            return vehiculo;
        }

        public async Task<IEnumerable<Vehiculo>> ConsutarVehiculos()
        {
            IEnumerable<Vehiculo> vehiculos = null;
            try
            {
                vehiculos = await _vehiculoRepository.ConsutarVehiculos();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsutarVehiculos");
                throw;
            }
            return vehiculos;
        }

        public async Task<Vehiculo> CrearVehiculo(Vehiculo vehiculo)
        {
            try
            {
                await _vehiculoRepository.CrearVehiculo(vehiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error CrearVehiculo");
                throw;
            }
            return vehiculo;
        }

        public async Task<bool> EliminarVehiculo(int IdVehiculo)
        {
            bool retorno = false;
            try
            {
                await _vehiculoRepository.EliminarVehiculo(IdVehiculo);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error EliminarVehiculo");
                throw;
            }
            return retorno;
        }
    }
}
