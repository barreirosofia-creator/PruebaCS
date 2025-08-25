using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string NombreSucursal { get; set; } = null!;

    public string? DireccionSucursal { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
