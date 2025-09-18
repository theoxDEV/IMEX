using IMEX.Models;
using System.Text.Json;

namespace IMEX.Services
{
    public class RevendedorService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<List<Revendedor>> BuscarAsync(string uf, string municipio, int pagina = 1)
        {
            var url = $"https://revendedoresapi.anp.gov.br/v1/glp?uf={uf}&municipio={Uri.EscapeDataString(municipio)}&numeropagina={pagina}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<Revendedor>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return result?.Data ?? new List<Revendedor>();
        }
    }
}
