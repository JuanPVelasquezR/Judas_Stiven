using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventarioAPP.Models;

public partial class InventarioTecnologiaContext : DbContext
{
    public InventarioTecnologiaContext()
    {
    }

    public InventarioTecnologiaContext(DbContextOptions<InventarioTecnologiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetallesOrdenCompra> DetallesOrdenCompras { get; set; }

    public virtual DbSet<DetallesOrdenVentum> DetallesOrdenVenta { get; set; }

    public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }

    public virtual DbSet<OrdenesVentum> OrdenesVenta { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("PK__Categori__CD54BC5A65A0061D");

            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__677F38F53A50239B");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .HasColumnName("contacto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<DetallesOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra).HasName("PK__Detalles__BD16E279F4ECC60E");

            entity.ToTable("DetallesOrdenCompra");

            entity.Property(e => e.IdDetalleCompra).HasColumnName("id_detalle_compra");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Costo)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo");
            entity.Property(e => e.IdOrdenCompra).HasColumnName("id_orden_compra");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.DetallesOrdenCompras)
                .HasForeignKey(d => d.IdOrdenCompra)
                .HasConstraintName("FK__DetallesO__id_or__44FF419A");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesOrdenCompras)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetallesO__id_pr__45F365D3");
        });

        modelBuilder.Entity<DetallesOrdenVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta).HasName("PK__Detalles__5B265D476058340A");

            entity.Property(e => e.IdDetalleVenta).HasColumnName("id_detalle_venta");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdOrdenVenta).HasColumnName("id_orden_venta");
            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");

            entity.HasOne(d => d.IdOrdenVentaNavigation).WithMany(p => p.DetallesOrdenVenta)
                .HasForeignKey(d => d.IdOrdenVenta)
                .HasConstraintName("FK__DetallesO__id_or__4BAC3F29");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesOrdenVenta)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__DetallesO__id_pr__4CA06362");
        });

        modelBuilder.Entity<OrdenesCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra).HasName("PK__OrdenesC__71B729AFD5FA1157");

            entity.ToTable("OrdenesCompra");

            entity.Property(e => e.IdOrdenCompra).HasColumnName("id_orden_compra");
            entity.Property(e => e.CostoTotal)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("costo_total");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__OrdenesCo__id_pr__4222D4EF");
        });

        modelBuilder.Entity<OrdenesVentum>(entity =>
        {
            entity.HasKey(e => e.IdOrdenVenta).HasName("PK__OrdenesV__8611A2E8DE7D203F");

            entity.Property(e => e.IdOrdenVenta).HasColumnName("id_orden_venta");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdenesVenta)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__OrdenesVe__id_cl__48CFD27E");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__FF341C0D0CBBE8E3");

            entity.Property(e => e.IdProducto).HasColumnName("id_producto");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
            entity.Property(e => e.PrecioCompra)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_compra");
            entity.Property(e => e.PrecioVenta)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio_venta");
            entity.Property(e => e.Stock)
                .HasDefaultValue(0)
                .HasColumnName("stock");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Productos__id_ca__3C69FB99");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Productos__id_pr__3D5E1FD2");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__8D3DFE281B1F2219");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Contacto)
                .HasMaxLength(100)
                .HasColumnName("contacto");
            entity.Property(e => e.Direccion).HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
