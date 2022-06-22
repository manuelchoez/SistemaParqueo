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
    public class PagoService : IPagoService
    {
        private readonly IPagoRepository _pagoRepository;
        private readonly ILogger _logger;

        public PagoService (IPagoRepository pagoRepository, ILogger logger)
        {
            _pagoRepository = pagoRepository;
            _logger = logger;
        }

        public async Task<Pago> RealizarPago(Pago pago)
        {           
            try
            {
             await  _pagoRepository.RealizarPago(pago);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error RealizarPago");                
                throw;
            }
            return pago;
        }
    }
}
