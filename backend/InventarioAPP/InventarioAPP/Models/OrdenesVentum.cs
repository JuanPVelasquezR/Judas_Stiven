using System;
using System.Collections.Generic;

namespace InventarioAPP.Models;

public partial class OrdenesVentum
{
    public int IdOrdenVenta { get; set; }

    public int? IdCliente { get; set; }

    public DateOnly? Fecha { get; set; }

    public decimal? Total { get; set; }

    public virtual ICollection<DetallesOrdenVentum> DetallesOrdenVenta { get; set; } = new List<DetallesOrdenVentum>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
