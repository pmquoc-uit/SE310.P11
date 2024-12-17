using Core.Interfaces;
using Core.Request;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Infrastructure.Services
{
    public class EmailPublisherService : IEmailPublisherService
    {
        private readonly RabbitMQSettings _rabbitMQSettings;
        public EmailPublisherService(IOptions<RabbitMQSettings> rabbitMQSettings)
        {
            _rabbitMQSettings = rabbitMQSettings.Value;
        }
        public void PublishToRabbitMQ(ForgotPWRequest request)
        {
            var factory = new ConnectionFactory { HostName = _rabbitMQSettings.HostName };
            //var factory = new ConnectionFactory
            //{
            //    HostName = _rabbitMQSettings.Host,
            //    UserName = _rabbitMQSettings.Username,
            //    Password = _rabbitMQSettings.Password,
            //    VirtualHost = _rabbitMQSettings.VirtualHost,
            //    Port = _rabbitMQSettings.Port
            //};
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "email_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(request));
            var properties = channel.CreateBasicProperties();
            properties.Persistent = true;
            channel.BasicPublish(
                exchange: "",
                routingKey: "email_queue",
                basicProperties: properties,
                body: body);
        }
    }
}
