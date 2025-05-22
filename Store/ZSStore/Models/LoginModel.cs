using System.ComponentModel.DataAnnotations;

namespace ZSStore.Models
{
    public class LoginModel
    {

        private string? _returnurl;

        [Required(ErrorMessage="E-posta zorunludur.")]
        public string? Email {get;set;}

        [Required(ErrorMessage="Şifre zorunludur.")]
        public string? Password{get;set;}

        public string Returnurl{
                get
                {
                    if(_returnurl is null)
                    return "/";
                    else
                    return _returnurl;
                }

                set
                {
                    _returnurl=value;
                }
        }
    }
}