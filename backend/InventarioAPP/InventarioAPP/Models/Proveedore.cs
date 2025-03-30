using System;
using System.Collections.Generic;

namespace InventarioAPP.Models;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Contacto { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
