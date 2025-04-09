using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class OrdenVentum
{
    public int IdOrdenVenta { get; set; }

    public int IdCliente { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetalleOrdenVentum> DetalleOrdenVenta { get; set; } = new List<DetalleOrdenVentum>();

    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}
