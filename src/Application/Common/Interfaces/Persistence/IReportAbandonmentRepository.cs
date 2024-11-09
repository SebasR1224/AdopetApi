using Domain.Abandonments;
using Domain.Abandonments.ValueObjects;
using Domain.Foundations.ValueObjects;

namespace Application.Common.Interfaces.Persistence;

public interface IReportAbandonmentRepository
{
    Task AddAsync(ReportAbandonment reportAbandonment);
    Task<List<ReportAbandonment>> GetReportsByFoundationIdAsync(FoundationId foundationId);
    Task<List<ReportAbandonment>> GetAllReports();
    Task<ReportAbandonment?> GetByIdAsync(ReportAbandonmentId reportAbandonmentId);
    Task UpdateAsync(ReportAbandonment reportAbandonment);
}