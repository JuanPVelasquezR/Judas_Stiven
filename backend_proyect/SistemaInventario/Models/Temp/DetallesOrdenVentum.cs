using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class DetallesOrdenVentum
{
    public int IdDetalleVenta { get; set; }

    public int IdOrdenVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal Precio { get; set; }

    public virtual OrdenesVentum IdOrdenVentaNavigation { get; set; } = null!;

    public virtual Producto1 IdProductoNavigation { get; set; } = null!;
}
