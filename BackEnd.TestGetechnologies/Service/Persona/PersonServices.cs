using BackEnd.TestGetechnologies.Service.Common.Response;
using BackEnd.TestGetechnologies.Service.Persona.Response;
using BackEnd.TestGetechnologies.Repository;
using BackEnd.TestGetechnologies.Service.Persona.Request;
using BackEnd.TestGetechnologies.Service.Persona.Transform;

namespace BackEnd.TestGetechnologies.Service.Persona
{
    public class PersonServices : IPersonServices
    {
        public IRepository<Guid, Models.Persona> repository;
       public IRepository<int, Models.Factura> repositoryInvoice;
        public PersonServices(IRepository<Guid, Models.Persona> _repository, IRepository<int, Models.Factura> _repositoryInvoice)
        {
            repository = _repository;
            repositoryInvoice = _repositoryInvoice;
        }

        public async Task<BaseResponse<bool>> AddPerson(PersonRQ person)
        {
            var result = new BaseResponse<bool>();

            // Aunque sean Guid se agrega validacion por si fuera otro tipo de dato
            var data = (await repository!.GetAllAsync()).Where(w=> w.identificacion == person.persona.identificacion).FirstOrDefault();
            if(data != null) 
            {
                result.Data = false;
                result.Message = $"La identificacion {person.persona.identificacion} ya existe";
            }
            else
            {
                await repository.AddAsync(person.persona.Transform());
                result.Data = true;
                result.Message = "La Persona se dio de alta correctamente";
            }

            result.Success = true;
           
            return result;
        }

        public async Task<BaseResponse<bool>> DeletePerson(Guid Id)
        {
            var result = new BaseResponse<bool>();

            var data = (await repository!.GetAllAsync()).Where(w => w.identificacion == Id).FirstOrDefault();

            if(data == null) 
            {
                result.Message = "La identificación no existe";
                result.Data = false;
            }
            else 
            {
                await repository.DeleteAsync(data);
                var dataInvoice = (await repositoryInvoice.GetAllAsync()).Where(w => w.Ididentificacion == data.identificacion);
                if (dataInvoice != null && !dataInvoice.Any())
                {
                    await repositoryInvoice.DeleteListAsync(dataInvoice!);
                }
                result.Message = "Se elimino a la Persona correctamente";
                result.Data = true;
            }
            
            result.Success = true;
            return result;
        }

        public async Task<BaseResponse<GetAllPersonRS>> GetAllPerson()
        {
            var result = new BaseResponse<GetAllPersonRS>();
            var data = await repository!.GetAllAsync();

            result.Success = true;
            result.Data = data!.Transform();
            return result;
        }

        public async Task<BaseResponse<GetPersonByIdRS>> GetPersonById(Guid Id)
        {
            var result = new BaseResponse<GetPersonByIdRS>();
            var data = (await repository!.GetAllAsync()).Where(w => w.identificacion == Id).FirstOrDefault();

            if (data == null)
            {
                result.Message = "La identificación no existe";
            }
            else
            {
                result.Data = data!.Transform();
            }

            result.Success = true;
            return result;
        }
    }
}
