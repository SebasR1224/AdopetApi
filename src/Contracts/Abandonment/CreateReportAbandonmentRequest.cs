using Contracts.Common;

namespace Contracts.Abandonment;

public record CreateReportAbandonmentRequest(
    string Title,
    string Description,
    List<string> Images,
    ReporterRequest Reporter,
    List<AnimalRequest> Animals,
    LocationRequest Location,
    DateTime AbandonmentDateTime,
    string AbandonmentStatus
);

public record ReporterRequest(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    bool IsAnonymous
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
