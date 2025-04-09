using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("OrdenCompra")]
    public class OrdenCompra
    {
        [Key]
        public int IdOrdenCompra { get; set; }
        
        [Required]
        public int IdProveedor { get; set; }
        
        [Required]
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        
        [Column(TypeName = "decimal(10,2)")]
        public decimal? CostoTotal { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdProveedor")]
        public virtual Proveedor Proveedor { get; set; }
        
        public virtual ICollection<DetalleOrdenCompra> DetallesOrdenCompra { get; set; }
    }
}
