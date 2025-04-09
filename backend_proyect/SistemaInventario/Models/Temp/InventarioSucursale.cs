using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class InventarioSucursale
{
    public int IdInventario { get; set; }

    public int IdProducto { get; set; }

    public int IdSucursal { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto1 IdProductoNavigation { get; set; } = null!;

    public virtual Sucursale IdSucursalNavigation { get; set; } = null!;
}
