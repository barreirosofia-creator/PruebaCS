using SistemaVentas.Models;
using SistemaVentas.Services.IRepository;

namespace SistemaVentas.Services
{
    public class ConexionDbService : IConexionDbService
    {
        private readonly SistemaVentasContext _context;

        public ConexionDbService(SistemaVentasContext context)
        {
            _context = context;
        }

        public async Task<bool> ProbarConexionAsync()
        {
            try
            {
                return await _context.Database.CanConnectAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
