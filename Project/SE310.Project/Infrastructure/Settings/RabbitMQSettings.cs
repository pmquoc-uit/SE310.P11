namespace Infrastructure.Settings
{
    public class RabbitMQSettings
    {
        public String HostName { get; set; } = String.Empty;
        public String Host { get; set; } = String.Empty;
        public String Username { get; set; } = String.Empty;
        public String Password { get; set; } = String.Empty;
        public String VirtualHost { get; set; } = String.Empty;
        public int Port { get; set; }
    }
}
