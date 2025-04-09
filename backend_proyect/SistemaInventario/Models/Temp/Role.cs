using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Role
{
    public int IdRol { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Usuario1> Usuario1s { get; set; } = new List<Usuario1>();

    public virtual ICollection<Permiso1> IdPermisos { get; set; } = new List<Permiso1>();
}
