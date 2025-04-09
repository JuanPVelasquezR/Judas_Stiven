using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Controllers
{
    public class SucursalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SucursalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sucursales
        public async Task<IActionResult> Index()
        {
            var sucursales = await _context.Sucursales.ToListAsync();
            return View(sucursales);
        }

        // GET: Sucursales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // GET: Sucursales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre,Direccion,Telefono,Encargado")] Sucursal sucursal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sucursal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sucursal);
        }

        // GET: Sucursales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);
        }

        // POST: Sucursales/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSucursal,Nombre,Direccion,Telefono,Encargado")] Sucursal sucursal)
        {
            if (id != sucursal.IdSucursal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SucursalExists(sucursal.IdSucursal))
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
            return View(sucursal);
        }

        // GET: Sucursales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sucursal = await _context.Sucursales
                .FirstOrDefaultAsync(m => m.IdSucursal == id);
            if (sucursal == null)
            {
                return NotFound();
            }

            return View(sucursal);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal != null)
            {
                _context.Sucursales.Remove(sucursal);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool SucursalExists(int id)
        {
            return _context.Sucursales.Any(e => e.IdSucursal == id);
        }
    }
}
