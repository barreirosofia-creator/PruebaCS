using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SistemaVentas.Data;
using SistemaVentas.Services.IRepository;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace SistemaVentas.Services
{

    public class StatusApiService : IStatusApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public StatusApiService(HttpClient http, IConfiguration config)
        {
            _httpClient = http;
            _config = config;
        }

        public async Task<string> ObtenerInformacionStatus()
        {
            string respuesta = string.Empty;
            var url = _config["ApiUrls:UrlconsultaApi"];
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

