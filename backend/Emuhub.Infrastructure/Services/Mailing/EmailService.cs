using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace Emuhub.Infrastructure.Services.Mailing;

public class EmailService(IConfiguration configuration) : IEmailService
{
    public async Task SendEmailAsync(string targetAddress, string subject, string body)
    { 
        var server = configuration.GetValue<string>("Mailing:Smtp:Server");
        var port = configuration.GetValue<int>("Mailing:Smtp:Port");
        var sender = configuration.GetValue<string>("Mailing:Sender");
        var key = configuration.GetValue<string>("Mailing:Key");
            
        var email = new MimeMessage();
        email.From.Add(MailboxAddress.Parse(sender));
        email.To.Add(MailboxAddress.Parse(targetAddress));
        email.Subject = subject;
        email.Body = new TextPart("plain") { Text = body };

        using var smtp = new SmtpClient();
        await smtp.ConnectAsync(server, port, SecureSocketOptions.StartTls);
        await smtp.AuthenticateAsync(sender, key);
        await smtp.SendAsync(email);
        await smtp.DisconnectAsync(true);
    }
}