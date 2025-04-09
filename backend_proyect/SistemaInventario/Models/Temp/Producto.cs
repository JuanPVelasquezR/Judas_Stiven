using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public int IdCategoria { get; set; }

    public int IdProveedor { get; set; }

    public virtual ICollection<DetalleMovimiento> DetalleMovimientoIdProductoNavigations { get; set; } = new List<DetalleMovimiento>();

    public virtual ICollection<DetalleMovimiento> DetalleMovimientoProductoIdProductoNavigations { get; set; } = new List<DetalleMovimiento>();

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompraIdProductoNavigations { get; set; } = new List<DetalleOrdenCompra>();

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompraProductoIdProductoNavigations { get; set; } = new List<DetalleOrdenCompra>();

    public virtual ICollection<DetalleOrdenVentum> DetalleOrdenVentumIdProductoNavigations { get; set; } = new List<DetalleOrdenVentum>();

    public virtual ICollection<DetalleOrdenVentum> DetalleOrdenVentumProductoIdProductoNavigations { get; set; } = new List<DetalleOrdenVentum>();

    public virtual Categorium IdCategoriaNavigation { get; set; } = null!;

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<InventarioSucursal> InventarioSucursals { get; set; } = new List<InventarioSucursal>();
}
