using SistemaVentas.Models;

namespace SistemaVentas.Services.IRepository
{
    public interface IEmpleadoApiService
    {
        Task<string> ObtenerListadoEmpleados();
        Task<string> ObtenerListadoEmpleadosActivos();

        Task<string> ObtenerListadoEmpleadosInactivos();
        Task<string> EnviarEmpleadoAsync(Empleado empleado);

    }
}
