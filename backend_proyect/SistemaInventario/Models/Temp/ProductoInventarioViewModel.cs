using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaInventario.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SistemaInventario.Models.Temp
{
    public class ProductoInventarioViewModel
    {
        // Propiedades del Producto
        public int IdProducto { get; set; }
        
        [Required(ErrorMessage = "El nombre del producto es obligatorio")]
        [StringLength(200, ErrorMessage = "El nombre no puede exceder los 200 caracteres")]
        public string Nombre { get; set; } = string.Empty;
        
        public string? Descripcion { get; set; }
        
        [Required(ErrorMessage = "El precio de compra es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio de compra debe ser mayor que cero")]
        public decimal PrecioCompra { get; set; }
        
        [Required(ErrorMessage = "El precio de venta es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio de venta debe ser mayor que cero")]
        public decimal PrecioVenta { get; set; }
        
        [Required(ErrorMessage = "La categoría es obligatoria")]
        public int IdCategoria { get; set; }
        
        [Required(ErrorMessage = "El proveedor es obligatorio")]
        public int IdProveedor { get; set; }
        
        // Propiedades para el inventario
        public List<InventarioSucursalViewModel> InventarioSucursales { get; set; }
        
        // Propiedades para los dropdowns
        public SelectList? Categorias { get; set; }
        public SelectList? Proveedores { get; set; }
        public SelectList? Sucursales { get; set; }
        
        public ProductoInventarioViewModel()
        {
            InventarioSucursales = new List<InventarioSucursalViewModel>();
        }
    }
    
    public class InventarioSucursalViewModel
    {
        public int IdSucursal { get; set; }
        public string NombreSucursal { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public int StockMinimo { get; set; }
    }
}
