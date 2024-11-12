using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Password;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Queries.Login;

internal sealed class LoginQueryHandler(
    IUserRepository userRepository,
    IJwtTokenGenerator jwtTokenGenerator,
    IPasswordHasher passwordHasher) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery command, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByUsernameAsync(command.Username) is not User user)
            return Errors.Authentication.InvalidCredentials;

        if (!passwordHasher.VerifyPassword(command.Password, user.Password))
            return Errors.Authentication.InvalidCredentials;

        if (!user.IsEmailVerified) return Errors.Authentication.EmailNotVerified;

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
