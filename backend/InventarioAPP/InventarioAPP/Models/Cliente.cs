using System;
using System.Collections.Generic;

namespace InventarioAPP.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public virtual ICollection<OrdenesVentum> OrdenesVenta { get; set; } = new List<OrdenesVentum>();
}
