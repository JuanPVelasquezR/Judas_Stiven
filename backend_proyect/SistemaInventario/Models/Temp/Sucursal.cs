using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Encargado { get; set; } = null!;

    public virtual ICollection<DetalleMovimiento> DetalleMovimientoIdSucursalDestinoNavigations { get; set; } = new List<DetalleMovimiento>();

    public virtual ICollection<DetalleMovimiento> DetalleMovimientoIdSucursalOrigenNavigations { get; set; } = new List<DetalleMovimiento>();

    public virtual ICollection<InventarioSucursal> InventarioSucursals { get; set; } = new List<InventarioSucursal>();
}
