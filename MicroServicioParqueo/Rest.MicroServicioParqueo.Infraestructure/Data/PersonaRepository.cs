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
    public class PersonaRepository : IPersonaRepository
    {
        private readonly BDParqueoContext _contexto;

        public PersonaRepository(BDParqueoContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<Persona> ActualizarPersona(Persona persona)
        {
            _contexto.Entry(persona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return persona;
        }

        public async Task<Persona> ConsultarPersona(int idPersona)
        {
            Persona persona = new Persona();
            persona = await _contexto.Personas.FindAsync(idPersona);
            return persona; 
        }

        public async Task<IEnumerable<Persona>> ConsultarPersonas()
        {
            IEnumerable<Persona> personas = null;
            personas = await _contexto.Personas.ToListAsync();
            return personas;
        }

        public async Task<Persona> CrearPersona(Persona persona)
        {
            _contexto.Personas.Add(persona);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return persona;
        }

        public async Task<bool> EliminarPersona(int idPersona)
        {
            Persona persona = new Persona();
            persona = await _contexto.Personas.FindAsync(idPersona);
            _contexto.Personas.Remove(persona);
            await _contexto.SaveChangesAsync().ConfigureAwait(true);
            return true;
        }
    }
}
