using Application.Common.Commands;
using Domain.Abandonments;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Commands.CreateReport;

public record CreateReportAbandonmentCommand(
    string Title,
    string Description,
    List<string> Images,
    ReporterCommand Reporter,
    List<AnimalCommand> Animals,
    LocationCommand Location,
    DateTime AbandonmentDateTime,
    string AbandonmentStatus
) : IRequest<ErrorOr<ReportAbandonment>>;

public record ReporterCommand(
    string Name,
    string LastName,
    string Email,
    string PhoneNumber,
    bool IsAnonymous
);

public record AnimalCommand(
    string Name,
    string? Image,
    string Description,
    int? Age,
    string CoatColor,
    string Specie,
    string? Breed,
    decimal? Weight,
    string Gender
);