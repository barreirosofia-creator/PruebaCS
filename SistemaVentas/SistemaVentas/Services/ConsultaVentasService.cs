using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SistemaVentas.Models;
using SistemaVentas.Services.IRepository;

namespace SistemaVentas.Services
{

    public class ConsultaVentasService : IConsultaVentasService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public ConsultaVentasService(HttpClient http, IConfiguration config)
        {
            _httpClient = http;
            _config = config;
        }

        public async Task<string> ObtenerTotalVentas()
        {
            string respuesta = string.Empty;
            var url = _config["ApiUrls:UrlconsultaVentas"];
            try
            {
                using (var httpResponse = await _httpClient.GetAsync(url))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    string responsContent = await httpResponse.Content.ReadAsStringAsync();
                    respuesta = responsContent;
                }
            }
            catch (Exception ex)
            {
                respuesta = $"Error: {ex.Message}";
            }

            return respuesta;
        }
    }

}

