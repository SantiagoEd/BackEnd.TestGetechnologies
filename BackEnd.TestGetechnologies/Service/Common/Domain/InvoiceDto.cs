using System.Text.Json.Serialization;

namespace BackEnd.TestGetechnologies.Service.Common.Domain
{
    public class InvoiceDto
    {
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public Guid Ididentificacion { get; set; }
    }
}
