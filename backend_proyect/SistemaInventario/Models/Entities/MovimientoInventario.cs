using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("MovimientoInventario")]
    public class MovimientoInventario
    {
        [Key]
        public int IdMovimiento { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        
        [Required]
        public int IdTipoMovimiento { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Estado { get; set; }
        
        public string Observaciones { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdTipoMovimiento")]
        public virtual TipoMovimiento TipoMovimiento { get; set; }
        
        public virtual ICollection<DetalleMovimiento> DetallesMovimiento { get; set; }
    }
}
