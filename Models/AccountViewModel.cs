
using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{

    public class Account
    {
        [Required(ErrorMessage = "Username is required")]
        [MinLength(5)]
        [MaxLength(15)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [MinLength(8)]
        [MaxLength(15)]
        public string Password { get; set; }

        [Range(18, 60, ErrorMessage = "Age must be between 18 and 60")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Url(ErrorMessage = "Invalid URL")]
        public string Website { get; set; }
    }
}