using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
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

        return _reportAbandonments.Where(ra => ra.FoundationId! == foundationId).ToList();
    }

    public async Task<List<ReportAbandonment>> GetAllReports()
    {
        await Task.CompletedTask;

        return [.. _reportAbandonments];
    }
}