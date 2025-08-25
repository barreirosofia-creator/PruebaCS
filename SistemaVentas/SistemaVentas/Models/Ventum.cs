using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Ventum
{
    public int IdVenta { get; set; }

    public DateTime FechaVenta { get; set; }

    public string DniCliente { get; set; } = null!;

    public int IdEmpleado { get; set; }

    public int IdSucursal { get; set; }

    public decimal ImporteTotal { get; set; }

    public virtual Cliente DniClienteNavigation { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
