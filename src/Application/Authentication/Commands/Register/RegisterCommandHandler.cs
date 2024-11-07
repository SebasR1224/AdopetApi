using Application.Authentication.Common;
using Application.Common.Interfaces.Authentication;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Foundations.ValueObjects;
using Domain.Users;
using ErrorOr;
using MediatR;

namespace Application.Authentication.Commands.Register;

internal sealed class RegisterCommandHandler(
    IUserRepository userRepository,
    IFoundationRepository foundationRepository,
    IJwtTokenGenerator jwtTokenGenerator) : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByUsernameAsync(command.Username) is not null)
            return Errors.User.DuplicateUsername;

        if (command.FoundationId != null)
        {
            var foundationId = FoundationId.Create(command.FoundationId.Value);
            if (await foundationRepository.GetByIdAsync(foundationId) is null)
                return Errors.User.FoundationNotFound;
        }

        var user = User.Create(
            command.Name,
            command.LastName,
            command.PersonalId,
            command.BirthDate,
            command.PhoneNumber,
            command.Address,
            command.Email,
            command.Username,
            command.Password,
            command.FoundationId.HasValue
                ? FoundationId.Create(command.FoundationId.Value)
                : null
        );

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(user, token);
    }
}
