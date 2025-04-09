using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Permiso")]
    public class Permiso
    {
        [Key]
        public int IdPermiso { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Codigo { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<RolPermiso> RolesPermisos { get; set; }
    }
}
