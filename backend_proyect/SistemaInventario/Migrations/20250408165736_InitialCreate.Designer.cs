﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaInventario.Models;

#nullable disable

namespace SistemaInventario.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250408165736_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.3.24172.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SistemaInventario.Models.Entities.Categoria", b =>
                {
                    b.Property<int>("IdCategoria")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCategoria"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdCategoria");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdCliente"));

                    b.Property<string>("Contacto")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.DetalleMovimiento", b =>
                {
                    b.Property<int>("IdDetalleMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleMovimiento"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdMovimiento")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("IdSucursalDestino")
                        .HasColumnType("int");

                    b.Property<int?>("IdSucursalOrigen")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoIdProducto")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleMovimiento");

                    b.HasIndex("IdMovimiento");

                    b.HasIndex("IdProducto");

                    b.HasIndex("IdSucursalDestino");

                    b.HasIndex("IdSucursalOrigen");

                    b.HasIndex("ProductoIdProducto");

                    b.ToTable("DetalleMovimiento");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.DetalleOrdenCompra", b =>
                {
                    b.Property<int>("IdDetalleCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleCompra"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("IdOrdenCompra")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int?>("ProductoIdProducto")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleCompra");

                    b.HasIndex("IdOrdenCompra");

                    b.HasIndex("IdProducto");

                    b.HasIndex("ProductoIdProducto");

                    b.ToTable("DetalleOrdenCompra");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.DetalleOrdenVenta", b =>
                {
                    b.Property<int>("IdDetalleVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdDetalleVenta"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdOrdenVenta")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int?>("ProductoIdProducto")
                        .HasColumnType("int");

                    b.HasKey("IdDetalleVenta");

                    b.HasIndex("IdOrdenVenta");

                    b.HasIndex("IdProducto");

                    b.HasIndex("ProductoIdProducto");

                    b.ToTable("DetalleOrdenVenta");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.InventarioSucursal", b =>
                {
                    b.Property<int>("IdInventario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdInventario"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("IdProducto")
                        .HasColumnType("int");

                    b.Property<int>("IdSucursal")
                        .HasColumnType("int");

                    b.HasKey("IdInventario");

                    b.HasIndex("IdSucursal");

                    b.HasIndex("IdProducto", "IdSucursal")
                        .IsUnique();

                    b.ToTable("InventarioSucursal");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.MovimientoInventario", b =>
                {
                    b.Property<int>("IdMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdMovimiento"));

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTipoMovimiento")
                        .HasColumnType("int");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdMovimiento");

                    b.HasIndex("IdTipoMovimiento");

                    b.ToTable("MovimientoInventario");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.OrdenCompra", b =>
                {
                    b.Property<int>("IdOrdenCompra")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrdenCompra"));

                    b.Property<decimal?>("CostoTotal")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.HasKey("IdOrdenCompra");

                    b.HasIndex("IdProveedor");

                    b.ToTable("OrdenCompra");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.OrdenVenta", b =>
                {
                    b.Property<int>("IdOrdenVenta")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdOrdenVenta"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("date");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdOrdenVenta");

                    b.HasIndex("IdCliente");

                    b.ToTable("OrdenVenta");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Permiso", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermiso"));

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdPermiso");

                    b.ToTable("Permiso");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProducto"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategoria")
                        .HasColumnType("int");

                    b.Property<int>("IdProveedor")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("PrecioCompra")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("PrecioVenta")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("IdProducto");

                    b.HasIndex("IdCategoria");

                    b.HasIndex("IdProveedor");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdProveedor"));

                    b.Property<string>("ContactoPrincipal")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRol"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdRol");

                    b.ToTable("Rol");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.RolPermiso", b =>
                {
                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<int>("IdPermiso")
                        .HasColumnType("int");

                    b.HasKey("IdRol", "IdPermiso");

                    b.HasIndex("IdPermiso");

                    b.ToTable("RolPermiso");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Sucursal", b =>
                {
                    b.Property<int>("IdSucursal")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdSucursal"));

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Encargado")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Telefono")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("IdSucursal");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.TipoMovimiento", b =>
                {
                    b.Property<int>("IdTipoMovimiento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdTipoMovimiento"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdTipoMovimiento");

                    b.ToTable("TipoMovimiento");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contraseña")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<int>("IdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdRol");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.DetalleMovimiento", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.MovimientoInventario", "MovimientoInventario")
                        .WithMany("DetallesMovimiento")
                        .HasForeignKey("IdMovimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Sucursal", "SucursalDestino")
                        .WithMany("DetallesMovimientoDestino")
                        .HasForeignKey("IdSucursalDestino")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SistemaInventario.Models.Entities.Sucursal", "SucursalOrigen")
                        .WithMany("DetallesMovimientoOrigen")
                        .HasForeignKey("IdSucursalOrigen")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("SistemaInventario.Models.Entities.Producto", null)
                        .WithMany("DetallesMovimiento")
                        .HasForeignKey("ProductoIdProducto");

                    b.Navigation("MovimientoInventario");

                    b.Navigation("Producto");

                    b.Navigation("SucursalDestino");

                    b.Navigation("SucursalOrigen");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.DetalleOrdenCompra", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.OrdenCompra", "OrdenCompra")
                        .WithMany("DetallesOrdenCompra")
                        .HasForeignKey("IdOrdenCompra")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Producto", null)
                        .WithMany("DetallesOrdenCompra")
                        .HasForeignKey("ProductoIdProducto");

                    b.Navigation("OrdenCompra");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.DetalleOrdenVenta", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.OrdenVenta", "OrdenVenta")
                        .WithMany("DetallesOrdenVenta")
                        .HasForeignKey("IdOrdenVenta")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Producto", null)
                        .WithMany("DetallesOrdenVenta")
                        .HasForeignKey("ProductoIdProducto");

                    b.Navigation("OrdenVenta");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.InventarioSucursal", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.Producto", "Producto")
                        .WithMany("InventarioSucursales")
                        .HasForeignKey("IdProducto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Sucursal", "Sucursal")
                        .WithMany("InventarioSucursales")
                        .HasForeignKey("IdSucursal")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producto");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.MovimientoInventario", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.TipoMovimiento", "TipoMovimiento")
                        .WithMany("MovimientosInventario")
                        .HasForeignKey("IdTipoMovimiento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoMovimiento");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.OrdenCompra", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.OrdenVenta", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.Cliente", "Cliente")
                        .WithMany("OrdenesVenta")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Producto", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Proveedor", "Proveedor")
                        .WithMany("Productos")
                        .HasForeignKey("IdProveedor")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");

                    b.Navigation("Proveedor");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.RolPermiso", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.Permiso", "Permiso")
                        .WithMany("RolesPermisos")
                        .HasForeignKey("IdPermiso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SistemaInventario.Models.Entities.Rol", "Rol")
                        .WithMany("RolesPermisos")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permiso");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Usuario", b =>
                {
                    b.HasOne("SistemaInventario.Models.Entities.Rol", "Rol")
                        .WithMany("Usuarios")
                        .HasForeignKey("IdRol")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Cliente", b =>
                {
                    b.Navigation("OrdenesVenta");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.MovimientoInventario", b =>
                {
                    b.Navigation("DetallesMovimiento");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.OrdenCompra", b =>
                {
                    b.Navigation("DetallesOrdenCompra");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.OrdenVenta", b =>
                {
                    b.Navigation("DetallesOrdenVenta");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Permiso", b =>
                {
                    b.Navigation("RolesPermisos");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Producto", b =>
                {
                    b.Navigation("DetallesMovimiento");

                    b.Navigation("DetallesOrdenCompra");

                    b.Navigation("DetallesOrdenVenta");

                    b.Navigation("InventarioSucursales");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Proveedor", b =>
                {
                    b.Navigation("Productos");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Rol", b =>
                {
                    b.Navigation("RolesPermisos");

                    b.Navigation("Usuarios");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.Sucursal", b =>
                {
                    b.Navigation("DetallesMovimientoDestino");

                    b.Navigation("DetallesMovimientoOrigen");

                    b.Navigation("InventarioSucursales");
                });

            modelBuilder.Entity("SistemaInventario.Models.Entities.TipoMovimiento", b =>
                {
                    b.Navigation("MovimientosInventario");
                });
#pragma warning restore 612, 618
        }
    }
}
