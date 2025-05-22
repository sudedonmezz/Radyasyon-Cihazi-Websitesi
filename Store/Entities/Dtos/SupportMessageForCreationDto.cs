using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class SupportMessageForCreationDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Mesaj en az 10 karakter olmalıdır.")]
        public string? Message { get; set; }
    }
}
