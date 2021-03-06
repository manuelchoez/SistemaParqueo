using Rest.MicroServicioParqueo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Dominio.Repository
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> ConsultarTickets();
        Task<Ticket> ConsultarTicket(int idTicket);
        Task<Ticket> IngresarTicket(Ticket ticket);
        Task<Ticket> ActualizarTicket(Ticket ticket);
        Task<bool> EliminarTicket(int IdTicket);


    }
}
