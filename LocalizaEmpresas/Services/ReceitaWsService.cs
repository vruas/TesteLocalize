using LocalizaEmpresas.Dtos;
using System.Text.Json;

namespace LocalizaEmpresas.Services
{
    public class ReceitaWsService
    {
        private HttpClient _httpClient;
        public ReceitaWsService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ReceitaWsDto> ConsultaCnpjAsync(string cnpj)
        {
            var url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Erro ao consultar CNPJ: {response.ReasonPhrase}");
            }

            var dadosJson = await response.Content.ReadAsStringAsync();

            var dadosReceita = JsonSerializer.Deserialize<ReceitaWsDto>(dadosJson, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            if (dadosReceita == null)
            {
                throw new Exception("Dados da Receita Federal não encontrados ou inválidos.");
            }

            return dadosReceita;


        }
    }
}
