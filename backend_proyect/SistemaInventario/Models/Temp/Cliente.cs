using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contacto { get; set; } = null!;

    public virtual ICollection<OrdenVentum> OrdenVenta { get; set; } = new List<OrdenVentum>();
}
