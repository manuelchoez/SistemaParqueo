using Rest.MicroServicioParqueo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Dominio.Repository
{
    public interface IPersonaRepository
    {
        Task<IEnumerable<Persona>> ConsultarPersonas();
        Task<Persona> ConsultarPersona(string identificacion);
        Task<Persona> CrearPersona(Persona persona);
        Task<Persona> ActualizarPersona(Persona persona);
        Task<bool> EliminarPersona(int idPersona);


    }
}
