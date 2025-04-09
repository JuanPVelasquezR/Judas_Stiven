using Microsoft.EntityFrameworkCore;
using SistemaInventario.Models;
using SistemaInventario.Models.Entities;
using System.Linq;

namespace SistemaInventario.Data
{
    public static class PermisosInicializador
    {
        public static void InicializarPermisos(ApplicationDbContext context)
        {
            // Asegurarse de que la base de datos esté creada
            context.Database.EnsureCreated();

            // Verificar si ya existen permisos
            if (context.Permisos.Any())
            {
                return; // La base de datos ya ha sido inicializada
            }

            // Crear permisos básicos
            var permisos = new[]
            {
                new Permiso { Nombre = "Ver Productos", Codigo = "PRODUCT_VIEW" },
                new Permiso { Nombre = "Editar Productos", Codigo = "INVENTORY_EDIT" },
                new Permiso { Nombre = "Ver Categorías", Codigo = "CATEGORY_VIEW" },
                new Permiso { Nombre = "Editar Categorías", Codigo = "CATEGORY_EDIT" }
            };

            context.Permisos.AddRange(permisos);
            context.SaveChanges();

            // Crear rol de administrador si no existe
            var rolAdmin = context.Roles.FirstOrDefault(r => r.Nombre == "Administrador");
            if (rolAdmin == null)
            {
                rolAdmin = new Rol { Nombre = "Administrador" };
                context.Roles.Add(rolAdmin);
                context.SaveChanges();
            }

            // Asignar todos los permisos al rol de administrador
            foreach (var permiso in permisos)
            {
                if (!context.RolesPermisos.Any(rp => rp.IdRol == rolAdmin.IdRol && rp.IdPermiso == permiso.IdPermiso))
                {
                    context.RolesPermisos.Add(new RolPermiso
                    {
                        IdRol = rolAdmin.IdRol,
                        IdPermiso = permiso.IdPermiso
                    });
                }
            }
            context.SaveChanges();
        }

        public static void ActualizarPermisosAdministrador(ApplicationDbContext context)
        {
            // Buscar el rol de administrador
            var rolAdmin = context.Roles.FirstOrDefault(r => r.Nombre == "Administrador");
            if (rolAdmin == null)
            {
                return; // No existe el rol de administrador
            }

            // Buscar el permiso CATEGORY_VIEW
            var permisoCategoryView = context.Permisos.FirstOrDefault(p => p.Codigo == "CATEGORY_VIEW");
            if (permisoCategoryView == null)
            {
                // Crear el permiso si no existe
                permisoCategoryView = new Permiso
                {
                    Nombre = "Ver Categorías",
                    Codigo = "CATEGORY_VIEW"
                };
                context.Permisos.Add(permisoCategoryView);
                context.SaveChanges();
            }

            // Buscar el permiso CATEGORY_EDIT
            var permisoCategoryEdit = context.Permisos.FirstOrDefault(p => p.Codigo == "CATEGORY_EDIT");
            if (permisoCategoryEdit == null)
            {
                // Crear el permiso si no existe
                permisoCategoryEdit = new Permiso
                {
                    Nombre = "Editar Categorías",
                    Codigo = "CATEGORY_EDIT"
                };
                context.Permisos.Add(permisoCategoryEdit);
                context.SaveChanges();
            }

            // Asignar los permisos al rol de administrador si no los tiene
            if (!context.RolesPermisos.Any(rp => rp.IdRol == rolAdmin.IdRol && rp.IdPermiso == permisoCategoryView.IdPermiso))
            {
                context.RolesPermisos.Add(new RolPermiso
                {
                    IdRol = rolAdmin.IdRol,
                    IdPermiso = permisoCategoryView.IdPermiso
                });
            }

            if (!context.RolesPermisos.Any(rp => rp.IdRol == rolAdmin.IdRol && rp.IdPermiso == permisoCategoryEdit.IdPermiso))
            {
                context.RolesPermisos.Add(new RolPermiso
                {
                    IdRol = rolAdmin.IdRol,
                    IdPermiso = permisoCategoryEdit.IdPermiso
                });
            }

            context.SaveChanges();
        }
    }
}
