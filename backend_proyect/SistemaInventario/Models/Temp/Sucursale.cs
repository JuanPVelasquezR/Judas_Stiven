using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Sucursale
{
    public int IdSucursal { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public virtual ICollection<DetallesMovimiento> DetallesMovimientoIdSucursalDestinoNavigations { get; set; } = new List<DetallesMovimiento>();

    public virtual ICollection<DetallesMovimiento> DetallesMovimientoIdSucursalOrigenNavigations { get; set; } = new List<DetallesMovimiento>();

    public virtual ICollection<InventarioSucursale> InventarioSucursales { get; set; } = new List<InventarioSucursale>();
}
