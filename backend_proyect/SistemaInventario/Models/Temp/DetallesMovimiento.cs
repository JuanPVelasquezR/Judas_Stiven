using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class DetallesMovimiento
{
    public int IdDetalleMovimiento { get; set; }

    public int IdMovimiento { get; set; }

    public int IdProducto { get; set; }

    public int? IdSucursalOrigen { get; set; }

    public int? IdSucursalDestino { get; set; }

    public int Cantidad { get; set; }

    public virtual MovimientosInventario IdMovimientoNavigation { get; set; } = null!;

    public virtual Producto1 IdProductoNavigation { get; set; } = null!;

    public virtual Sucursale? IdSucursalDestinoNavigation { get; set; }

    public virtual Sucursale? IdSucursalOrigenNavigation { get; set; }
}
