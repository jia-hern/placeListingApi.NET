using System.ComponentModel.DataAnnotations;

namespace PlaceListing.API.Core.Models.Users
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password has to be between {2} to {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
