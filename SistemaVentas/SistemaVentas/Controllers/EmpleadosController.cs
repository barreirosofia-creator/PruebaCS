using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Services;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace SistemaVentas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        [HttpGet("{usuario}")]
        public IActionResult ObtenerGruposUsuario(string usuario)
        {
            Object[] resultado = new Object[0];
            //try 
            //{
            //    //var rta = ServicioGrupos.BuscarGrupoXUsuario(usuario);
            //    //resultado = rta.Result;
            //}
            //catch (Exception ex)
            //{
            //    //LoggerManager logger = new LoggerManager();
            //    //logger.LogError("Error en ObtenerGruposUsuario ", ex);
            //}
            return Ok(resultado);
        }
    }
}
