using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class ContactMessageForCreationDto
    {
        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Eposta zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mesaj boş bırakılamaz.")]
        public string Message { get; set; } = string.Empty;
    }
}
