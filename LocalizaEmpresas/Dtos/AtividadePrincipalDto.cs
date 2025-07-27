using System.Text.Json.Serialization;

namespace LocalizaEmpresas.Dtos
{
    public class AtividadePrincipalDto
    {
        [JsonPropertyName("code")]
        public string Codigo { get; set; }
        [JsonPropertyName("text")]
        public string Descricao { get; set; }
        
    }
}
