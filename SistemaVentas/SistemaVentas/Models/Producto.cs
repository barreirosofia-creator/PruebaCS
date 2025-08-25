using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public virtual ICollection<VentaDetalle> VentaDetalles { get; set; } = new List<VentaDetalle>();
}
