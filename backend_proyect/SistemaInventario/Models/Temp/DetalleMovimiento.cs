using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class DetalleMovimiento
{
    public int IdDetalleMovimiento { get; set; }

    public int IdMovimiento { get; set; }

    public int IdProducto { get; set; }

    public int? IdSucursalOrigen { get; set; }

    public int? IdSucursalDestino { get; set; }

    public int Cantidad { get; set; }

    public int? ProductoIdProducto { get; set; }

    public virtual MovimientoInventario IdMovimientoNavigation { get; set; } = null!;

    public virtual Producto IdProductoNavigation { get; set; } = null!;

    public virtual Sucursal? IdSucursalDestinoNavigation { get; set; }

    public virtual Sucursal? IdSucursalOrigenNavigation { get; set; }

    public virtual Producto? ProductoIdProductoNavigation { get; set; }
}
