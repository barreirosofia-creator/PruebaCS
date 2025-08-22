using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using SistemaVentas.Data;
namespace SistemaVentas.Services
{

    public class EmpleadoApiService
    {
        private readonly HttpClient _http;

        public EmpleadoApiService(HttpClient http)
        {
            _http = http;
        }

        //public async Task<List<Empleado>> ObtenerEmpleadosAsync()
        //{
        //    //return await _http.GetFromJsonAsync<List<Emple>>("https://api.tuservicio.com/empleados");
        //}

        //public async Task<bool> CrearEmpleadoAsync(Empleado nuevo)
        //{
        //    var response = await _http.PostAsJsonAsync("https://api.tuservicio.com/empleados", nuevo);
        //    return response.IsSuccessStatusCode;
        //}
    }

}

