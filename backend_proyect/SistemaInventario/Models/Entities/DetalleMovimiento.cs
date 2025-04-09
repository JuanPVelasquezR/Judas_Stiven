using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("DetalleMovimiento")]
    public class DetalleMovimiento
    {
        [Key]
        public int IdDetalleMovimiento { get; set; }
        
        [Required]
        public int IdMovimiento { get; set; }
        
        [Required]
        public int IdProducto { get; set; }
        
        public int? IdSucursalOrigen { get; set; }
        
        public int? IdSucursalDestino { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdMovimiento")]
        public virtual MovimientoInventario MovimientoInventario { get; set; }
        
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
        
        [ForeignKey("IdSucursalOrigen")]
        public virtual Sucursal SucursalOrigen { get; set; }
        
        [ForeignKey("IdSucursalDestino")]
        public virtual Sucursal SucursalDestino { get; set; }
    }
}
