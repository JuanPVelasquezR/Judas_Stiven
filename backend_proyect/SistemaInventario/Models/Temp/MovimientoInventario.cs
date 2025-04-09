using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class MovimientoInventario
{
    public int IdMovimiento { get; set; }

    public DateTime Fecha { get; set; }

    public int IdTipoMovimiento { get; set; }

    public string Estado { get; set; } = null!;

    public string Observaciones { get; set; } = null!;

    public virtual ICollection<DetalleMovimiento> DetalleMovimientos { get; set; } = new List<DetalleMovimiento>();

    public virtual TipoMovimiento IdTipoMovimientoNavigation { get; set; } = null!;
}
