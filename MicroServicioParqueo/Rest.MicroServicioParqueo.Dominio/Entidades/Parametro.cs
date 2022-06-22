using System;
using System.Collections.Generic;

#nullable disable

namespace Rest.MicroServicioParqueo.Dominio.Entidades
{
    public partial class Parametro
    {
        public int IdParametro { get; set; }
        public string TipoVehiculo { get; set; }
        public decimal? Tarifa { get; set; }
        public string UnidadTiempo { get; set; }
    }
}
