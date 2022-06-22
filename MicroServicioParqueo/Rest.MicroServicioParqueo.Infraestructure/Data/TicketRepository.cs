using Microsoft.EntityFrameworkCore;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using Rest.MicroServicioParqueo.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Infraestructure.Data
{
    public class TicketRepository : ITicketRepository
    {
        private readonly BDParqueoContext _contexto;
        public TicketRepository (BDParqueoContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Ticket> ActualizarTicket(Ticket ticket)
        {
            _contexto.Entry(ticket).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return ticket;
        }

        public async Task<Ticket> ConsultarTicket(int idTicket)
        {
            Ticket ticket = new Ticket();
            ticket = await _contexto.Tickets.FindAsync(idTicket);
            return ticket;
        }

        public async Task<IEnumerable<Ticket>> ConsultarTickets()
        {
            IEnumerable<Ticket> tickets = null;
            tickets = await _contexto.Tickets.ToListAsync();
            return tickets;
        }

        public async Task<bool> EliminarTicket(int IdTicket)
        {
            Ticket ticket = new Ticket();
            ticket = await _contexto.Tickets.FindAsync(IdTicket);
            _contexto.Tickets.Remove(ticket);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return true;
        }

        public async Task<Ticket> IngresarTicket(Ticket ticket)
        {
            _contexto.Tickets.Add(ticket);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return ticket;
        }
    }
}
