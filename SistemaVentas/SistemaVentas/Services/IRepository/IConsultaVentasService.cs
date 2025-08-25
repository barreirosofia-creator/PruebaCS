namespace SistemaVentas.Services.IRepository
{
    public interface IConexionDbService
    {
        Task<bool> ProbarConexionAsync();
    }
}