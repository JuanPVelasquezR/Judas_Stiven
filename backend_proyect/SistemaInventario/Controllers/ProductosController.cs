using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Filters;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using SistemaInventario.Models.Temp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Controllers
{
    [RequirePermission("PRODUCT_VIEW")]
    public class ProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Productos
        public async Task<IActionResult> Index(string searchString)
        {
            var productos = _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                productos = productos.Where(p => p.Nombre.Contains(searchString) || 
                                               p.Descripcion.Contains(searchString) ||
                                               p.Categoria.Nombre.Contains(searchString));
            }

            // Cargar categorías y proveedores para el formulario de creación
            ViewBag.IdCategoria = new SelectList(_context.Categorias, "IdCategoria", "Nombre");
            ViewBag.IdProveedor = new SelectList(_context.Proveedores, "IdProveedor", "Nombre");
            
            ViewData["CurrentFilter"] = searchString;
            return View(await productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .Include(p => p.InventarioSucursales)
                    .ThenInclude(i => i.Sucursal)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        [RequirePermission("INVENTORY_EDIT")]
        public IActionResult Create()
        {
            var viewModel = new ProductoInventarioViewModel
            {
                Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nombre"),
                Proveedores = new SelectList(_context.Proveedores, "IdProveedor", "Nombre"),
                Sucursales = new SelectList(_context.Sucursales, "IdSucursal", "Nombre")
            };

            // Inicializar el inventario para cada sucursal
            var sucursales = _context.Sucursales.ToList();
            foreach (var sucursal in sucursales)
            {
                viewModel.InventarioSucursales.Add(new InventarioSucursalViewModel
                {
                    IdSucursal = sucursal.IdSucursal,
                    NombreSucursal = sucursal.Nombre,
                    Cantidad = 0,
                    StockMinimo = 5 // Valor predeterminado
                });
            }

            return View(viewModel);
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequirePermission("INVENTORY_EDIT")]
        public async Task<IActionResult> Create(ProductoInventarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Crear el producto
                var producto = new SistemaInventario.Models.Entities.Producto
                {
                    Nombre = viewModel.Nombre,
                    Descripcion = viewModel.Descripcion ?? string.Empty,
                    PrecioCompra = viewModel.PrecioCompra,
                    PrecioVenta = viewModel.PrecioVenta,
                    IdCategoria = viewModel.IdCategoria,
                    IdProveedor = viewModel.IdProveedor
                };

                _context.Add(producto);
                await _context.SaveChangesAsync();

                // Crear registros de inventario para cada sucursal
                foreach (var inventarioSucursal in viewModel.InventarioSucursales)
                {
                    if (inventarioSucursal.Cantidad > 0)
                    {
                          var nuevoInventario = new SistemaInventario.Models.Entities.InventarioSucursal
                        {
                            IdProducto = producto.IdProducto,
                            IdSucursal = inventarioSucursal.IdSucursal,
                            Cantidad = inventarioSucursal.Cantidad,
                            StockMinimo = inventarioSucursal.StockMinimo
                        };

                        _context.Add(nuevoInventario);
                    }
                }

                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Producto creado correctamente con su inventario inicial.";
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, reconstruir el ViewModel
            viewModel.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nombre", viewModel.IdCategoria);
            viewModel.Proveedores = new SelectList(_context.Proveedores, "IdProveedor", "Nombre", viewModel.IdProveedor);
            viewModel.Sucursales = new SelectList(_context.Sucursales, "IdSucursal", "Nombre");

            // Recargar las sucursales si es necesario
            if (viewModel.InventarioSucursales.Count == 0)
            {
                var sucursales = _context.Sucursales.ToList();
                foreach (var sucursal in sucursales)
                {
                    viewModel.InventarioSucursales.Add(new InventarioSucursalViewModel
                    {
                        IdSucursal = sucursal.IdSucursal,
                        NombreSucursal = sucursal.Nombre,
                        Cantidad = 0,
                        StockMinimo = 5
                    });
                }
            }

            return View(viewModel);
        }

        // GET: Productos/Edit/5
        [RequirePermission("INVENTORY_EDIT")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.InventarioSucursales)
                .FirstOrDefaultAsync(p => p.IdProducto == id);
                
            if (producto == null)
            {
                return NotFound();
            }
            
            var viewModel = new ProductoInventarioViewModel
            {
                IdProducto = producto.IdProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                PrecioCompra = producto.PrecioCompra,
                PrecioVenta = producto.PrecioVenta,
                IdCategoria = producto.IdCategoria,
                IdProveedor = producto.IdProveedor,
                Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nombre", producto.IdCategoria),
                Proveedores = new SelectList(_context.Proveedores, "IdProveedor", "Nombre", producto.IdProveedor),
                Sucursales = new SelectList(_context.Sucursales, "IdSucursal", "Nombre")
            };

            // Obtener todas las sucursales
            var sucursales = await _context.Sucursales.ToListAsync();
            
            // Para cada sucursal, buscar si tiene inventario para este producto
            foreach (var sucursal in sucursales)
            {
                var inventario = producto.InventarioSucursales
                    .FirstOrDefault(i => i.IdSucursal == sucursal.IdSucursal);
                    
                viewModel.InventarioSucursales.Add(new InventarioSucursalViewModel
                {
                    IdSucursal = sucursal.IdSucursal,
                    NombreSucursal = sucursal.Nombre,
                    Cantidad = inventario?.Cantidad ?? 0,
                    StockMinimo = inventario?.StockMinimo ?? 5
                });
            }
            
            return View(viewModel);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequirePermission("INVENTORY_EDIT")]
        public async Task<IActionResult> Edit(int id, ProductoInventarioViewModel viewModel)
        {
            if (id != viewModel.IdProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Actualizar el producto
                    var producto = await _context.Productos.FindAsync(id);
                    if (producto == null)
                    {
                        return NotFound();
                    }

                    producto.Nombre = viewModel.Nombre;
                    producto.Descripcion = viewModel.Descripcion ?? string.Empty;
                    producto.PrecioCompra = viewModel.PrecioCompra;
                    producto.PrecioVenta = viewModel.PrecioVenta;
                    producto.IdCategoria = viewModel.IdCategoria;
                    producto.IdProveedor = viewModel.IdProveedor;

                    _context.Update(producto);
                    
                    // Actualizar o crear registros de inventario para cada sucursal
                    foreach (var inventarioSucursal in viewModel.InventarioSucursales)
                    {
                        // Buscar si ya existe un registro de inventario para esta sucursal y producto
                        var inventarioExistente = await _context.InventarioSucursales
                            .FirstOrDefaultAsync(i => i.IdProducto == id && i.IdSucursal == inventarioSucursal.IdSucursal);

                        if (inventarioExistente != null)
                        {
                            // Actualizar el inventario existente
                            inventarioExistente.Cantidad = inventarioSucursal.Cantidad;
                            inventarioExistente.StockMinimo = inventarioSucursal.StockMinimo;
                            _context.Update(inventarioExistente);
                        }
                        else if (inventarioSucursal.Cantidad > 0)
                        {
                            // Crear un nuevo registro de inventario si no existe y la cantidad es mayor que cero
                             var nuevoInventario = new SistemaInventario.Models.Entities.InventarioSucursal
                            {
                                IdProducto = id,
                                IdSucursal = inventarioSucursal.IdSucursal,
                                Cantidad = inventarioSucursal.Cantidad,
                                StockMinimo = inventarioSucursal.StockMinimo
                            };
                            _context.Add(nuevoInventario);
                        }
                    }

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Producto actualizado correctamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoExists(viewModel.IdProducto))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            // Si hay errores, reconstruir el ViewModel
            viewModel.Categorias = new SelectList(_context.Categorias, "IdCategoria", "Nombre", viewModel.IdCategoria);
            viewModel.Proveedores = new SelectList(_context.Proveedores, "IdProveedor", "Nombre", viewModel.IdProveedor);
            viewModel.Sucursales = new SelectList(_context.Sucursales, "IdSucursal", "Nombre");

            return View(viewModel);
        }

        // GET: Productos/Delete/5
        [RequirePermission("INVENTORY_EDIT")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var producto = await _context.Productos
                .Include(p => p.Categoria)
                .Include(p => p.Proveedor)
                .FirstOrDefaultAsync(m => m.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RequirePermission("INVENTORY_EDIT")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                // Primero, eliminar los registros de inventario relacionados
                var inventarios = await _context.InventarioSucursales
                    .Where(i => i.IdProducto == id)
                    .ToListAsync();
                    
                _context.InventarioSucursales.RemoveRange(inventarios);
                
                // Luego, eliminar el producto
                var producto = await _context.Productos.FindAsync(id);
                if (producto != null)
                {
                    _context.Productos.Remove(producto);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Producto eliminado correctamente.";
                }
            }
            catch (Exception)
            {
                // Si hay un error (por ejemplo, si el producto está siendo utilizado en algún movimiento)
                TempData["ErrorMessage"] = "No se pudo eliminar el producto. Puede estar siendo utilizado en movimientos de inventario o ventas.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.IdProducto == id);
        }
    }
}
