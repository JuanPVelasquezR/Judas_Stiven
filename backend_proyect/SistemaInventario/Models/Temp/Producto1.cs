using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Producto1
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal PrecioCompra { get; set; }

    public decimal PrecioVenta { get; set; }

    public int IdCategoria { get; set; }

    public int IdProveedor { get; set; }

    public virtual ICollection<DetallesMovimiento> DetallesMovimientos { get; set; } = new List<DetallesMovimiento>();

    public virtual ICollection<DetallesOrdenCompra> DetallesOrdenCompras { get; set; } = new List<DetallesOrdenCompra>();

    public virtual ICollection<DetallesOrdenVentum> DetallesOrdenVenta { get; set; } = new List<DetallesOrdenVentum>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;

    public virtual ICollection<InventarioSucursale> InventarioSucursales { get; set; } = new List<InventarioSucursale>();
}
