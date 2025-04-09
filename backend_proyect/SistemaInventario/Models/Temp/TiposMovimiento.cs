using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class TiposMovimiento
{
    public int IdTipoMovimiento { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<MovimientosInventario> MovimientosInventarios { get; set; } = new List<MovimientosInventario>();
}
