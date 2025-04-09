using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Proveedore
{
    public int IdProveedor { get; set; }

    public string Nombre { get; set; } = null!;

    public string Contacto { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<OrdenesCompra> OrdenesCompras { get; set; } = new List<OrdenesCompra>();

    public virtual ICollection<Producto1> Producto1s { get; set; } = new List<Producto1>();
}
