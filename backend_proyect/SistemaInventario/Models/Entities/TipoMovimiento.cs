using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("TipoMovimiento")]
    public class TipoMovimiento
    {
        [Key]
        public int IdTipoMovimiento { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<MovimientoInventario> MovimientosInventario { get; set; }
    }
}
