using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityWebApi.Models
{
    public class ApplicationUser: IdentityUser
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string SecurityStamp { get; set; }
        
        [Required(ErrorMessage = "Username is required")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
