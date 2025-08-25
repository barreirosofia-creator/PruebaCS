using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SistemaVentas.Models;
using SistemaVentas.Services.IRepository;
using System.Text;
using Newtonsoft.Json;
namespace SistemaVentas.Services
{

    public class EmpleadoApiService : IEmpleadoApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public EmpleadoApiService(HttpClient http, IConfiguration config)
        {
            _httpClient = http;
            _config = config;
        }

        public async Task<string> ObtenerListadoEmpleados()
        {
            string respuesta = string.Empty;
            var url = _config["ApiUrls:UrlconsultaEmpleados"];
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
        public async Task<string> ObtenerListadoEmpleadosActivos()
        {
            string respuesta = string.Empty;
            var url = _config["ApiUrls:UrlconsultaEmpleadosActivos"];
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
        public async Task<string> ObtenerListadoEmpleadosInactivos()
        {
            string respuesta = string.Empty;
            var url = _config["ApiUrls:UrlconsultaEmpleadosInactivos"];
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

        public async Task<string> EnviarEmpleadoAsync(Empleado empleado)
        {
            string respuesta = string.Empty;
            var url = _config["ApiUrls:UrlEnvioEmpleado"]; // Asegurate de tener esta clave en tu config

            try
            {
                var url2 = _config["ApiUrls:UrlEnvioEmpleado"];

                if (string.IsNullOrWhiteSpace(url2))
                    throw new InvalidOperationException("La URL de envío no está configurada correctamente.");


                using (var httpResponse = await _httpClient.PostAsJsonAsync<Empleado>(url, empleado))
                {
                    httpResponse.EnsureSuccessStatusCode();
                    string responseContent = await httpResponse.Content.ReadAsStringAsync();
                    respuesta = responseContent;
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

