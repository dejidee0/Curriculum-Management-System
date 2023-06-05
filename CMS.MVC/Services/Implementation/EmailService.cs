using CMS.API.Configuration;
using MimeKit;
using MimeKit.Text;
using MailKit.Net.Smtp;
using MailKit.Security;
using CMS.MVC.Configuration;
using CMS.API.Models;
using CMS.MVC.Services.ServicesInterface;

namespace CMS.MVC.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _emailConfiguration;
        private readonly IConfiguration _configuration;

        public EmailService(EmailConfiguration emailConfiguration, IConfiguration configuration)
        {
            _emailConfiguration = emailConfiguration;
            _configuration = configuration;
        }

        public void SendInvite(EmailDto emailDto)
        {
            var message = new Message(emailDto.To, emailDto.Subject, emailDto.Content);
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfiguration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(TextFormat.Html) { Text = message.Content };
            return emailMessage;
        }

        public void Send(MimeMessage mailMessage)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfiguration.SmtpServer, _emailConfiguration.Port, SecureSocketOptions.StartTls);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_emailConfiguration.UserName, _emailConfiguration.Password);
                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }
    }
}
