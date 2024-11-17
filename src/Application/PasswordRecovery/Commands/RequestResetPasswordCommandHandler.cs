using Application.Common;
using Application.Common.Interfaces.Models;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services.Email;
using Domain.Common.Errors;
using Domain.PasswordRecovery;
using Domain.Users;
using ErrorOr;
using MediatR;
using Microsoft.Extensions.Options;

namespace Application.PasswordRecovery.Commands;

public class RequestResetPasswordCommandHandler(
    IUserRepository userRepository,
    IPasswordRecoveryTokenRepository passwordRecoveryTokenRepository,
    IEmailService emailService,
    IOptions<ApplicationConfiguration> configuration) : IRequestHandler<RequestResetPasswordCommand, ErrorOr<Unit>>
{
    private readonly ApplicationConfiguration _configuration = configuration.Value;
    public async Task<ErrorOr<Unit>> Handle(RequestResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByUsernameOrEmailAsync(request.Username);

        if (user is null) return Errors.User.NotFound;

        var passwordRecoveryToken = PasswordRecoveryToken.Create(user.Email);

        await passwordRecoveryTokenRepository.AddAsync(passwordRecoveryToken);

        await SendPasswordRecoveryEmail(passwordRecoveryToken, user);

        return Unit.Value;
    }

    private async Task SendPasswordRecoveryEmail(PasswordRecoveryToken passwordRecoveryToken, User user)
    {
        var recoveryLink = $"{_configuration.FrontendUrl}/reset-password?token={passwordRecoveryToken.Token}";
        await emailService.SendEmailAsync(
            passwordRecoveryToken.Email,
            "Password Recovery",
            PasswordRecoveryTemplateModel.GetPasswordRecoveryTemplate(recoveryLink, user.Username)
        );
    }
}