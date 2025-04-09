using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<RolPermiso> RolesPermisos { get; set; }
    }
}
