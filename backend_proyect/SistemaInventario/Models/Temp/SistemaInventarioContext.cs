using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Models.Temp;

public partial class SistemaInventarioContext : DbContext
{
    public SistemaInventarioContext()
    {
    }

    public SistemaInventarioContext(DbContextOptions<SistemaInventarioContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Cliente1> Clientes1 { get; set; }

    public virtual DbSet<DetalleMovimiento> DetalleMovimientos { get; set; }

    public virtual DbSet<DetalleOrdenCompra> DetalleOrdenCompras { get; set; }

    public virtual DbSet<DetalleOrdenVentum> DetalleOrdenVenta { get; set; }

    public virtual DbSet<DetallesMovimiento> DetallesMovimientos { get; set; }

    public virtual DbSet<DetallesOrdenCompra> DetallesOrdenCompras { get; set; }

    public virtual DbSet<DetallesOrdenVentum> DetallesOrdenVenta { get; set; }

    public virtual DbSet<InventarioSucursal> InventarioSucursals { get; set; }

    public virtual DbSet<InventarioSucursale> InventarioSucursales { get; set; }

    public virtual DbSet<MovimientoInventario> MovimientoInventarios { get; set; }

    public virtual DbSet<MovimientosInventario> MovimientosInventarios { get; set; }

    public virtual DbSet<OrdenCompra> OrdenCompras { get; set; }

    public virtual DbSet<OrdenVentum> OrdenVenta { get; set; }

    public virtual DbSet<OrdenesCompra> OrdenesCompras { get; set; }

    public virtual DbSet<OrdenesVentum> OrdenesVenta { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Permiso1> Permisos1 { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Producto1> Productos1 { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<TipoMovimiento> TipoMovimientos { get; set; }

    public virtual DbSet<TiposMovimiento> TiposMovimientos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Usuario1> Usuarios1 { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=SistemaInventario;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Cliente");

            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<Cliente1>(entity =>
        {
            entity.HasKey(e => e.IdCliente);

            entity.ToTable("Clientes");

            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(255);
        });

        modelBuilder.Entity<DetalleMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdDetalleMovimiento);

            entity.ToTable("DetalleMovimiento");

            entity.HasIndex(e => e.IdMovimiento, "IX_DetalleMovimiento_IdMovimiento");

            entity.HasIndex(e => e.IdProducto, "IX_DetalleMovimiento_IdProducto");

            entity.HasIndex(e => e.IdSucursalDestino, "IX_DetalleMovimiento_IdSucursalDestino");

            entity.HasIndex(e => e.IdSucursalOrigen, "IX_DetalleMovimiento_IdSucursalOrigen");

            entity.HasIndex(e => e.ProductoIdProducto, "IX_DetalleMovimiento_ProductoIdProducto");

            entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.DetalleMovimientos).HasForeignKey(d => d.IdMovimiento);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleMovimientoIdProductoNavigations)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSucursalDestinoNavigation).WithMany(p => p.DetalleMovimientoIdSucursalDestinoNavigations).HasForeignKey(d => d.IdSucursalDestino);

            entity.HasOne(d => d.IdSucursalOrigenNavigation).WithMany(p => p.DetalleMovimientoIdSucursalOrigenNavigations).HasForeignKey(d => d.IdSucursalOrigen);

            entity.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.DetalleMovimientoProductoIdProductoNavigations).HasForeignKey(d => d.ProductoIdProducto);
        });

        modelBuilder.Entity<DetalleOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra);

            entity.ToTable("DetalleOrdenCompra");

            entity.HasIndex(e => e.IdOrdenCompra, "IX_DetalleOrdenCompra_IdOrdenCompra");

            entity.HasIndex(e => e.IdProducto, "IX_DetalleOrdenCompra_IdProducto");

            entity.HasIndex(e => e.ProductoIdProducto, "IX_DetalleOrdenCompra_ProductoIdProducto");

            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.DetalleOrdenCompras).HasForeignKey(d => d.IdOrdenCompra);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleOrdenCompraIdProductoNavigations)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.DetalleOrdenCompraProductoIdProductoNavigations).HasForeignKey(d => d.ProductoIdProducto);
        });

        modelBuilder.Entity<DetalleOrdenVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta);

            entity.HasIndex(e => e.IdOrdenVenta, "IX_DetalleOrdenVenta_IdOrdenVenta");

            entity.HasIndex(e => e.IdProducto, "IX_DetalleOrdenVenta_IdProducto");

            entity.HasIndex(e => e.ProductoIdProducto, "IX_DetalleOrdenVenta_ProductoIdProducto");

            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdOrdenVentaNavigation).WithMany(p => p.DetalleOrdenVenta).HasForeignKey(d => d.IdOrdenVenta);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetalleOrdenVentumIdProductoNavigations)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductoIdProductoNavigation).WithMany(p => p.DetalleOrdenVentumProductoIdProductoNavigations).HasForeignKey(d => d.ProductoIdProducto);
        });

        modelBuilder.Entity<DetallesMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdDetalleMovimiento);

            entity.ToTable("DetallesMovimiento");

            entity.HasIndex(e => e.IdMovimiento, "IX_DetallesMovimiento_IdMovimiento");

            entity.HasIndex(e => e.IdProducto, "IX_DetallesMovimiento_IdProducto");

            entity.HasIndex(e => e.IdSucursalDestino, "IX_DetallesMovimiento_IdSucursalDestino");

            entity.HasIndex(e => e.IdSucursalOrigen, "IX_DetallesMovimiento_IdSucursalOrigen");

            entity.HasOne(d => d.IdMovimientoNavigation).WithMany(p => p.DetallesMovimientos)
                .HasForeignKey(d => d.IdMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesMovimientos)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSucursalDestinoNavigation).WithMany(p => p.DetallesMovimientoIdSucursalDestinoNavigations).HasForeignKey(d => d.IdSucursalDestino);

            entity.HasOne(d => d.IdSucursalOrigenNavigation).WithMany(p => p.DetallesMovimientoIdSucursalOrigenNavigations).HasForeignKey(d => d.IdSucursalOrigen);
        });

        modelBuilder.Entity<DetallesOrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCompra);

            entity.ToTable("DetallesOrdenCompra");

            entity.HasIndex(e => e.IdOrdenCompra, "IX_DetallesOrdenCompra_IdOrdenCompra");

            entity.HasIndex(e => e.IdProducto, "IX_DetallesOrdenCompra_IdProducto");

            entity.Property(e => e.Costo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdOrdenCompraNavigation).WithMany(p => p.DetallesOrdenCompras)
                .HasForeignKey(d => d.IdOrdenCompra)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesOrdenCompras)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DetallesOrdenVentum>(entity =>
        {
            entity.HasKey(e => e.IdDetalleVenta);

            entity.HasIndex(e => e.IdOrdenVenta, "IX_DetallesOrdenVenta_IdOrdenVenta");

            entity.HasIndex(e => e.IdProducto, "IX_DetallesOrdenVenta_IdProducto");

            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdOrdenVentaNavigation).WithMany(p => p.DetallesOrdenVenta)
                .HasForeignKey(d => d.IdOrdenVenta)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.DetallesOrdenVenta)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<InventarioSucursal>(entity =>
        {
            entity.HasKey(e => e.IdInventario);

            entity.ToTable("InventarioSucursal");

            entity.HasIndex(e => new { e.IdProducto, e.IdSucursal }, "IX_InventarioSucursal_IdProducto_IdSucursal").IsUnique();

            entity.HasIndex(e => e.IdSucursal, "IX_InventarioSucursal_IdSucursal");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.InventarioSucursals).HasForeignKey(d => d.IdProducto);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.InventarioSucursals).HasForeignKey(d => d.IdSucursal);
        });

        modelBuilder.Entity<InventarioSucursale>(entity =>
        {
            entity.HasKey(e => e.IdInventario);

            entity.HasIndex(e => new { e.IdProducto, e.IdSucursal }, "IX_InventarioSucursales_IdProducto_IdSucursal").IsUnique();

            entity.HasIndex(e => e.IdSucursal, "IX_InventarioSucursales_IdSucursal");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.InventarioSucursales)
                .HasForeignKey(d => d.IdProducto)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.InventarioSucursales)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<MovimientoInventario>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento);

            entity.ToTable("MovimientoInventario");

            entity.HasIndex(e => e.IdTipoMovimiento, "IX_MovimientoInventario_IdTipoMovimiento");

            entity.Property(e => e.Estado).HasMaxLength(50);

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.MovimientoInventarios).HasForeignKey(d => d.IdTipoMovimiento);
        });

        modelBuilder.Entity<MovimientosInventario>(entity =>
        {
            entity.HasKey(e => e.IdMovimiento);

            entity.ToTable("MovimientosInventario");

            entity.HasIndex(e => e.IdTipoMovimiento, "IX_MovimientosInventario_IdTipoMovimiento");

            entity.Property(e => e.Estado).HasMaxLength(50);

            entity.HasOne(d => d.IdTipoMovimientoNavigation).WithMany(p => p.MovimientosInventarios)
                .HasForeignKey(d => d.IdTipoMovimiento)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrdenCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra);

            entity.ToTable("OrdenCompra");

            entity.HasIndex(e => e.IdProveedor, "IX_OrdenCompra_IdProveedor");

            entity.Property(e => e.CostoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.OrdenCompras).HasForeignKey(d => d.IdProveedor);
        });

        modelBuilder.Entity<OrdenVentum>(entity =>
        {
            entity.HasKey(e => e.IdOrdenVenta);

            entity.HasIndex(e => e.IdCliente, "IX_OrdenVenta_IdCliente");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdenVenta).HasForeignKey(d => d.IdCliente);
        });

        modelBuilder.Entity<OrdenesCompra>(entity =>
        {
            entity.HasKey(e => e.IdOrdenCompra);

            entity.ToTable("OrdenesCompra");

            entity.HasIndex(e => e.IdProveedor, "IX_OrdenesCompra_IdProveedor");

            entity.Property(e => e.CostoTotal).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.OrdenesCompras)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<OrdenesVentum>(entity =>
        {
            entity.HasKey(e => e.IdOrdenVenta);

            entity.HasIndex(e => e.IdCliente, "IX_OrdenesVenta_IdCliente");

            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.OrdenesVenta)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("Permiso");

            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Permiso1>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("Permisos");

            entity.Property(e => e.Codigo).HasMaxLength(50);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Producto");

            entity.HasIndex(e => e.IdCategoria, "IX_Producto_IdCategoria");

            entity.HasIndex(e => e.IdProveedor, "IX_Producto_IdProveedor");

            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.IdCategoria);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos).HasForeignKey(d => d.IdProveedor);
        });

        modelBuilder.Entity<Producto1>(entity =>
        {
            entity.HasKey(e => e.IdProducto);

            entity.ToTable("Productos");

            entity.HasIndex(e => e.IdCategoria, "IX_Productos_IdCategoria");

            entity.HasIndex(e => e.IdProveedor, "IX_Productos_IdProveedor");

            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.PrecioCompra).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.PrecioVenta).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto1s)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Producto1s)
                .HasForeignKey(d => d.IdProveedor)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.ToTable("Proveedor");

            entity.Property(e => e.ContactoPrincipal).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(200);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor);

            entity.Property(e => e.Contacto).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(200);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasMany(d => d.IdPermisos).WithMany(p => p.IdRols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolPermiso",
                    r => r.HasOne<Permiso>().WithMany().HasForeignKey("IdPermiso"),
                    l => l.HasOne<Rol>().WithMany().HasForeignKey("IdRol"),
                    j =>
                    {
                        j.HasKey("IdRol", "IdPermiso");
                        j.ToTable("RolPermiso");
                        j.HasIndex(new[] { "IdPermiso" }, "IX_RolPermiso_IdPermiso");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasMany(d => d.IdPermisos).WithMany(p => p.IdRols)
                .UsingEntity<Dictionary<string, object>>(
                    "RolesPermiso",
                    r => r.HasOne<Permiso1>().WithMany()
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    l => l.HasOne<Role>().WithMany()
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.ClientSetNull),
                    j =>
                    {
                        j.HasKey("IdRol", "IdPermiso");
                        j.ToTable("RolesPermisos");
                        j.HasIndex(new[] { "IdPermiso" }, "IX_RolesPermisos_IdPermiso");
                    });
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal);

            entity.ToTable("Sucursal");

            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Encargado).HasMaxLength(100);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdSucursal);

            entity.Property(e => e.Direccion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<TipoMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMovimiento);

            entity.ToTable("TipoMovimiento");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<TiposMovimiento>(entity =>
        {
            entity.HasKey(e => e.IdTipoMovimiento);

            entity.ToTable("TiposMovimiento");

            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.IdRol, "IX_Usuario_IdRol");

            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios).HasForeignKey(d => d.IdRol);
        });

        modelBuilder.Entity<Usuario1>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuarios");

            entity.HasIndex(e => e.IdRol, "IX_Usuarios_IdRol");

            entity.Property(e => e.Contraseña).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.NombreUsuario).HasMaxLength(100);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario1s)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
