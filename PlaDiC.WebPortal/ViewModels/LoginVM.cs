using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PlaDiC.WebPortal.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage ="Usuario es requerido")]
        [Display(Name ="Usuario")]
        public string? Username { get; set; }
        [Required(ErrorMessage = "Contraseña es requerida")]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Recordarme")]
        public bool RememberMe { get; set; }
    }
}
