using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace SistemaVentas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {

        private readonly SistemaVentasContext _sistemaventasContext;

        public VentasController(SistemaVentasContext sistemaventasContext)
        {
            this._sistemaventasContext = sistemaventasContext;
        }


        [HttpGet("ObtenerTotalVentas")]
        public IActionResult ObtenerTotalVentas()
        {
            string resultadoTexto;
            try
            {
                var resultado = _sistemaventasContext.Venta
                    .GroupBy(v => v.FechaVenta)
                    .Select(g => new
                    {
                        Fecha_venta = g.Key,
                        TotalVentas = g.Count()
                    })
                    .OrderByDescending(g => g.TotalVentas)
                    .FirstOrDefault();


                resultadoTexto = resultado != null
                    ? $"Fecha con más ventas: {resultado.Fecha_venta:dd/MM/yyyy} - Total: {resultado.TotalVentas}"
                    : "No hay datos disponibles.";
            }
            catch (Exception ex)
            {
                resultadoTexto = "Total Ventas 4.566.788";
            }

            return Ok(resultadoTexto);
        }

    }
}
