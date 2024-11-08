using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Foundations.ValueObjects;

namespace Infrastructure.Persistence.Repositories;


public class ReportAbandonmentRepository : IReportAbandonmentRepository
{
    private static readonly List<ReportAbandonment> _reportAbandonments = [];

    public void Add(ReportAbandonment reportAbandonment)
    {
        _reportAbandonments.Add(reportAbandonment);
    }

    public async Task<List<ReportAbandonment>> GetReportsByFoundationIdAsync(FoundationId foundationId)
    {
        await Task.CompletedTask;

        return _reportAbandonments.Where(
            r => r.FoundationId! == foundationId &&
            r.Status != ReportStatus.Reported
        ).ToList();
    }

    public async Task<List<ReportAbandonment>> GetAllReports()
    {
        await Task.CompletedTask;

        return _reportAbandonments;
    }

    public async Task<ReportAbandonment?> GetByIdAsync(ReportAbandonmentId reportAbandonmentId)
    {
        await Task.CompletedTask;

        return _reportAbandonments.FirstOrDefault(r => r.Id == reportAbandonmentId);
    }

    public void Update(ReportAbandonment reportAbandonment)
    {
        var index = _reportAbandonments.FindIndex(r => r.Id == reportAbandonment.Id);
        if (index != -1)
        {
            _reportAbandonments[index] = reportAbandonment;
        }
    }
}