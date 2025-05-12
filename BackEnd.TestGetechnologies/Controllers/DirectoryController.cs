using BackEnd.TestGetechnologies.Service.Persona;
using BackEnd.TestGetechnologies.Service.Persona.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.TestGetechnologies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryController : ControllerBase
    {
        private IPersonServices personServices;

        public DirectoryController(IPersonServices _personServices)
        {
            personServices = _personServices;
        }

        /// <summary>
        /// Consulta de Persona filtrado por identificacion
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        [HttpGet("findPersonaByIdentificacion/{identificacion}")]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> getPersonByIdAsync([FromRoute] Guid identificacion)
        {
            return Ok(await personServices.GetPersonById(identificacion));
        }

        /// <summary>
        /// Consulta de todas las Personas
        /// </summary>
        /// <returns></returns>
        [HttpGet("findPersonas")]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> getPersonAllAsync()
        {
            return Ok(await personServices.GetAllPerson());
        }


        /// <summary>
        /// Eliminar Persona por identificacion
        /// </summary>
        /// <param name="identificacion"></param>
        /// <returns></returns>
        [HttpPost("deletePersonaByIdentificacion")]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> deletePersonByIdAsync([FromBody] DeletePersonRQ request)
        {
            return Ok(await personServices.DeletePerson(request.identificacion));
        }

        /// <summary>
        /// Agregar Persona
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("storePersona")]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> addPerson([FromBody] PersonRQ request)
        {
            return Ok(await personServices.AddPerson(request));
        }
    }
}
