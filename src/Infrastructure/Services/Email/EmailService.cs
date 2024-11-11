using Application.Common.Interfaces.Services.Email;

namespace Infrastructure.Services.Email;

public class EmailService : IEmailService
{
    public Task SendEmailAsync(string to, string subject, string body)
    {
        Console.WriteLine($"Sending email to {to} with subject {subject} and body {body}");
        return Task.CompletedTask;
    }
}
