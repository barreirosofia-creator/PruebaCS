using Microsoft.AspNetCore.Mvc;
using SistemaVentas.Models;
using SistemaVentas.Services;
using System.Net.Mime;
using System.Runtime.CompilerServices;

namespace SistemaVentas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly SistemaVentasContext _sistemaventasContext;

        public EmpleadosController(SistemaVentasContext sistemaventasContext)
        {
            this._sistemaventasContext = sistemaventasContext;
        }


        [HttpGet("ObtenerListadoEmpleados")]
        public IActionResult ObtenerListadoEmpleados()
        {
            List<Empleado> listadoEmpleados = new List<Empleado>();
            try
            {
                var resultado = _sistemaventasContext.Empleados.ToList();
                if(resultado != null)
                {
                    listadoEmpleados = resultado;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(listadoEmpleados);
        }
        [HttpGet("ObtenerListadoEmpleadosActivos")]
        public IActionResult ObtenerListadoEmpleadosActivos()
        {
            List<Empleado> listadoEmpleados = new List<Empleado>();
            try
            {
                var resultado = _sistemaventasContext.Empleados.Where( x => x.Estado == Models.EstadoEmpleado.Activo).ToList();
                if (resultado != null)
                {
                    listadoEmpleados = resultado;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(listadoEmpleados);
        }
        [HttpGet("ObtenerListadoEmpleadosInactivos")]
        public IActionResult ObtenerListadoEmpleadosInactivos()
        {
            List<Empleado> listadoEmpleados = new List<Empleado>();
            try
            {
                var resultado = _sistemaventasContext.Empleados.Where(x => x.Estado == Models.EstadoEmpleado.Inactivo).ToList();
                if (resultado != null)
                {
                    listadoEmpleados = resultado;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return Ok(listadoEmpleados);
        }

        [HttpPost("AgregarEmpleado")]
        public async Task<IActionResult> AgregarEmpleado([FromBody] Empleado nuevoEmpleado)
        {
           
            if (nuevoEmpleado == null)
                return BadRequest("Datos del empleado no válidos.");

            try
            {



                _sistemaventasContext.Empleados.Add(nuevoEmpleado);
                await _sistemaventasContext.SaveChangesAsync();
                return Ok(new { mensaje = "Empleado agregado correctamente", empleado = nuevoEmpleado });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, $"Error interno: {ex.Message}");
            }
        }

    }
}
