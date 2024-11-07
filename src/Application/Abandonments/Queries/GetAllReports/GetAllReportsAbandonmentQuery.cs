using Domain.Abandonments;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Queries.GetAllReports;

public record GetAllReportsAbandonmentQuery() : IRequest<ErrorOr<IReadOnlyList<ReportAbandonment>>>;