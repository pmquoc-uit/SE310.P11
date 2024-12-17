using Core.Interfaces;
using Core.Request;
using Infrastructure.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Infrastructure.Services
{
    public class EmailConsumerService : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<EmailConsumerService> _log;
        private readonly RabbitMQSettings _rabbitMQSettings;
        public EmailConsumerService
            (IServiceProvider serviceProvider, ILogger<EmailConsumerService> log, IOptions<RabbitMQSettings> rabbitMQSettings)
        {
            _serviceProvider = serviceProvider;
            _log = log;
            _rabbitMQSettings = rabbitMQSettings.Value;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(
                queue: "email_queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                try
                {
                    var request = JsonConvert.DeserializeObject<ForgotPWRequest>(message);
                    if (request != null)
                    {
                        // Tạo scope mới và lấy IMailService
                        using (var scope = _serviceProvider.CreateScope())
                        {
                            var mailService = scope.ServiceProvider.GetRequiredService<IMailService>();
                            await mailService.SendEmailAsync(request);
                        }
                    }
                }
                catch (Exception ex)
                {
                    _log.LogError($"Error when sending email with RabbitMQ: {ex}");
                }
                finally
                {
                    channel.BasicAck(ea.DeliveryTag, false);
                }
            };

            channel.BasicConsume(queue: "email_queue", autoAck: false, consumer: consumer);
            await Task.CompletedTask;
        }
    }
}
