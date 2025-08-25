namespace SistemaVentas.Services.IRepository
{
    public interface IConsultaVentasService
    {
        Task<string> ObtenerTotalVentas();

    }
}