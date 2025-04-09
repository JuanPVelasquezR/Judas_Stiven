using System.ComponentModel.DataAnnotations;

namespace SistemaInventario.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        [Display(Name = "Nombre de Usuario")]
        public string NombreUsuario { get; set; }
        
        [Required(ErrorMessage = "La nueva contraseña es obligatoria")]
        [StringLength(100, ErrorMessage = "La {0} debe tener al menos {2} caracteres de longitud.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña")]
        public string NuevaContraseña { get; set; }
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("NuevaContraseña", ErrorMessage = "La nueva contraseña y la confirmación no coinciden.")]
        public string ConfirmarContraseña { get; set; }
        
        public string Token { get; set; }
    }
}
