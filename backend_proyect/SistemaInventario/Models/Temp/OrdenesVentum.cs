using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class OrdenesVentum
{
    public int IdOrdenVenta { get; set; }

    public int IdCliente { get; set; }

    public DateOnly Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetallesOrdenVentum> DetallesOrdenVenta { get; set; } = new List<DetallesOrdenVentum>();

    public virtual Cliente1 IdClienteNavigation { get; set; } = null!;
}
