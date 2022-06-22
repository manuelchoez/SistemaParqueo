using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API.Controllers
{
    [Route("api/ticket")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        [Route("ConsultarTicket")]
        public async Task<Ticket> ConsultarTicket(int idTicket)
        {
            return await _ticketService.ConsultarTicket(idTicket);
        }

        [HttpGet]
        [Route("ConsultarTickets")]
        public async Task<IEnumerable<Ticket>> ConsultarTickets()
        {
            return await _ticketService.ConsultarTickets();
        }

        [HttpPut]
        [Route("ActualizarTicket")]
        public async Task<Ticket> ActualizarTicket(Ticket ticket)
        {
            return await _ticketService.ActualizarTicket(ticket);
        }

        [HttpDelete]
        [Route("EliminarTicket")]
        public async Task<bool> EliminarTicket(int idTicket)
        {
            return await _ticketService.EliminarTicket(idTicket);
        }

        [HttpPost]
        [Route("IngresarTicket")]
        public async Task<Ticket> IngresarTicket(Ticket ticket)
        {
            return await _ticketService.IngresarTicket(ticket);
        }
    }
}
