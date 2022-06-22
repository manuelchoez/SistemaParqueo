using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.API.Controllers
{
    [Route("api/persona")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;

        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        [HttpGet]
        [Route("ConsultarPersona")]
        public async Task<Persona> ConsultarPersona(int idPersona)
        {
            return await _personaService.ConsultarPersona(idPersona);
        }

        [HttpGet]
        [Route("ConsultarPersonas")]
        public async Task<IEnumerable<Persona>> ConsultarPersonas()
        {
            return await _personaService.ConsultarPersonas();
        }

        [HttpPut]
        [Route("ActualizarPersona")]
        public async Task<Persona> ActualizarPersona(Persona persona)
        {
            return await _personaService.ActualizarPersona(persona);
        }

        [HttpPost]
        [Route("CrearPersona")]
        public async Task<Persona> CrearPersona(Persona persona)
        {
            return await _personaService.CrearPersona(persona);
        }

        [HttpDelete]
        [Route("EliminarPersona")]
        public async Task<bool> EliminarPersona(int IdPersona)
        {
            return await _personaService.EliminarPersona(IdPersona);
        }
    }
}
