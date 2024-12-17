using Core.Entities;
using Core.Interfaces;
using Core.Request;
using Infrastructure.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Infrastructure.Services
{
    public class MailService : IMailService
    {
        private readonly MailKitOptions _mailSetting;
        private readonly UserManager<AppUser> _userManager;
        public MailService(IOptions<MailKitOptions> mailSetting, UserManager<AppUser> userManager)
        {
            _mailSetting = mailSetting.Value;
            _userManager = userManager;
        }
        public async Task SendEmailAsync(ForgotPWRequest mailRequest)
        {
            String FilePath = Directory.GetCurrentDirectory() + "\\Templates\\MailTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            String MailText = str.ReadToEnd();
            str.Close();
            MailText = MailText.Replace
                ("[username]", mailRequest.ToEmail).Replace("[email]", mailRequest.Password);
            var mimeMessage = new MimeMessage();
            mimeMessage.Subject = $"PMQ Pharmacy - Password Recovery for {mailRequest.ToEmail}";
            mimeMessage.From.Add(new MailboxAddress(name: _mailSetting.DisplayName, _mailSetting.Mail));
            mimeMessage.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));

            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            mimeMessage.Body = builder.ToMessageBody();

            using var smtpClient = new SmtpClient();
            smtpClient.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
            smtpClient.Authenticate(_mailSetting.Mail, _mailSetting.Password);
            await smtpClient.SendAsync(mimeMessage);
            smtpClient.Disconnect(true);
        }
        public async Task SendMarketingEmailAsync()
        {
            // Đọc nội dung email từ file template
            string filePath = Path.Combine
                (Directory.GetCurrentDirectory(), "Templates", "Pharmacy Newsletter Template", "html", "index.html");
            using (StreamReader str = new StreamReader(filePath))
            {
                string mailText = str.ReadToEnd();

                var mimeMessage = new MimeMessage();
                mimeMessage.Subject = $"Newsletter Update from PMQ Pharmacy";
                mimeMessage.From.Add(new MailboxAddress(name: _mailSetting.DisplayName, _mailSetting.Mail));

                var builder = new BodyBuilder();
                builder.HtmlBody = mailText;
                mimeMessage.Body = builder.ToMessageBody();

                using var smtpClient = new SmtpClient();
                smtpClient.Connect(_mailSetting.Host, _mailSetting.Port, SecureSocketOptions.StartTls);
                smtpClient.Authenticate(_mailSetting.Mail, _mailSetting.Password);

                var users = _userManager.Users;
                foreach (var user in users)
                {
                    mimeMessage.To.Clear();
                    mimeMessage.To.Add(MailboxAddress.Parse(user.Email));
                    await smtpClient.SendAsync(mimeMessage);
                }

                smtpClient.Disconnect(true);
            }
        }
    }
}
