using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.WebApi.Models
{
    public class RegisterModel
    {
        [Required]
        public required string FirstName { get; set; }
        [Required]
        public required string LastName { get; set; }
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
