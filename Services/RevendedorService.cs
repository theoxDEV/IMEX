using IMEX.Models;
using System.Text.Json;

namespace IMEX.Services
{
    public class RevendedorService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        // cache em memória: chave = UF|Município|Página
        private readonly Dictionary<string, (DateTime Expira, List<Revendedor> Dados)> _cache = new();

        public async Task<List<Revendedor>> BuscarAsync(string uf, string municipio, int pagina = 1)
        {
            string key = $"{uf}|{municipio.ToUpper()}|{pagina}";

            // verifica cache para evitar múltiplas requests
            if (_cache.TryGetValue(key, out var cacheEntry))
            {
                if (cacheEntry.Expira > DateTime.Now)
                    return cacheEntry.Dados;
                else
                    _cache.Remove(key); // expirou
            }

            // a própria paginação da api não funciona, em qualquer chamada ela retorna a página com limite de 500 elementos
            var url = $"https://revendedoresapi.anp.gov.br/v1/glp?uf={uf}&municipio={Uri.EscapeDataString(municipio)}&numeropagina={pagina}";

            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer.Deserialize<ApiResponse<Revendedor>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            List<Revendedor> data = result?.Data ?? new List<Revendedor>();

            // guarda no cache
            _cache[key] = (DateTime.Now.AddHours(23), data);

            return data;
        }
    }
}
