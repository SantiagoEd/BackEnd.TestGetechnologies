using BackEnd.TestGetechnologies.Service.Common.Domain;
using BackEnd.TestGetechnologies.Service.Persona.Request;
using BackEnd.TestGetechnologies.Service.Persona.Response;
using System.Runtime.CompilerServices;

namespace BackEnd.TestGetechnologies.Service.Persona.Transform
{
    public static class TransformPerson
    {
        public static Models.Persona Transform(this PersonDto person) 
        {
            return new Models.Persona
            {
                 apellidoMaterno = person.apellidoMaterno,
                 apellidoPaterno = person.apellidoPaterno,
                 identificacion = person.identificacion,
                 nombre = person.nombre
            };
        }

        public static GetAllPersonRS Transform(this IEnumerable<Models.Persona> personas)
        {
            return new GetAllPersonRS 
            {
                personas = personas.Select(s => new PersonRS
                {
                    apellidoMaterno = s.apellidoMaterno,
                    apellidoPaterno = s.apellidoPaterno,
                    identificacion = s.identificacion,
                    nombre = s.nombre,
                    id = s.id
                }).ToList()
            };
        }

        
        public static GetPersonByIdRS Transform(this Models.Persona persona)
        {
            return new GetPersonByIdRS
            {
                Persona = new PersonRS
                {
                    apellidoMaterno = persona.apellidoMaterno,
                    apellidoPaterno = persona.apellidoPaterno,
                    identificacion = persona.identificacion,
                    nombre = persona.nombre,
                    id = persona.id
                }
            };
        }

    }
}
