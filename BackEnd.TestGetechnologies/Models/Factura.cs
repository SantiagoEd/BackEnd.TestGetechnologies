namespace BackEnd.TestGetechnologies.Models
{
    public class Factura
    {
        public int id {  get; set; }
        public DateTime fecha { get; set; }
        public decimal monto {  get; set; }
        public Guid Ididentificacion { get; set; }
    }
}
