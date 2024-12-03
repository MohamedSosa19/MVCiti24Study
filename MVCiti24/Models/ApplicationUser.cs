using Microsoft.AspNetCore.Identity;

namespace MVCiti24.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Address { get; set; }
    }
}
