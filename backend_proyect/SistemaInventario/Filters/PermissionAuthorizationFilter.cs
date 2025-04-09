using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;
using SistemaInventario.Controllers;
using System.Text.Json;

namespace SistemaInventario.Filters
{
    public class PermissionAuthorizationFilter : IActionFilter
    {
        private readonly string _permissionCode;

        public PermissionAuthorizationFilter(string permissionCode)
        {
            _permissionCode = permissionCode;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Verificar si hay un usuario autenticado
            var userId = context.HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                // Si no hay usuario autenticado, redirigir al login
                context.Result = new RedirectToActionResult("Login", "Account", null);
                return;
            }

            // Verificar si el usuario tiene el permiso requerido
            var permissionsJson = context.HttpContext.Session.GetString("UserPermissions");
            if (string.IsNullOrEmpty(permissionsJson))
            {
                // Si no hay permisos, redirigir a la página de acceso denegado
                context.Result = new ViewResult { ViewName = "AccessDenied" };
                return;
            }

            var permissions = JsonSerializer.Deserialize<List<string>>(permissionsJson);
            if (permissions == null || !permissions.Contains(_permissionCode))
            {
                // Si no tiene el permiso, mostrar página de acceso denegado
                context.Result = new ViewResult { ViewName = "AccessDenied" };
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // No es necesario hacer nada después de la ejecución de la acción
        }
    }

    // Atributo personalizado para aplicar el filtro de autorización
    public class RequirePermissionAttribute : TypeFilterAttribute
    {
        public RequirePermissionAttribute(string permissionCode) : base(typeof(PermissionAuthorizationFilter))
        {
            Arguments = new object[] { permissionCode };
        }
    }
}
