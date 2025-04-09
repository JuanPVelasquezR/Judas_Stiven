using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Cliente")]
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Nombre { get; set; }
        
        [StringLength(100)]
        public string Contacto { get; set; }
        
        // Propiedades de navegación
        public virtual ICollection<OrdenVenta> OrdenesVenta { get; set; }
    }
}
