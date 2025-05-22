using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto //veri üzerinde değişiklik yapılmayacağı için dto tercih ettim.
    {
        [Required(ErrorMessage ="Email alanı zorunludur.")]
        public String? Email {get;init;}

        [Required(ErrorMessage ="Şifre alanı zorunludur.")]
        public String? Password {get;init;}
    }
}