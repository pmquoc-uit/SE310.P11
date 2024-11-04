using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication.WebApi.Models
{
    public class AddRoleModel
    {
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
        [Required]
        public required string Role { get; set; }
    }
}
