namespace Core.Request
{
    public class ForgotPWRequest
    {
        public string ToEmail { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
