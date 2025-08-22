using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Data
{
    public class Empleado
    {
        
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
        public string Apellido { get; set; }


        [Required(ErrorMessage = "Debe seleccionar un estado")]
        [EnumDataType(typeof(EstadoEmpleado), ErrorMessage = "Estado inválido")]
        public EstadoEmpleado Estado { get; set; }
    }

    public enum EstadoEmpleado
    {
        Activo,
        Inactivo
    }
}