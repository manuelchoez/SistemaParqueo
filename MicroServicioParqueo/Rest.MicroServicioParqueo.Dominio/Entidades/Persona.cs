using System;
using System.Collections.Generic;

#nullable disable

namespace Rest.MicroServicioParqueo.Dominio.Entidades
{
    public partial class Persona
    {
        public Persona()
        {
            Pagos = new HashSet<Pago>();
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdPersona { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<Pago> Pagos { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
