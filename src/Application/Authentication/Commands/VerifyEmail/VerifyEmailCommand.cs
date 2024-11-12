using Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.VerifyEmail;

public record VerifyEmailCommand(Guid UserId, string Token) : IRequest<ErrorOr<AuthenticationResult>>;
