using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class DetallesOrdenCompra
{
    public int IdDetalleCompra { get; set; }

    public int IdOrdenCompra { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Costo { get; set; }

    public virtual OrdenesCompra IdOrdenCompraNavigation { get; set; } = null!;

    public virtual Producto1 IdProductoNavigation { get; set; } = null!;
}
