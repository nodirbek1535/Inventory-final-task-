//======================================
//Nodirbek Nasrullayev Inventory Project
//======================================

using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Inventory_final_task_.Brokers.Emails
{
    public class EmailBroker : IEmailBroker
    {
        private readonly IConfiguration configuration;

        public EmailBroker(IConfiguration configuration) =>
            this.configuration = configuration;

        public async ValueTask SendEmailAsync(string receiverAddress, string subject, string body)
        {
            var emailSettings = configuration.GetSection("EmailSettings");

            string fromAddress = emailSettings["From"] ?? 
                throw new InvalidOperationException("Email 'From' is not configured.");

            string appPassword = emailSettings["AppPassword"] ?? 
                throw new InvalidOperationException("Email 'AppPassword' is not configured.");

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("InvenTrack System", fromAddress));
            message.To.Add(new MailboxAddress("", receiverAddress));
            message.Subject = subject;
            message.Body = new TextPart("html") { Text = body };

            using var client = new SmtpClient();

            await client.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(fromAddress, appPassword);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
