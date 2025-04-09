using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }
        
        [Required]
        [StringLength(100)]
        public string NombreUsuario { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Contraseña { get; set; }
        
        // Campo opcional para compatibilidad con la recuperación de contraseña
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }
        
        [Required]
        public int IdRol { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdRol")]
        public virtual Rol Rol { get; set; }
    }
}
