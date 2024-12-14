using Application.Common;
using Application.Common.Interfaces.Models;
using Application.Common.Interfaces.Services.Email;
using Domain.Abandonments.Events;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.Abandonments.Events;

public class EmailVerificationReportEventHandler(IEmailService emailService, IOptions<ApplicationConfiguration> configuration) : INotificationHandler<EmailVerificationReportEvent>
{
    private readonly ApplicationConfiguration _configuration = configuration.Value;
    public async Task Handle(EmailVerificationReportEvent notification, CancellationToken cancellationToken)
    {
        var reportLink = $"{_configuration.FrontendUrl}/verify-report/{notification.ReportAbandonmentId.Value}";
        var emailBody = VerifyReportTemplateModel.GetVerificationReportTemplate(notification.Name, reportLink);
        await emailService.SendEmailAsync(notification.Email, "Verify Report", emailBody);
    }
}