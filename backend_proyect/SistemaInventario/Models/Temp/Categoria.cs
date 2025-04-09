using System;
using System.Collections.Generic;

namespace SistemaInventario.Models.Temp;

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<Producto1> Producto1s { get; set; } = new List<Producto1>();
}
