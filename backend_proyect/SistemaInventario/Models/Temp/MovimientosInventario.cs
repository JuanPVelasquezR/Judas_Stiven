using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class MovimientosInventario
{
    public int IdMovimiento { get; set; }

    public DateTime Fecha { get; set; }

    public int IdTipoMovimiento { get; set; }

    public string Estado { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public virtual ICollection<DetallesMovimiento> DetallesMovimientos { get; set; } = new List<DetallesMovimiento>();

    public virtual TiposMovimiento IdTipoMovimientoNavigation { get; set; } = null!;
}
