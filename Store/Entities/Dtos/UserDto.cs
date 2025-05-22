using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record UserDto
    {
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email zorunludur.")]
        public String? Email {get;init;}

        [DataType(DataType.PhoneNumber)]
        public String? PhoneNumber{get;init;}

        public HashSet<String> Roles{get;set;}=new HashSet<string>();
    }
}