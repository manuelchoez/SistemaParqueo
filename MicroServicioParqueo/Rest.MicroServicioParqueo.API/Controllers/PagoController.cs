using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API.Controllers
{
    [Route("api/pago")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly IPagoService _pagoService;

        public PagoController(IPagoService pagoService)
        {
            _pagoService = pagoService;
        }

        [HttpPost]
        [Route("RealizarPago")]
        public async Task<Pago> ConsultarClientes(Pago pago)
        {           
            return await _pagoService.RealizarPago(pago);
        }
    }
}
