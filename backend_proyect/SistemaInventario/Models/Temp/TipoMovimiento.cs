using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class TipoMovimiento
{
    public int IdTipoMovimiento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<MovimientoInventario> MovimientoInventarios { get; set; } = new List<MovimientoInventario>();
}
