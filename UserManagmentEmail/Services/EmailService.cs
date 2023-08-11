using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagmentEmail.Models;
using UserManagmentEmail.Services.Interfaces;

namespace UserManagmentEmail.Services
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfigration _emailConfigration;
        public EmailService(EmailConfigration emailConfigration)
        {
            _emailConfigration = emailConfigration;
        }

        void IEmailService.SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private async void Send(MimeMessage emailMessage)
        {
            var client = new SmtpClient();
            try
            {
                client.Connect(_emailConfigration.SmtpServer, _emailConfigration.Port, true);
                client.AuthenticationMechanisms.Remove("xoauth2");
                await client.AuthenticateAsync(_emailConfigration.UserName, _emailConfigration.Password);
                await client.SendAsync(emailMessage);
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
            
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _emailConfigration.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message.Content
            };

            return emailMessage;
        }

        
    }
}
