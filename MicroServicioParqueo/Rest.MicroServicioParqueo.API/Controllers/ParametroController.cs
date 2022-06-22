using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API.Controllers
{
    [Route("api/parametro")]
    [ApiController]
    public class ParametroController : ControllerBase
    {
        private readonly IParametroService _parametroService;

        public ParametroController(IParametroService parametroService)
        {
            _parametroService = parametroService;
        }

        [HttpGet]
        [Route("ConsultarParametros")]
        public async Task<IEnumerable<Parametro>> ConsultarParametros()
        {
            return await _parametroService.ConsultarParametros();
        }
    }
}
