using Domain.Abandonments;
using Domain.Abandonments.Enums;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Queries.GetReportsByFoundationId;

public record GetReportsAbandonmentByFoundationIdQuery(
    Guid FoundationId,
    ReportStatus? Status,
    DateTime? StartDate,
    DateTime? EndDate,
    AbandonmentStatus? AbandonmentStatus,
    Guid? ReporterId) : IRequest<ErrorOr<List<ReportAbandonment>>>;