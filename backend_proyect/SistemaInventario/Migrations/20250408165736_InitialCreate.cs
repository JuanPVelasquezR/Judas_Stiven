using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaInventario.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Contacto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                });

            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });

            migrationBuilder.CreateTable(
                name: "Proveedor",
                columns: table => new
                {
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContactoPrincipal = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedor", x => x.IdProveedor);
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.IdRol);
                });

            migrationBuilder.CreateTable(
                name: "Sucursal",
                columns: table => new
                {
                    IdSucursal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Encargado = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sucursal", x => x.IdSucursal);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimiento",
                columns: table => new
                {
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimiento", x => x.IdTipoMovimiento);
                });

            migrationBuilder.CreateTable(
                name: "OrdenVenta",
                columns: table => new
                {
                    IdOrdenVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenVenta", x => x.IdOrdenVenta);
                    table.ForeignKey(
                        name: "FK_OrdenVenta_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrdenCompra",
                columns: table => new
                {
                    IdOrdenCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProveedor = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "date", nullable: false),
                    CostoTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenCompra", x => x.IdOrdenCompra);
                    table.ForeignKey(
                        name: "FK_OrdenCompra_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioCompra = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    IdCategoria = table.Column<int>(type: "int", nullable: false),
                    IdProveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                    table.ForeignKey(
                        name: "FK_Producto_Categoria_IdCategoria",
                        column: x => x.IdCategoria,
                        principalTable: "Categoria",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Producto_Proveedor_IdProveedor",
                        column: x => x.IdProveedor,
                        principalTable: "Proveedor",
                        principalColumn: "IdProveedor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolPermiso",
                columns: table => new
                {
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolPermiso", x => new { x.IdRol, x.IdPermiso });
                    table.ForeignKey(
                        name: "FK_RolPermiso_Permiso_IdPermiso",
                        column: x => x.IdPermiso,
                        principalTable: "Permiso",
                        principalColumn: "IdPermiso",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolPermiso_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NombreUsuario = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Contraseña = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IdRol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                    table.ForeignKey(
                        name: "FK_Usuario_Rol_IdRol",
                        column: x => x.IdRol,
                        principalTable: "Rol",
                        principalColumn: "IdRol",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimientoInventario",
                columns: table => new
                {
                    IdMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoMovimiento = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimientoInventario", x => x.IdMovimiento);
                    table.ForeignKey(
                        name: "FK_MovimientoInventario_TipoMovimiento_IdTipoMovimiento",
                        column: x => x.IdTipoMovimiento,
                        principalTable: "TipoMovimiento",
                        principalColumn: "IdTipoMovimiento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenCompra",
                columns: table => new
                {
                    IdDetalleCompra = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdenCompra = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Costo = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenCompra", x => x.IdDetalleCompra);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenCompra_OrdenCompra_IdOrdenCompra",
                        column: x => x.IdOrdenCompra,
                        principalTable: "OrdenCompra",
                        principalColumn: "IdOrdenCompra",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenCompra_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenCompra_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                });

            migrationBuilder.CreateTable(
                name: "DetalleOrdenVenta",
                columns: table => new
                {
                    IdDetalleVenta = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdenVenta = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleOrdenVenta", x => x.IdDetalleVenta);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVenta_OrdenVenta_IdOrdenVenta",
                        column: x => x.IdOrdenVenta,
                        principalTable: "OrdenVenta",
                        principalColumn: "IdOrdenVenta",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVenta_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleOrdenVenta_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                });

            migrationBuilder.CreateTable(
                name: "InventarioSucursal",
                columns: table => new
                {
                    IdInventario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdSucursal = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventarioSucursal", x => x.IdInventario);
                    table.ForeignKey(
                        name: "FK_InventarioSucursal_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventarioSucursal_Sucursal_IdSucursal",
                        column: x => x.IdSucursal,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetalleMovimiento",
                columns: table => new
                {
                    IdDetalleMovimiento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdMovimiento = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdSucursalOrigen = table.Column<int>(type: "int", nullable: true),
                    IdSucursalDestino = table.Column<int>(type: "int", nullable: true),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalleMovimiento", x => x.IdDetalleMovimiento);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_MovimientoInventario_IdMovimiento",
                        column: x => x.IdMovimiento,
                        principalTable: "MovimientoInventario",
                        principalColumn: "IdMovimiento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Producto_IdProducto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Sucursal_IdSucursalDestino",
                        column: x => x.IdSucursalDestino,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DetalleMovimiento_Sucursal_IdSucursalOrigen",
                        column: x => x.IdSucursalOrigen,
                        principalTable: "Sucursal",
                        principalColumn: "IdSucursal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdMovimiento",
                table: "DetalleMovimiento",
                column: "IdMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdProducto",
                table: "DetalleMovimiento",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdSucursalDestino",
                table: "DetalleMovimiento",
                column: "IdSucursalDestino");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_IdSucursalOrigen",
                table: "DetalleMovimiento",
                column: "IdSucursalOrigen");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleMovimiento_ProductoIdProducto",
                table: "DetalleMovimiento",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenCompra_IdOrdenCompra",
                table: "DetalleOrdenCompra",
                column: "IdOrdenCompra");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenCompra_IdProducto",
                table: "DetalleOrdenCompra",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenCompra_ProductoIdProducto",
                table: "DetalleOrdenCompra",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVenta_IdOrdenVenta",
                table: "DetalleOrdenVenta",
                column: "IdOrdenVenta");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVenta_IdProducto",
                table: "DetalleOrdenVenta",
                column: "IdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_DetalleOrdenVenta_ProductoIdProducto",
                table: "DetalleOrdenVenta",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSucursal_IdProducto_IdSucursal",
                table: "InventarioSucursal",
                columns: new[] { "IdProducto", "IdSucursal" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventarioSucursal_IdSucursal",
                table: "InventarioSucursal",
                column: "IdSucursal");

            migrationBuilder.CreateIndex(
                name: "IX_MovimientoInventario_IdTipoMovimiento",
                table: "MovimientoInventario",
                column: "IdTipoMovimiento");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenCompra_IdProveedor",
                table: "OrdenCompra",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenVenta_IdCliente",
                table: "OrdenVenta",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdCategoria",
                table: "Producto",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdProveedor",
                table: "Producto",
                column: "IdProveedor");

            migrationBuilder.CreateIndex(
                name: "IX_RolPermiso_IdPermiso",
                table: "RolPermiso",
                column: "IdPermiso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_IdRol",
                table: "Usuario",
                column: "IdRol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalleMovimiento");

            migrationBuilder.DropTable(
                name: "DetalleOrdenCompra");

            migrationBuilder.DropTable(
                name: "DetalleOrdenVenta");

            migrationBuilder.DropTable(
                name: "InventarioSucursal");

            migrationBuilder.DropTable(
                name: "RolPermiso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "MovimientoInventario");

            migrationBuilder.DropTable(
                name: "OrdenCompra");

            migrationBuilder.DropTable(
                name: "OrdenVenta");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Sucursal");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "TipoMovimiento");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Categoria");

            migrationBuilder.DropTable(
                name: "Proveedor");
        }
    }
}
