using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using SistemaInventario.Models.ViewModels;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

namespace SistemaInventario.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            ViewData["ShowNavbar"] = false;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string usuario, string contraseña)
        {
            ViewData["ShowNavbar"] = false;
            
            try
            {
                // Verificar si el usuario existe
                var user = _context.Usuarios
                    .Include(u => u.Rol)
                    .ThenInclude(r => r.RolesPermisos)
                    .ThenInclude(rp => rp.Permiso)
                    .FirstOrDefault(u => u.NombreUsuario == usuario && u.Contraseña == contraseña);
                
                if (user != null)
                {
                    // Almacenar información del usuario en la sesión
                    HttpContext.Session.SetInt32("UserId", user.IdUsuario);
                    HttpContext.Session.SetString("UserName", user.Nombre);
                    HttpContext.Session.SetString("UserRole", user.Rol.Nombre);
                    
                    // Guardar los permisos del usuario en la sesión
                    var permisos = user.Rol.RolesPermisos.Select(rp => rp.Permiso.Codigo).ToList();
                    HttpContext.Session.SetString("UserPermissions", JsonSerializer.Serialize(permisos));
                    
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error en Login: {ex.Message}");
            }
            
            ViewData["Error"] = "Usuario o contraseña incorrectos";
            ViewData["ShowNavbar"] = false;
            return View();
        }

        public IActionResult Logout()
        {
            // Limpiar la sesión
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
        
        // GET: Account/ForgotPassword
        public IActionResult ForgotPassword()
        {
            ViewData["ShowNavbar"] = false;
            return View();
        }
        
        // POST: Account/ForgotPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            ViewData["ShowNavbar"] = false;
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                // Verificar si se proporcionó un nombre de usuario
                if (string.IsNullOrEmpty(model.NombreUsuario))
                {
                    ModelState.AddModelError("NombreUsuario", "Por favor, ingresa tu nombre de usuario.");
                    return View(model);
                }
                
                // Registrar todos los usuarios en la base de datos para depuración
                var todosLosUsuarios = _context.Usuarios.ToList();
                System.Diagnostics.Debug.WriteLine($"Total de usuarios en la base de datos: {todosLosUsuarios.Count}");
                foreach (var u in todosLosUsuarios)
                {
                    System.Diagnostics.Debug.WriteLine($"Usuario en BD: {u.NombreUsuario}");
                }
                
                // Buscar usuario por NombreUsuario directamente
                var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario);
                System.Diagnostics.Debug.WriteLine($"Buscando usuario: {model.NombreUsuario}, Encontrado: {usuario != null}");
                
                if (usuario == null)
                {
                    // Para propósitos de depuración, mostrar un mensaje más informativo
                    ViewData["Message"] = $"No se encontró el usuario '{model.NombreUsuario}'. Si crees que esto es un error, contacta al administrador.";
                    
                    // Registrar el intento fallido para fines de auditoría
                    System.Diagnostics.Debug.WriteLine($"Intento de recuperación de contraseña para usuario inexistente: {model.NombreUsuario}");
                    
                    return View();
                }
                
                // Para compatibilidad con el código existente, asignamos el nombre de usuario al email
                // Esto es necesario porque el flujo de recuperación de contraseña espera un email
                model.Email = model.NombreUsuario + "@example.com";
                
                // Generar token simple (en un sistema real usaríamos algo más seguro)
                string token = GenerateResetToken();
                
                // En un sistema real, enviaríamos un correo con el enlace
                // Aquí solo guardamos el token en TempData para simplificar
                TempData["ResetToken"] = token;
                TempData["ResetEmail"] = model.Email; // Valor ficticio para compatibilidad
                TempData["ResetUserName"] = usuario.NombreUsuario;
                
                // Guardar estos valores en la sesión para asegurar que estén disponibles
                HttpContext.Session.SetString("ResetToken", token);
                HttpContext.Session.SetString("ResetEmail", model.Email);
                HttpContext.Session.SetString("ResetUserName", usuario.NombreUsuario);
                
                // Registrar el token generado para el usuario (en un sistema real, lo guardaríamos en la base de datos)
                System.Diagnostics.Debug.WriteLine($"Token generado para {usuario.NombreUsuario}: {token}");
                
                ViewData["Message"] = "Se han enviado instrucciones a tu correo electrónico.";
                ViewData["ShowResetLink"] = true; // Para mostrar un enlace directo en la demo
                
                return View();
            }
            catch (Exception ex)
            {
                // Registrar el error detalladamente
                System.Diagnostics.Debug.WriteLine($"Error en ForgotPassword: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                
                // Mostrar un mensaje de error genérico al usuario
                ModelState.AddModelError("", "Ocurrió un error al procesar tu solicitud. Inténtalo de nuevo más tarde.");
                return View(model);
            }
        }
        
        // GET: Account/ResetPassword
        public IActionResult ResetPassword(string token, string email)
        {
            ViewData["ShowNavbar"] = false;
            
            try
            {
                // Intentar recuperar los valores de la sesión si TempData no los tiene
                string storedToken = TempData["ResetToken"]?.ToString();
                string storedEmail = TempData["ResetEmail"]?.ToString();
                string storedUsername = TempData["ResetUserName"]?.ToString();
                
                // Si no están en TempData, intentar recuperarlos de la sesión
                if (string.IsNullOrEmpty(storedToken))
                {
                    storedToken = HttpContext.Session.GetString("ResetToken");
                    TempData["ResetToken"] = storedToken; // Restaurar en TempData
                }
                
                if (string.IsNullOrEmpty(storedEmail))
                {
                    storedEmail = HttpContext.Session.GetString("ResetEmail");
                    TempData["ResetEmail"] = storedEmail; // Restaurar en TempData
                }
                
                if (string.IsNullOrEmpty(storedUsername))
                {
                    storedUsername = HttpContext.Session.GetString("ResetUserName");
                    TempData["ResetUserName"] = storedUsername; // Restaurar en TempData
                }
                
                // Verificar que el token y email coincidan con los almacenados
                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(storedToken) || string.IsNullOrEmpty(storedEmail))
                {
                    // Registrar el intento fallido
                    System.Diagnostics.Debug.WriteLine($"Intento de restablecer contraseña con token o email inválido. Token: {token}, Email: {email}");
                    System.Diagnostics.Debug.WriteLine($"Valores almacenados - Token: {storedToken}, Email: {storedEmail}, Username: {storedUsername}");
                    
                    TempData["ErrorMessage"] = "El enlace para restablecer la contraseña no es válido o ha expirado.";
                    return RedirectToAction("Login");
                }
                
                if (token != storedToken || email != storedEmail)
                {
                    // Registrar el intento fallido con detalles
                    System.Diagnostics.Debug.WriteLine($"Token o email no coinciden con los almacenados. Token recibido: {token}, Token almacenado: {storedToken}, Email recibido: {email}, Email almacenado: {storedEmail}");
                    
                    TempData["ErrorMessage"] = "El enlace para restablecer la contraseña no es válido o ha expirado.";
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                // Registrar el error
                System.Diagnostics.Debug.WriteLine($"Error en GET ResetPassword: {ex.Message}");
                TempData["ErrorMessage"] = "Ha ocurrido un error al procesar tu solicitud. Inténtalo de nuevo más tarde.";
                return RedirectToAction("Login");
            }
            
            // Guardar los valores en TempData para el POST
            TempData["ResetToken"] = token;
            TempData["ResetEmail"] = email;
            TempData["ResetUserName"] = TempData["ResetUserName"];
            
            var model = new ResetPasswordViewModel
            {
                Token = token,
                NombreUsuario = TempData["ResetUserName"]?.ToString()
            };
            
            return View(model);
        }
        
        // POST: Account/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ResetPassword(ResetPasswordViewModel model)
        {
            ViewData["ShowNavbar"] = false;
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            try
            {
                // Verificar que el token sea válido
                string storedToken = TempData["ResetToken"]?.ToString();
                string storedUsername = TempData["ResetUserName"]?.ToString();
                
                // Registrar la información para depuración
                System.Diagnostics.Debug.WriteLine($"Intento de restablecer contraseña - Token recibido: {model.Token}, Token almacenado: {storedToken}, Usuario recibido: {model.NombreUsuario}, Usuario almacenado: {storedUsername}");
                
                if (string.IsNullOrEmpty(storedToken) || 
                    model.Token != storedToken || 
                    string.IsNullOrEmpty(storedUsername) || 
                    model.NombreUsuario != storedUsername)
                {
                    ModelState.AddModelError("", "Token inválido o expirado. Por favor, solicita un nuevo enlace para restablecer tu contraseña.");
                    return View(model);
                }
                
                // Buscar el usuario
                var usuario = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario);
                if (usuario == null)
                {
                    // No revelar información específica por seguridad
                    ModelState.AddModelError("", "Ha ocurrido un error. Por favor, intenta nuevamente.");
                    System.Diagnostics.Debug.WriteLine($"Intento de restablecer contraseña para usuario inexistente: {model.NombreUsuario}");
                    return View(model);
                }
                
                // Validar la nueva contraseña (además de las validaciones del modelo)
                if (model.NuevaContraseña == usuario.NombreUsuario)
                {
                    ModelState.AddModelError("NuevaContraseña", "La contraseña no puede ser igual a tu nombre de usuario.");
                    return View(model);
                }
                
                // Actualizar la contraseña
                usuario.Contraseña = model.NuevaContraseña; // En un sistema real, hashearíamos la contraseña
                _context.Update(usuario);
                _context.SaveChanges();
                
                // Registrar el cambio exitoso
                System.Diagnostics.Debug.WriteLine($"Contraseña actualizada exitosamente para el usuario: {usuario.NombreUsuario}");
                
                // Limpiar TempData
                TempData.Remove("ResetToken");
                TempData.Remove("ResetEmail");
                TempData.Remove("ResetUserName");
                
                TempData["SuccessMessage"] = "Tu contraseña ha sido restablecida correctamente. Ya puedes iniciar sesión.";
                return RedirectToAction("Login");
            }
            catch (Exception ex)
            {
                // Registrar el error detalladamente
                System.Diagnostics.Debug.WriteLine($"Error al restablecer la contraseña: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
                
                if (ex.InnerException != null)
                {
                    System.Diagnostics.Debug.WriteLine($"InnerException: {ex.InnerException.Message}");
                }
                
                // Mostrar un mensaje de error genérico al usuario
                ModelState.AddModelError("", "Ocurrió un error al restablecer la contraseña. Inténtalo de nuevo más tarde.");
                return View(model);
            }
        }
        
        // Método para verificar si el usuario tiene un permiso específico
        public static bool HasPermission(HttpContext httpContext, string permissionCode)
        {
            var permissionsJson = httpContext.Session.GetString("UserPermissions");
            if (string.IsNullOrEmpty(permissionsJson))
                return false;
                
            var permissions = JsonSerializer.Deserialize<List<string>>(permissionsJson);
            return permissions != null && permissions.Contains(permissionCode);
        }
        
        // Método para generar un token simple para restablecer la contraseña
        private string GenerateResetToken()
        {
            // Generar un token aleatorio simple (en un sistema real usaríamos algo más seguro)
            byte[] tokenBytes = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(tokenBytes);
            }
            return Convert.ToBase64String(tokenBytes);
        }
    }
}
