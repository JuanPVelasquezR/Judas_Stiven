using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class OrdenCompra
{
    public int IdOrdenCompra { get; set; }

    public int IdProveedor { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? CostoTotal { get; set; }

    public virtual ICollection<DetalleOrdenCompra> DetalleOrdenCompras { get; set; } = new List<DetalleOrdenCompra>();

    public virtual Proveedor IdProveedorNavigation { get; set; } = null!;
}
