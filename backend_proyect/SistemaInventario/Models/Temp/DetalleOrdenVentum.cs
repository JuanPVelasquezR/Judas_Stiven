using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class DetalleOrdenVentum
{
    public int IdDetalleVenta { get; set; }

    public int IdOrdenVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public int? ProductoIdProducto { get; set; }

    public virtual OrdenVentum IdOrdenVentaNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Producto? ProductoIdProductoNavigation { get; set; }
}
