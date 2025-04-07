using System;
using System.Collections.Generic;

namespace InventarioAPP.Models;

public partial class DetallesOrdenVentum
{
    public int IdDetalleVenta { get; set; }

    public int? IdOrdenVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public virtual OrdenesVentum? IdOrdenVentaNavigation { get; set; }

    public virtual Producto? IdProductoNavigation { get; set; }
}
