using BackEnd.TestGetechnologies.Repository;
using BackEnd.TestGetechnologies.Service.Common.Response;
using BackEnd.TestGetechnologies.Service.Factura.Request;
using BackEnd.TestGetechnologies.Service.Factura.Response;
using BackEnd.TestGetechnologies.Service.Factura.Transform;

namespace BackEnd.TestGetechnologies.Service.Factura
{
    public class InvoiceServices : IInvoiceServices
    {
        public IRepository<int, Models.Factura> repository;
        public IRepository<Guid, Models.Persona> repositoryPerson;
        public InvoiceServices(IRepository<int, Models.Factura> _repository,
            IRepository<Guid, Models.Persona> _repositoryPerson)
        {
            repository = _repository;
            repositoryPerson = _repositoryPerson;
        }

        public async Task<BaseResponse<bool>> AddInvoice(InvoiceRQ invoice)
        {
            var result = new BaseResponse<bool>();

            var data = (await repositoryPerson.GetAllAsync()).Where(w=> w.identificacion == invoice.Invoice.Ididentificacion);
            if (data == null) 
            {
                result.Data = false;
                result.Message = $"La Persona con identificacion {invoice.Invoice.Ididentificacion} no existe";
            }
            else
            {
                await repository.AddAsync(invoice.Invoice.Transform());
                result.Data = true;
                result.Message = "La factura se dio de alta correctamente";
            }

            

            result.Success = true;
            return result;
        }

        public async Task<BaseResponse<bool>> DeleteInvoice(int Id)
        {
            var result = new BaseResponse<bool>();

            var data = await repository!.GetByIdAsync(Id);

            if (data == null)
            {
                result.Message = "La factura no existe";
                result.Data = false;
            }
            else
            {
                await repository.DeleteAsync(data);
                result.Message = "Se elimino la factura correctamente";
                result.Data = true;
            }

            result.Success = true;
            return result;
        }

        public async Task<BaseResponse<bool>> DeleteInvoiceByIdentification(Guid Identification)
        {
            var result = new BaseResponse<bool>();
            var data = (await repository!.GetAllAsync()).Where(w=> w!.Ididentificacion == Identification);

            if (data == null && !data!.Any()) 
            {
                result.Message = "La identificacion no tiene facturas";
                result.Data = false;
            }
            else 
            {
                await repository.DeleteListAsync(data!);
                result.Message = "Se eliminaron correctamente las facturas";
                result.Data = true;
            }


            return result;
        }

        public async Task<BaseResponse<GetAllInvoiceRS>> GetAllInvoice()
        {
            var result = new BaseResponse<GetAllInvoiceRS>();
            var data = await repository!.GetAllAsync();

            result.Success = true;
            result.Data = data!.Transform();
            return result;
        }

        public async Task<BaseResponse<GetInvoiceByIdRS>> GetInvoiceById(int Id)
        {
            var result = new BaseResponse<GetInvoiceByIdRS>();
            var data = await repository!.GetByIdAsync(Id);

            if (data == null)
            {
                result.Message = "La factura no existe";
            }
            else
            {
                result.Data = data!.Transform();
            }

            result.Success = true;
            return result;
        }

        public async Task<BaseResponse<GetAllInvoiceRS>> GetInvoicebyIdentification(Guid Identification)
        {
            var result = new BaseResponse<GetAllInvoiceRS>();
            var data = (await repository!.GetAllAsync()).Where(w => w!.Ididentificacion == Identification);

            result.Success = true;
            result.Data = data!.Transform();
            return result;
        }
    }
}
