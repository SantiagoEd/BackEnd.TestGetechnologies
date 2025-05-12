namespace BackEnd.TestGetechnologies.Models
{
    public class Persona
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string? apellidoMaterno {  get; set; }
        public Guid identificacion {  get; set; }
    }
}
