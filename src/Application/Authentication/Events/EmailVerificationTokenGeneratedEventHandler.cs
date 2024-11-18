using Application.Common;
using Application.Common.Interfaces.Services.Email;
using Domain.Users.Events;
using MediatR;
using Microsoft.Extensions.Options;
using Application.Common.Interfaces.Models;

namespace Application.Authentication.Events;

public sealed class EmailVerificationTokenGeneratedEventHandler(IEmailService emailService, IOptions<ApplicationConfiguration> configuration) : INotificationHandler<EmailVerificationTokenGeneratedEvent>
{
    private readonly ApplicationConfiguration _configuration = configuration.Value;
    public async Task Handle(EmailVerificationTokenGeneratedEvent notification, CancellationToken cancellationToken)
    {
        var emailBody = VerifyEmailTemplateModel.GetVerificationEmailTemplate(notification.Username, $"{_configuration.FrontendUrl}/verify-email?token={notification.Token}&userId={notification.UserId.Value}");
        await emailService.SendEmailAsync(notification.Email, "Verify Email", emailBody);
    }
}
