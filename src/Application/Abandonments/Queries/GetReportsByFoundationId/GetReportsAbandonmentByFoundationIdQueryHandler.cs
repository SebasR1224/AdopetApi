using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Abandonments.ValueObjects;
using Domain.Foundations.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Queries.GetReportsByFoundationId;

public class GetReportsAbandonmentByFoundationIdQueryHandler(IReportAbandonmentRepository reportAbandonmentRepository)
    : IRequestHandler<GetReportsAbandonmentByFoundationIdQuery, ErrorOr<List<ReportAbandonment>>>
{
    public async Task<ErrorOr<List<ReportAbandonment>>> Handle(GetReportsAbandonmentByFoundationIdQuery request, CancellationToken cancellationToken)
    {
        var reports = await reportAbandonmentRepository.GetReportsByFoundationIdAsync(FoundationId.Create(request.FoundationId));

        return reports
            .Where(r => !request.Status.HasValue || r.Status == request.Status)
            .Where(r => !request.StartDate.HasValue || r.ReportDateTime >= request.StartDate)
            .Where(r => !request.EndDate.HasValue || r.ReportDateTime <= request.EndDate)
            .Where(r => !request.AbandonmentStatus.HasValue || r.AbandonmentStatus == request.AbandonmentStatus)
            .Where(r => !request.ReporterId.HasValue || r.Reporter.Id == ReporterId.Create(request.ReporterId.Value))
            .ToList();
    }
}
