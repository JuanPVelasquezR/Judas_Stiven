using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SistemaInventario.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Obtener estadísticas para mostrar en el dashboard
        ViewBag.TotalProductos = await _context.Productos.CountAsync();
        ViewBag.TotalCategorias = await _context.Categorias.CountAsync();
        ViewBag.TotalProveedores = await _context.Proveedores.CountAsync();
        ViewBag.TotalClientes = await _context.Clientes.CountAsync();
        
        // Obtener los últimos movimientos para mostrar en la línea de tiempo
        ViewBag.UltimosMovimientos = await _context.MovimientosInventario
            .OrderByDescending(m => m.Fecha)
            .Take(5)
            .Include(m => m.TipoMovimiento)
            .ToListAsync();
        
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
