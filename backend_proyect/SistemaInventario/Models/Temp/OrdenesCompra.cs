using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class OrdenesCompra
{
    public int IdOrdenCompra { get; set; }

    public int IdProveedor { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? CostoTotal { get; set; }

    public virtual ICollection<DetallesOrdenCompra> DetallesOrdenCompras { get; set; } = new List<DetallesOrdenCompra>();

    public virtual Proveedore IdProveedorNavigation { get; set; } = null!;
}
