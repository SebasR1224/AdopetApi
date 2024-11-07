using Contracts.Common;

namespace Contracts.Abandonment;

public record CreateReportAbandonmentRequest(
    Guid ReporterId,
    string Title,
    string Description,
    List<string> Images,
    List<AnimalRequest> Animals,
    LocationRequest Location,
    DateTime AbandonmentDateTime,
    string AbandonmentStatus
);

public record AnimalRequest(
    string Name,
    string? Image,
    string Description,
    int? Age,
    string CoatColor,
    string Specie,
    string? Breed,
    double? Weight,
    string Gender
);
