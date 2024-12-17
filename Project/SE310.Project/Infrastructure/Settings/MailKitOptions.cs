namespace Infrastructure.Settings
{
    public class MailKitOptions
    {
        public Boolean AuthenticationRequired { get; set; }
        public String? DkimPrivateKey { get; set; }
        public String? DkimSelector { get; set; }
        public String? DomainName { get; set; }
        public required String Host { get; set; }
        public required int Port { get; set; }
        public required String Mail { get; set; }
        public String DisplayName { get; set; } = String.Empty;
        public String UserName { get; set; } = String.Empty;
        public required String Password { get; set; }
    }
}
