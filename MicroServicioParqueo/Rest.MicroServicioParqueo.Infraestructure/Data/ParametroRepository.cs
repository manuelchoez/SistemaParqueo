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
    public class ParametroRepository : IParametroRepository
    {
        private readonly BDParqueoContext _contexto;

        public ParametroRepository(BDParqueoContext contexto)
        {
            _contexto = contexto;
        }
        public async Task<IEnumerable<Parametro>> ConsultarParametros()
        {
            IEnumerable<Parametro> parametros = null;
            parametros = await _contexto.Parametros.ToListAsync();
            return parametros;
        }
    }
}
