using System;
using System.Collections.Generic;

namespace InventarioAPP.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int? IdCategoria { get; set; }

    public decimal? PrecioCompra { get; set; }

    public decimal? PrecioVenta { get; set; }

    public int? Stock { get; set; }

    public int? IdProveedor { get; set; }

    public virtual ICollection<DetallesOrdenCompra> DetallesOrdenCompras { get; set; } = new List<DetallesOrdenCompra>();

    public virtual ICollection<DetallesOrdenVentum> DetallesOrdenVenta { get; set; } = new List<DetallesOrdenVentum>();

    public virtual Categoria? IdCategoriaNavigation { get; set; }

    public virtual Proveedore? IdProveedorNavigation { get; set; }
}
