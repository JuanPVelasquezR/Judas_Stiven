using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("RolPermiso")]
    public class RolPermiso
    {
        [Required]
        public int IdRol { get; set; }
        
        [Required]
        public int IdPermiso { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdRol")]
        public virtual Rol Rol { get; set; }
        
        [ForeignKey("IdPermiso")]
        public virtual Permiso Permiso { get; set; }
    }
}
