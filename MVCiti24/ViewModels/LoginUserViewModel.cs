using System.ComponentModel.DataAnnotations;

namespace MVCiti24.ViewModels
{
    public class LoginUserViewModel
    {
        [Required(ErrorMessage ="*")]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name ="Remember Me !!!")]
        public bool RememberMe { get; set; }
    }
}
