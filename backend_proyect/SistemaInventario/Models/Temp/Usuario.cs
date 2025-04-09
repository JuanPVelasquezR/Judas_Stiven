using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string NombreUsuario { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public int IdRol { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;
}
