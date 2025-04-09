using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Categoria")]
    public class Categoria
    {
        public Categoria()
        {
            // Inicializar la colección de productos para evitar errores de referencia nula
            Productos = new List<Producto>();
        }
        
        [Key]
        public int IdCategoria { get; set; }
        
        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres")]
        public string Nombre { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<Producto> Productos { get; set; }
    }
}
