using BackEnd.TestGetechnologies.Service.Common.Domain;
using BackEnd.TestGetechnologies.Service.Factura.Response;

namespace BackEnd.TestGetechnologies.Service.Factura.Transform
{
    public static class TransformInvoice
    {
        public static Models.Factura Transform(this InvoiceDto invoice)
        {
            return new Models.Factura
            {
                 fecha = invoice.fecha,
                 Ididentificacion = invoice.Ididentificacion,
                 monto = invoice.monto
            };
        }

        public static GetAllInvoiceRS Transform(this IEnumerable<Models.Factura> factura)
        {
            return new GetAllInvoiceRS
            {
                invoices = factura.Select(s => new InvoiceRS
                {
                     monto = s.monto,
                     fecha = s.fecha,
                     id = s.id,
                     Ididentificacion = s.Ididentificacion
                }).ToList()
            };
        }


        public static GetInvoiceByIdRS Transform(this Models.Factura factura)
        {
            return new GetInvoiceByIdRS
            {
                invoice = new InvoiceRS 
                {
                    fecha = factura.fecha,
                    id = factura.id,
                    Ididentificacion = factura.Ididentificacion,
                    monto = factura.monto
                }
            };
        }
    }
}
