using System.ComponentModel.DataAnnotations;

namespace PlaDiC.WebPortal.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name = "Nombre completo")]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electrónico")]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="No coincide la confirmación de contraseña")]
        [Display(Name = "Confirme contraseña")]
        public string? ConfirmPassword { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Domicilio")]
        public string? Address { get; set; }
    }
}
