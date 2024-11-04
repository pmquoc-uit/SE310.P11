namespace JWTAuthentication.WebApi.Models
{
    public class RevokeTokenRequest
    {
        public required string Token { get; set; }
    }
}
