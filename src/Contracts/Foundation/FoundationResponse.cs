namespace Contracts.Foundation;

public record FoundationResponse(
    string Id,
    string Name,
    string? Logo,
    string Description,
    string Nit,
    string Address,
    string Email,
    string Website,
    string PhoneNumber,
    string? Mission,
    string? Vision,
    float? AverageRating,
    string Status,
    List<LegalRepresentativeResponse> LegalRepresentatives
);

public record LegalRepresentativeResponse(
    string Id,
    string FullName,
    string PersonalId,
    string Email,
    string PhoneNumber,
    string Address
);