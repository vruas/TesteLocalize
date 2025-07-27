using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace LocalizaEmpresas.Models
{
    [Owned]
    public class AtividadePrincipal
    {
        [JsonPropertyName("code")]
        public string Codigo { get; set; }
        
        [JsonPropertyName("text")]
        public string Descricao { get; set; }
    }
}
