using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class VentaDetalle
{
    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Ventum IdVentaNavigation { get; set; } = null!;
}
