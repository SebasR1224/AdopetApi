using Contracts.Common;

namespace Contracts.Foundation;

public record CreateFoundationRequest(
    string Name,
    string LegalName,
    string? Logo,
    string Description,
    string Nit,
    LocationRequest Location,
    string Email,
    string Website,
    string PhoneNumber,
    string? Mission,
    string? Vission,
    List<LegalRepresentativeRequest> LegalRepresentatives
);

public record LegalRepresentativeRequest(
    string Name,
    string LastName,
    string PersonalId,
    string Email,
    string PhoneNumber,
    string Address
);
