using System;
using System.Collections.Generic;

namespace SistemaVentas.Models;

public partial class Cliente
{
    public string DniCliente { get; set; } = null!;

    public string NombreCliente { get; set; } = null!;

    public string? DireccionEnvioCliente { get; set; }

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
