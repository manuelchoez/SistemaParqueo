using Moq;
using Rest.MicroServicioParqueo.API.Controllers;
using Rest.MicroServicioParqueo.Application.Services.Interfaces;
using Rest.MicroServicioParqueo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rest.MicroServicioParqueo.Test
{
    public class PersonaValidatorShould
    {
        [Fact]
        public async void ConsultarPersona_ShouldReturnsPersona()
        {
            //datos
            var personaServicio = new Mock<IPersonaService>();
            Persona persona = new Persona();
            personaServicio.Setup(_ => _.ConsultarPersona(1)).ReturnsAsync(persona);
            PersonaController personaController = new PersonaController(personaServicio.Object);            
            persona.IdPersona = 0;
            persona.Nombres = "Manuel";
            persona.Apellidos = "Choez";
            await personaController.CrearPersona(persona);

            //accion
            var personaResult = await personaController.ConsultarPersona(1);

            //afirmacion
            Assert.NotNull(personaResult);    
        }

     

        [Fact]
        public async void CrearPersona_ShouldReturnsPersona()
        {
            //datos
            var personaServicio = new Mock<IPersonaService>();
            Persona persona = new Persona();
            personaServicio.Setup(_ => _.CrearPersona(persona)).ReturnsAsync(persona);
            PersonaController personaController = new PersonaController(personaServicio.Object);
            persona.IdPersona = 0;
            persona.Nombres = "Manuel";
            persona.Apellidos = "Choez";
            //accion
            var personaResult = await personaController.CrearPersona(persona);

            //afirmacion
            Assert.NotNull(personaResult);
        }
        
        [Fact]
        public async void ActualizarPersona_ShouldReturnsPersona()
        {
            //datos
            var personaServicio = new Mock<IPersonaService>();
            Persona persona = new Persona();
            personaServicio.Setup(_ => _.ActualizarPersona(persona)).ReturnsAsync(persona);
            PersonaController personaController = new PersonaController(personaServicio.Object);
            persona.IdPersona = 1;
            persona.Nombres = "Jose";
            persona.Apellidos = "Choez";
            //accion
            var personaResult = await personaController.ActualizarPersona(persona);

            //afirmacion
            Assert.NotNull(personaResult);
        }

        




    }
}
