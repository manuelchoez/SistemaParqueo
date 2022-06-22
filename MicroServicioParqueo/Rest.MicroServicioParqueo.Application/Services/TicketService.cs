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
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketService;
        private readonly ILogger _logger;

        public TicketService(ITicketRepository ticketService, ILogger logger)
        {
            _ticketService = ticketService;
            _logger = logger;
        }
        public async Task<Ticket> ActualizarTicket(Ticket ticket)
        {
            try
            {
                await _ticketService.ActualizarTicket(ticket);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ActualizarTicket");
                throw;
            }
            return ticket;
        }

        public async Task<Ticket> ConsultarTicket(int idTicket)
        {
            Ticket ticket = new Ticket();
            try
            {
                ticket = await _ticketService.ConsultarTicket(idTicket);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsultarTicket");
                throw;
            }
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> ConsultarTickets()
        {
            IEnumerable<Ticket> tickets = null;
            try
            {
                tickets = await _ticketService.ConsultarTickets();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsultarTickets");
                throw;
            }
            return tickets;
        }

        public async Task<bool> EliminarTicket(int IdTicket)
        {
            bool retorno = false;
            try
            {
                retorno = await _ticketService.EliminarTicket(IdTicket);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error EliminarTicket");
                throw;
            }
            return retorno;
        }

        public async Task<Ticket> IngresarTicket(Ticket ticket)
        {
            try
            {
                await _ticketService.IngresarTicket(ticket);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error IngresarTicket");
                throw;
            }
            return ticket;
        }
    }
}
