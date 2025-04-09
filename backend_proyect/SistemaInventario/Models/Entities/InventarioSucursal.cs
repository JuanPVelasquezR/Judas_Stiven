using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("InventarioSucursal")]
    public class InventarioSucursal
    {
        [Key]
        public int IdInventario { get; set; }
        
        [Required]
        public int IdProducto { get; set; }
        
        [Required]
        public int IdSucursal { get; set; }
        
        [Required]
        public int Cantidad { get; set; }
        
        [Required]
        public int StockMinimo { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdProducto")]
        public virtual Producto Producto { get; set; }
        
        [ForeignKey("IdSucursal")]
        public virtual Sucursal Sucursal { get; set; }
    }
}
