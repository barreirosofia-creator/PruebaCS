using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SistemaVentas.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreEmpleado { get; set; } = null!;
    [Required(ErrorMessage = "El nombre es obligatorio")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio")]
    public string Apellido { get; set; }

    [Required(ErrorMessage = "El estado es obligatorio")]
    public EstadoEmpleado? Estado { get; set; } // ← Nullable para que el valor "" sea válido


    //[Required(ErrorMessage = "Debe seleccionar un estado")]
    //[EnumDataType(typeof(EstadoEmpleado), ErrorMessage = "Estado inválido")] 
    //public EstadoEmpleado Estado { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();

   

}
public enum EstadoEmpleado { Activo, Inactivo }
