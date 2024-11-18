using Domain.Abandonments.Enums;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Commands.UpdateReportStatus;

public record UpdateReportStatusCommand(Guid ReportAbandonmentId, string Status) : IRequest<ErrorOr<Unit>>;