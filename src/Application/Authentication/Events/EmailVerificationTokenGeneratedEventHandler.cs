using Application.Common.Interfaces.Services.Email;
using Domain.Users.Events;
using MediatR;

namespace Application.Authentication.Events;

public sealed class EmailVerificationTokenGeneratedEventHandler(IEmailService emailService) : INotificationHandler<EmailVerificationTokenGeneratedEvent>
{
    public async Task Handle(EmailVerificationTokenGeneratedEvent notification, CancellationToken cancellationToken)
    {
        await emailService.SendEmailAsync(notification.Email, "Email Verification", notification.Token);
    }
}
