using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Foundations.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Queries.GetReportsByFoundationId;

public class GetReportsAbandonmentByFoundationIdQueryHandler(IReportAbandonmentRepository reportAbandonmentRepository) : IRequestHandler<GetReportsAbandonmentByFoundationIdQuery, ErrorOr<IReadOnlyList<ReportAbandonment>>>
{
    public async Task<ErrorOr<IReadOnlyList<ReportAbandonment>>> Handle(GetReportsAbandonmentByFoundationIdQuery request, CancellationToken cancellationToken)
    {
        return await reportAbandonmentRepository.GetReportsByFoundationIdAsync(FoundationId.Create(request.FoundationId));
    }
}
