using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("OrdenVenta")]
    public class OrdenVenta
    {
        [Key]
        public int IdOrdenVenta { get; set; }
        
        [Required]
        public int IdCliente { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? Total { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdCliente")]
        public virtual Cliente Cliente { get; set; }
        
        public virtual ICollection<DetalleOrdenVenta> DetallesOrdenVenta { get; set; }
    }
}
