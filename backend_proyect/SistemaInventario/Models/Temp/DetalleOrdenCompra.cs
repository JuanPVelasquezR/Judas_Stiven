using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class DetalleOrdenCompra
{
    public int IdDetalleCompra { get; set; }

    public int IdOrdenCompra { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Costo { get; set; }

    public int? ProductoIdProducto { get; set; }

    public virtual OrdenCompra IdOrdenCompraNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Producto? ProductoIdProductoNavigation { get; set; }
}
