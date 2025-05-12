namespace BackEnd.TestGetechnologies.Service.Factura.Response
{
    public class InvoiceRS
    {
        public int id { get; set; }
        public DateTime fecha { get; set; }
        public decimal monto { get; set; }
        public Guid Ididentificacion { get; set; }
    }
}
