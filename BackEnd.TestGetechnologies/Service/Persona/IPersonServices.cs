using BackEnd.TestGetechnologies.Service.Common.Response;
using BackEnd.TestGetechnologies.Service.Persona.Request;
using BackEnd.TestGetechnologies.Service.Persona.Response;

namespace BackEnd.TestGetechnologies.Service.Persona
{
    public interface IPersonServices
    {
        Task<BaseResponse<bool>> AddPerson(PersonRQ person);
        Task<BaseResponse<bool>> DeletePerson(Guid Id);
        Task<BaseResponse<GetAllPersonRS>> GetAllPerson();
        Task<BaseResponse<GetPersonByIdRS>> GetPersonById(Guid Id);
    }
}
