using Application.Common.Commands;
using Domain.Foundations;
using ErrorOr;
using MediatR;

namespace Application.Foundations.Commands.CreateFoundation;

public record CreateFoundationCommand(
    string Name,
    string? Logo,
    string Description,
    string Nit,
    LocationCommand Location,
    string Email,
    string Website,
    string PhoneNumber,
    string Mission,
    string Vision,
    List<LegalRepresentativeCommand> LegalRepresentatives
) : IRequest<ErrorOr<Foundation>>;


public record LegalRepresentativeCommand(
    string Name,
    string LastName,
    string PersonalId,
    string Email,
    string PhoneNumber,
    string Address
);
