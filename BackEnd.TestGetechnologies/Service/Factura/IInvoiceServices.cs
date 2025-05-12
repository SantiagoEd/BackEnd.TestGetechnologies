using BackEnd.TestGetechnologies.Service.Common.Response;
using BackEnd.TestGetechnologies.Service.Factura.Request;
using BackEnd.TestGetechnologies.Service.Factura.Response;
namespace BackEnd.TestGetechnologies.Service.Factura
{
    public interface IInvoiceServices
    {
        Task<BaseResponse<bool>> AddInvoice(InvoiceRQ invoice);
        Task<BaseResponse<bool>> DeleteInvoice(int Id);
        Task<BaseResponse<GetAllInvoiceRS>> GetAllInvoice();
        Task<BaseResponse<GetInvoiceByIdRS>> GetInvoiceById(int Id);
        Task<BaseResponse<GetAllInvoiceRS>> GetInvoicebyIdentification(Guid Identification);
        Task<BaseResponse<bool>> DeleteInvoiceByIdentification(Guid Identification);
    }
}
