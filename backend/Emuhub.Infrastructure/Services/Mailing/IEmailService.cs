namespace Emuhub.Infrastructure.Services.Mailing;

public interface IEmailService
{
    public Task SendEmailAsync(string targetAddress, string subject, string body);
}

