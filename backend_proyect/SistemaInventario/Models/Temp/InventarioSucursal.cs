using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class InventarioSucursal
{
    public int IdInventario { get; set; }

    public int IdProducto { get; set; }

    public int IdSucursal { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursal IdSucursalNavigation { get; set; } = null!;
}
