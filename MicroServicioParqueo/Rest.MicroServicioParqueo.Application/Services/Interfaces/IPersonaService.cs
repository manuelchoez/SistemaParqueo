using Rest.MicroServicioParqueo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Application.Services.Interfaces
{
    public interface IPersonaService
    {
        Task<IEnumerable<Persona>> ConsultarPersonas();
        Task<Persona> ConsultarPersona(int idPersona);
        Task<Persona> CrearPersona(Persona persona);
        Task<Persona> ActualizarPersona(Persona persona);
        Task<bool> EliminarPersona(int idPersona);
    }
}
