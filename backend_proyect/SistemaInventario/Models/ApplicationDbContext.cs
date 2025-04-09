using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models.Entities;

namespace SistemaInventario.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<InventarioSucursal> InventarioSucursales { get; set; }
        public DbSet<TipoMovimiento> TiposMovimiento { get; set; }
        public DbSet<MovimientoInventario> MovimientosInventario { get; set; }
        public DbSet<DetalleMovimiento> DetallesMovimiento { get; set; }
        public DbSet<OrdenCompra> OrdenesCompra { get; set; }
        public DbSet<DetalleOrdenCompra> DetallesOrdenCompra { get; set; }
        public DbSet<OrdenVenta> OrdenesVenta { get; set; }
        public DbSet<DetalleOrdenVenta> DetallesOrdenVenta { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<RolPermiso> RolesPermisos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de la relación muchos a muchos entre Rol y Permiso
            modelBuilder.Entity<RolPermiso>()
                .HasKey(rp => new { rp.IdRol, rp.IdPermiso });

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Rol)
                .WithMany(r => r.RolesPermisos)
                .HasForeignKey(rp => rp.IdRol);

            modelBuilder.Entity<RolPermiso>()
                .HasOne(rp => rp.Permiso)
                .WithMany(p => p.RolesPermisos)
                .HasForeignKey(rp => rp.IdPermiso);

            // Configuración de la restricción única para InventarioSucursal
            modelBuilder.Entity<InventarioSucursal>()
                .HasIndex(i => new { i.IdProducto, i.IdSucursal })
                .IsUnique();

            // Configuración de las relaciones entre DetalleMovimiento y Sucursal
            modelBuilder.Entity<DetalleMovimiento>()
                .HasOne(dm => dm.SucursalOrigen)
                .WithMany(s => s.DetallesMovimientoOrigen)
                .HasForeignKey(dm => dm.IdSucursalOrigen)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleMovimiento>()
                .HasOne(dm => dm.SucursalDestino)
                .WithMany(s => s.DetallesMovimientoDestino)
                .HasForeignKey(dm => dm.IdSucursalDestino)
                .OnDelete(DeleteBehavior.Restrict);

            // Configuración para evitar ciclos de eliminación en cascada
            modelBuilder.Entity<DetalleOrdenCompra>()
                .HasOne(doc => doc.Producto)
                .WithMany()
                .HasForeignKey(doc => doc.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleOrdenVenta>()
                .HasOne(dov => dov.Producto)
                .WithMany()
                .HasForeignKey(dov => dov.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DetalleMovimiento>()
                .HasOne(dm => dm.Producto)
                .WithMany()
                .HasForeignKey(dm => dm.IdProducto)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}
