using Application.Common.Interfaces.Password;
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
    IPasswordHasher passwordHasher) : IRequestHandler<RegisterCommand, ErrorOr<Unit>>
{
    public async Task<ErrorOr<Unit>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (await userRepository.GetByUsernameOrEmailAsync(command.Username) is not null)
            return Errors.User.DuplicateUsername;

        if (command.FoundationId != null)
        {
            var foundationId = FoundationId.Create(command.FoundationId.Value);
            if (await foundationRepository.GetByIdAsync(foundationId) is null)
                return Errors.User.FoundationNotFound;
        }

        var hashedPassword = passwordHasher.HashPassword(command.Password);

        var user = User.Create(
            command.Name,
            command.LastName,
            command.PersonalId,
            command.BirthDate,
            command.PhoneNumber,
            command.Address,
            command.Email,
            command.Username,
            hashedPassword,
            command.FoundationId.HasValue
                ? FoundationId.Create(command.FoundationId.Value)
                : null
        );

        await userRepository.AddAsync(user);

        return Unit.Value;
    }
}
