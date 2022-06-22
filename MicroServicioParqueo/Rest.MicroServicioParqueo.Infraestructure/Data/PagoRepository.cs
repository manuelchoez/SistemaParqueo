using Rest.MicroServicioParqueo.Dominio.Entidades;
using Rest.MicroServicioParqueo.Dominio.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Infraestructure.Data
{

    public class PagoRepository : IPagoRepository
    {
        private readonly BDParqueoContext _contexto;

        public PagoRepository(BDParqueoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<Pago> RealizarPago(Pago pago)
        {
            _contexto.Pagos.Add(pago);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return pago;
        }
    }
}
