using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaInventario.Models.Entities
{
    [Table("Producto")]
    public class Producto
    {
        [Key]
        public int IdProducto { get; set; }
        
        [Required]
        [StringLength(200)]
        public string Nombre { get; set; }
        
        public string Descripcion { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioCompra { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal PrecioVenta { get; set; }
        
        [Required]
        public int IdCategoria { get; set; }
        
        [Required]
        public int IdProveedor { get; set; }
        
        // Propiedades de navegación
        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }
        
        [ForeignKey("IdProveedor")]
        public virtual Proveedor Proveedor { get; set; }
        
        public virtual ICollection<InventarioSucursal> InventarioSucursales { get; set; }
        public virtual ICollection<DetalleMovimiento> DetallesMovimiento { get; set; }
        public virtual ICollection<DetalleOrdenCompra> DetallesOrdenCompra { get; set; }
        public virtual ICollection<DetalleOrdenVenta> DetallesOrdenVenta { get; set; }
    }
}
