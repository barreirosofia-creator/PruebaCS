using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaVentas.Models;

public partial class SistemaVentasContext : DbContext
{
    public SistemaVentasContext()
    {
    }

    public SistemaVentasContext(DbContextOptions<SistemaVentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<VentaDetalle> VentaDetalles { get; set; }

    public virtual DbSet<Ventum> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GSQ32K7;Database=SistemaVentasDER;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.DniCliente).HasName("PK__CLIENTE__538EA93AF188D636");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.DniCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dni_cliente");
            entity.Property(e => e.DireccionEnvioCliente)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Direccion_envio_cliente");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_cliente");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__01AC2829EF167A63");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.IdEmpleado).HasColumnName("Id_empleado");
            entity.Property(e => e.NombreEmpleado)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_empleado");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__PRODUCTO__1D8EFF01B3C1DAAC");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_producto");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__SUCURSAL__A71B7D48A74B6331");

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.IdSucursal).HasColumnName("Id_sucursal");
            entity.Property(e => e.DireccionSucursal)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Direccion_sucursal");
            entity.Property(e => e.NombreSucursal)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Nombre_sucursal");
        });

        modelBuilder.Entity<VentaDetalle>(entity =>
        {
            entity.HasKey(e => new { e.IdVenta, e.IdProducto }).HasName("PK__VENTA_DE__F1AF077093591C2A");

            entity.ToTable("VENTA_DETALLE");

            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.IdProducto).HasColumnName("Id_producto");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA_DET__Id_pr__44FF419A");

            entity.HasOne(d => d.IdVentaNavigation).WithMany(p => p.VentaDetalles)
                .HasForeignKey(d => d.IdVenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA_DET__Id_ve__440B1D61");
        });

        modelBuilder.Entity<Ventum>(entity =>
        {
            entity.HasKey(e => e.IdVenta).HasName("PK__VENTA__F077E8803C956CFB");

            entity.ToTable("VENTA");

            entity.Property(e => e.IdVenta).HasColumnName("Id_venta");
            entity.Property(e => e.DniCliente)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("Dni_cliente");
            entity.Property(e => e.FechaVenta)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_venta");
            entity.Property(e => e.IdEmpleado).HasColumnName("Id_empleado");
            entity.Property(e => e.IdSucursal).HasColumnName("Id_sucursal");
            entity.Property(e => e.ImporteTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("Importe_total");

            entity.HasOne(d => d.DniClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.DniCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__Dni_clien__3D5E1FD2");

            entity.HasOne(d => d.IdEmpleadoNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdEmpleado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__Id_emplea__3E52440B");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__VENTA__Id_sucurs__3F466844");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
