using System;
using System.Collections.Generic;

#nullable disable

namespace Rest.MicroServicioParqueo.Dominio.Entidades
{
    public partial class Vehiculo
    {
        public int IdVehiculo { get; set; }
        public int? IdPersona { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string TipoVehiculo { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
    }
}
