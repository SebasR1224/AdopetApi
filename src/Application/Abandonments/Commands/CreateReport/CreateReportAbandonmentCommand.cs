using Application.Common.Commands;
using Domain.Abandonments;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Commands.CreateReport;

public record CreateReportAbandonmentCommand(
    Guid ReporterId,
    string Title,
    string Description,
    List<string> Images,
    List<AnimalCommand> Animals,
    LocationCommand Location,
    DateTime AbandonmentDateTime,
    string AbandonmentStatus
) : IRequest<ErrorOr<ReportAbandonment>>;

public record AnimalCommand(
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