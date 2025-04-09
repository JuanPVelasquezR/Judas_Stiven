using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using SistemaInventario.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaInventario.Controllers
{
    [RequirePermission("USER_MANAGE")]
    public class RolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Roles
        public async Task<IActionResult> Index()
        {
            var roles = await _context.Roles
                .ToListAsync();
            return View(roles);
        }

        // GET: Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Roles
                .Include(r => r.RolesPermisos)
                .ThenInclude(rp => rp.Permiso)
                .FirstOrDefaultAsync(m => m.IdRol == id);
            
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: Roles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roles/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre")] Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rol);
        }

        // GET: Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Roles.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: Roles/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRol,Nombre")] Rol rol)
        {
            if (id != rol.IdRol)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.IdRol))
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
            return View(rol);
        }

        // GET: Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Roles
                .FirstOrDefaultAsync(m => m.IdRol == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rol = await _context.Roles.FindAsync(id);
            if (rol != null)
            {
                _context.Roles.Remove(rol);
                await _context.SaveChangesAsync();
            }
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Roles/ManagePermissions/5
        public async Task<IActionResult> ManagePermissions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rol = await _context.Roles
                .Include(r => r.RolesPermisos)
                .ThenInclude(rp => rp.Permiso)
                .FirstOrDefaultAsync(m => m.IdRol == id);

            if (rol == null)
            {
                return NotFound();
            }

            // Obtener todos los permisos
            var allPermisos = await _context.Permisos.ToListAsync();
            
            // Crear una lista de permisos asignados y no asignados
            var assignedPermisos = rol.RolesPermisos.Select(rp => rp.Permiso).ToList();
            var unassignedPermisos = allPermisos.Except(assignedPermisos).ToList();

            ViewData["AssignedPermisos"] = assignedPermisos;
            ViewData["UnassignedPermisos"] = unassignedPermisos;

            return View(rol);
        }

        // POST: Roles/AssignPermission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AssignPermission(int idRol, int idPermiso)
        {
            // Verificar si ya existe la asignación
            var existingAssignment = await _context.RolesPermisos
                .FirstOrDefaultAsync(rp => rp.IdRol == idRol && rp.IdPermiso == idPermiso);

            if (existingAssignment == null)
            {
                // Crear nueva asignación
                var rolPermiso = new RolPermiso
                {
                    IdRol = idRol,
                    IdPermiso = idPermiso
                };

                _context.Add(rolPermiso);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManagePermissions), new { id = idRol });
        }

        // POST: Roles/RemovePermission
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemovePermission(int idRol, int idPermiso)
        {
            var rolPermiso = await _context.RolesPermisos
                .FirstOrDefaultAsync(rp => rp.IdRol == idRol && rp.IdPermiso == idPermiso);

            if (rolPermiso != null)
            {
                _context.RolesPermisos.Remove(rolPermiso);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(ManagePermissions), new { id = idRol });
        }

        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.IdRol == id);
        }
    }
}
