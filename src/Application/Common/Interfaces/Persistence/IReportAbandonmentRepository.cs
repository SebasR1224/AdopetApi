using Domain.Abandonments;
using Domain.Foundations.ValueObjects;

namespace Application.Common.Interfaces.Persistence;

public interface IReportAbandonmentRepository
{
    void Add(ReportAbandonment reportAbandonment);
    Task<List<ReportAbandonment>> GetReportsByFoundationIdAsync(FoundationId foundationId);
    Task<List<ReportAbandonment>> GetAllReports();

}