using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("DetalleOrdenVenta")]
    public class DetalleOrdenVenta
    {
        [Key]
        public int IdDetalleVenta { get; set; }
        
        [Required]
        public int IdOrdenVenta { get; set; }
        
        [Required]
        public int IdProducto { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Precio { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdOrdenVenta")]
        public virtual OrdenVenta OrdenVenta { get; set; }
        
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
    }
}
