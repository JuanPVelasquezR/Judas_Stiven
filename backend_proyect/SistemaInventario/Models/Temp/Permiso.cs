using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Permiso
{
    public int IdPermiso { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Rol> IdRols { get; set; } = new List<Rol>();
}
