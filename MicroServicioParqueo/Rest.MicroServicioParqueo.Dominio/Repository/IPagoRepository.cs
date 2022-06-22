using Rest.MicroServicioParqueo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Dominio.Repository
{
    public interface IPagoRepository
    {
        Task<Pago> RealizarPago(Pago pago);        
    }
}
