using Core.Request;

namespace Core.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(ForgotPWRequest mailRequest);
        Task SendMarketingEmailAsync();

    }
}
