using System.ComponentModel.DataAnnotations;

namespace MVCiti24.ViewModels
{
    public class RoleViewModel
    {
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
