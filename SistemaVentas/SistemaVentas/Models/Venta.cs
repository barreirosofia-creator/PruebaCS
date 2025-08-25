namespace SistemaVentas.Models
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public DateTime FechaVenta { get; set; }
        public decimal ImporteTotal { get; set; }

        // Foreign keys
        public string DniCliente { get; set; }
        public Cliente Cliente { get; set; }

        public int IdEmpleado { get; set; }
        public Empleado Empleado { get; set; }

        public int IdSucursal { get; set; }
        public Sucursal Sucursal { get; set; }

        public List<VentaDetalle> VentaDetalles { get; set; } = new();
    }
}
