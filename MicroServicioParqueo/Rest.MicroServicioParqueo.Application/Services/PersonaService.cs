using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using Rest.MicroServicioParqueo.Dominio.Repository;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rest.MicroServicioParqueo.Application.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IPersonaRepository _personaRepository;
        private readonly ILogger _logger;
        public PersonaService(IPersonaRepository personaRepository, ILogger logger)
        {
            _personaRepository = personaRepository;
            _logger = logger;
        }

        public async Task<Persona> ActualizarPersona(Persona persona)
        {

            try
            {
              await  _personaRepository.ActualizarPersona(persona);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ActualizarPersona");
                throw;
            }
            return persona;
        }

        public async Task<Persona> ConsultarPersona(int idPersona)
        {
            Persona persona = new Persona();
            try
            {
                persona = await _personaRepository.ConsultarPersona(idPersona);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsultarPersona");
                throw;
            }
            return persona;
        }

        public async Task<IEnumerable<Persona>> ConsultarPersonas()
        {
            IEnumerable<Persona> personas = null;
            try
            {
                personas = await _personaRepository.ConsultarPersonas();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error ConsultarPersonas");
                throw;
            }
            return personas;
        }

        public async Task<Persona> CrearPersona(Persona persona)
        {
            try
            {
                await _personaRepository.CrearPersona(persona);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error CrearPersona");
                throw;
            }
            return persona;
        }

        public async Task<bool> EliminarPersona(int idPersona)
        {
            bool retorno = false;   
            try
            {
                retorno =await _personaRepository.EliminarPersona(idPersona);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error EliminarPersona");
                throw;
            }
            return retorno;
        }
    }
}
