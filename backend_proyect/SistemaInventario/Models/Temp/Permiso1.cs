using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Permiso1
{
    public int IdPermiso { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Role> IdRols { get; set; } = new List<Role>();
}
