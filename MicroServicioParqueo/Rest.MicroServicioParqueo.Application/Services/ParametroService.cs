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
    public class ParametroService : IParametroService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly ILogger _logger;

        public ParametroService(IParametroRepository parametroRepository, ILogger logger)
        {
            _parametroRepository = parametroRepository;
            _logger = logger;
        }

        public  async Task<IEnumerable<Parametro>> ConsultarParametros()
        {
            IEnumerable<Parametro> parametros = null;
            try
            {
                parametros = await _parametroRepository.ConsultarParametros();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsultarParametros");
                throw;
            }
            return parametros;
        }
    }
}
