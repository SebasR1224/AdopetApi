namespace Contracts.Abandonment;

public record ReportAbandonmentResponse(
    Guid Id,
    string Title,
    string Description,
    List<string> Images,
    string Status,
    string AbandonmentStatus,
    string Address,
    DateTime AbandonmentDateTime,
    TimeSpan AbandonmentDuration,
    DateTime ReportDateTime,
    DateTime? RescueDateTime,
    TimeSpan? ResponseTime,
    Guid? FoundationId,
    List<AnimalResponse> Animals,
    ReporterResponse Reporter
);

public record ReporterResponse(
    Guid Id,
    string FullName,
    string Email,
    string PhoneNumber
);

public record AnimalResponse(
    Guid Id,
    string Name,
    string Description,
    List<string> Images,
    string Specie,
    string Age,
    string Gender,
    string Status
);
