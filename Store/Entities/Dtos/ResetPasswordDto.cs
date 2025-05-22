using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ResetPasswordDto
    {
        [DataType(DataType.EmailAddress)]
        public String? Email{get;init;}
        [Required(ErrorMessage ="Şifre zorunludur.")]

        [DataType(DataType.Password)]
        public String? Password {get;init;}

        [DataType(DataType.Password)]

        [Required(ErrorMessage ="Şifreyi onaylayın.")]
        [Compare("Password",ErrorMessage="Şifre eşleştirilemedi.")]
        public String? ConfirmPassword{get;init;}
    }
}