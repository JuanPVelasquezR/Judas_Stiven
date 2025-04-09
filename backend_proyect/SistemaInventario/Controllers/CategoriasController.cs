using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Filters;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using System.Threading.Tasks;

namespace SistemaInventario.Controllers
{
    [RequirePermission("CATEGORY_VIEW")]
    public class CategoriasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categorias
        public async Task<IActionResult> Index(string searchString)
        {
            var categorias = _context.Categorias.AsQueryable();

            if (!string.IsNullOrEmpty(searchString))
            {
                categorias = categorias.Where(c => c.Nombre.Contains(searchString));
            }

            ViewData["CurrentFilter"] = searchString;
            return View(await categorias.ToListAsync());
        }

        // GET: Categorias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // GET: Categorias/Create
        [RequirePermission("CATEGORY_EDIT")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categorias/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequirePermission("CATEGORY_EDIT")]
        public async Task<IActionResult> Create(string Nombre)
        {
            try
            {
                // Mostrar los errores de validación si existen
                foreach (var state in ModelState)
                {
                    if (state.Value.Errors.Count > 0)
                    {
                        var errorMessages = string.Join(", ", state.Value.Errors.Select(e => e.ErrorMessage));
                        System.Diagnostics.Debug.WriteLine($"Error en {state.Key}: {errorMessages}");
                    }
                }

                if (ModelState.IsValid && !string.IsNullOrEmpty(Nombre))
                {
                    try
                    {
                        // Crear una nueva instancia de Categoria con el nombre proporcionado
                        var nuevaCategoria = new Categoria
                        {
                            Nombre = Nombre
                        };
                        
                        _context.Categorias.Add(nuevaCategoria);
                        await _context.SaveChangesAsync();
                        TempData["SuccessMessage"] = "Categoría creada correctamente.";
                        return RedirectToAction(nameof(Index));
                    }
                    catch (Exception dbEx)
                    {
                        // Capturar errores específicos de la base de datos
                        System.Diagnostics.Debug.WriteLine($"Error de base de datos: {dbEx.Message}");
                        if (dbEx.InnerException != null)
                        {
                            System.Diagnostics.Debug.WriteLine($"Error interno: {dbEx.InnerException.Message}");
                        }
                        
                        TempData["ErrorMessage"] = $"Error de base de datos: {dbEx.Message}";
                        return RedirectToAction(nameof(Index));
                    }
                }
                
                // Si hay errores de validación y la solicitud viene de la vista Index
                if (Request.Headers["Referer"].ToString().Contains("/Categorias/Index"))
                {
                    var errors = string.Join(", ", ModelState.Values
                        .SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage));
                    
                    TempData["ErrorMessage"] = $"Error al crear la categoría: {errors}";
                    return RedirectToAction(nameof(Index));
                }
                
                // Crear un nuevo objeto Categoria para pasar a la vista
                var categoriaParaVista = new Categoria { Nombre = Nombre ?? string.Empty };
                return View(categoriaParaVista);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error general: {ex.Message}");
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Error interno general: {ex.InnerException.Message}");
                }
                
                TempData["ErrorMessage"] = $"Error al crear la categoría: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Categorias/Edit/5
        [RequirePermission("CATEGORY_EDIT")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }

        // POST: Categorias/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RequirePermission("CATEGORY_EDIT")]
        public async Task<IActionResult> Edit(int id, [Bind("IdCategoria,Nombre")] Categoria categoria)
        {
            if (id != categoria.IdCategoria)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoria);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Categoría actualizada correctamente.";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaExists(categoria.IdCategoria))
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
            return View(categoria);
        }

        // GET: Categorias/Delete/5
        [RequirePermission("CATEGORY_EDIT")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoria = await _context.Categorias
                .FirstOrDefaultAsync(m => m.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }

            return View(categoria);
        }

        // POST: Categorias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [RequirePermission("CATEGORY_EDIT")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var categoria = await _context.Categorias.FindAsync(id);
                if (categoria != null)
                {
                    _context.Categorias.Remove(categoria);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Categoría eliminada correctamente.";
                }
            }
            catch (DbUpdateException)
            {
                TempData["ErrorMessage"] = "No se puede eliminar esta categoría porque está siendo utilizada por productos.";
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.IdCategoria == id);
        }
    }
}
