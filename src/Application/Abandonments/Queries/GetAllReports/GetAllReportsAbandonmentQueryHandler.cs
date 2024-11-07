using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Queries.GetAllReports;

public class GetAllReportsAbandonmentQueryHandler(IReportAbandonmentRepository reportAbandonmentRepository) : IRequestHandler<GetAllReportsAbandonmentQuery, ErrorOr<IReadOnlyList<ReportAbandonment>>>
{
    public async Task<ErrorOr<IReadOnlyList<ReportAbandonment>>> Handle(GetAllReportsAbandonmentQuery request, CancellationToken cancellationToken)
    {
        return await reportAbandonmentRepository.GetAllReports();
    }
}
