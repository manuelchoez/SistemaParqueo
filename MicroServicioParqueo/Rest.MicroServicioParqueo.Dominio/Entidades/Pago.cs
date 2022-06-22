using System;
using System.Collections.Generic;

#nullable disable

namespace Rest.MicroServicioParqueo.Dominio.Entidades
{
    public partial class Pago
    {
        public int IdPago { get; set; }
        public int? IdTicket { get; set; }
        public int? IdPersona { get; set; }
        public decimal? Valor { get; set; }
        public DateTime? FechaPago { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual Ticket IdTicketNavigation { get; set; }
    }
}
