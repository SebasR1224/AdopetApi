using Domain.Abandonments;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Queries.GetReportsByFoundationId;

public record GetReportsAbandonmentByFoundationIdQuery(Guid FoundationId) : IRequest<ErrorOr<IReadOnlyList<ReportAbandonment>>>;