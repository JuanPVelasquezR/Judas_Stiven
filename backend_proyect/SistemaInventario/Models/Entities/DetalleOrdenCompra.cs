using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("DetalleOrdenCompra")]
    public class DetalleOrdenCompra
    {
        [Key]
        public int IdDetalleCompra { get; set; }
        
        [Required]
        public int IdOrdenCompra { get; set; }
        
        [Required]
        public int IdProducto { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Costo { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdOrdenCompra")]
        public virtual OrdenCompra OrdenCompra { get; set; }
        
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
    }
}
