using System;
using System.Collections.Generic;

#nullable disable

namespace Rest.MicroServicioParqueo.Dominio.Entidades
{
    public partial class Ticket
    {
        public Ticket()
        {
            Pagos = new HashSet<Pago>();
        }

        public int IdTicket { get; set; }
        public Guid? Secuencial { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public DateTime? FechaSalida { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
    }
}
