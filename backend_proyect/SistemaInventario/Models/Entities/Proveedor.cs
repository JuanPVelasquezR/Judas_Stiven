using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        public int IdProveedor { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }
        
        [StringLength(100)]
        public string ContactoPrincipal { get; set; }
        
        public string Direccion { get; set; }
        
        [StringLength(20)]
        public string Telefono { get; set; }
        
        [StringLength(100)]
        public string Email { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
