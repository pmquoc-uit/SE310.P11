using Core.Request;

namespace Core.Interfaces
{
    public interface IEmailPublisherService
    {
        void PublishToRabbitMQ(ForgotPWRequest request);
    }
}
