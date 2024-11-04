using System.Text.Json.Serialization;

namespace JWTAuthentication.WebApi.Models
{
    public class AuthenticationModel
    {
        public string Message { get; set; } = null!;
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string> Roles { get; set; } = [];
        public string Token { get; set; } = null!;
        [JsonIgnore]
        public string RefreshToken { get; set; } = null!;
        public DateTime RefreshTokenExpiration { get; set; }
    }
}
