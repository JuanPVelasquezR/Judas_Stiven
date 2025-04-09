using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Sucursal")]
    public class Sucursal
    {
        [Key]
        public int IdSucursal { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [StringLength(255)]
        public string Direccion { get; set; }
        
        [StringLength(20)]
        public string Telefono { get; set; }
        
        [StringLength(100)]
        public string Encargado { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<InventarioSucursal> InventarioSucursales { get; set; }
        public virtual ICollection<DetalleMovimiento> DetallesMovimientoOrigen { get; set; }
        public virtual ICollection<DetalleMovimiento> DetallesMovimientoDestino { get; set; }
    }
}
