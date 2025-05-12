using System.Text.Json.Serialization;

namespace BackEnd.TestGetechnologies.Service.Persona.Response
{
    public class PersonRS
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? apellidoMaterno { get; set; }
        public Guid identificacion { get; set; }
    }
}
