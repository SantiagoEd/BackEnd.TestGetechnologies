using BackEnd.TestGetechnologies.Service.Factura;
using BackEnd.TestGetechnologies.Service.Factura.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.TestGetechnologies.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private IInvoiceServices invoiceServices;
        public SaleController(IInvoiceServices _invoiceServices)
        {
            invoiceServices = _invoiceServices;
        }

        [HttpGet("findFacturasByPersona/{identificacion}")]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> GetInvoiceById([FromRoute] Guid identificacion) 
        {
            return Ok(await invoiceServices.GetInvoicebyIdentification(identificacion));
        }

        [HttpPost("storeFactura")]
        [ProducesResponseType(400, Type = typeof(ValidationProblemDetails))]
        public async Task<IActionResult> AddInvoice([FromBody] InvoiceRQ request)
        {
            return Ok(await invoiceServices.AddInvoice(request));
        }


    }
}
