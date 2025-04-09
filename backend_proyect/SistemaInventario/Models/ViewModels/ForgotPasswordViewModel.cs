using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        
        // Mantenemos Email para compatibilidad con el código existente
        // pero no lo usaremos directamente
        public string Email { get; set; }
    }
}
