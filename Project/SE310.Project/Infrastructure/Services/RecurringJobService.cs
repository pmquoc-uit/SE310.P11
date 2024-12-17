using Core.Interfaces;

namespace Infrastructure.Services
{
    public class RecurringJobService
    {
        private readonly IMailService _mailService;

        public RecurringJobService(IMailService mailService)
        {
            _mailService = mailService;
        }

        public async Task SendMarketingEmail()
        {
            await _mailService.SendMarketingEmailAsync();
        }
    }
}
