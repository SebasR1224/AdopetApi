using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ReportAbandonmentRepository(ApplicationDbContext context) : IReportAbandonmentRepository
{
    public void Add(ReportAbandonment reportAbandonment)
    {
        context.ReportAbandonments.Add(reportAbandonment);
        context.SaveChanges();
    }

    public async Task<List<ReportAbandonment>> GetReportsByFoundationIdAsync(FoundationId foundationId)
    {
        await Task.CompletedTask;

        return [.. context.ReportAbandonments.Where(
            r => r.FoundationId! == foundationId &&
            r.Status != ReportStatus.Reported)
            .Include(r => r.Animals)
            .Include(r => r.Images)
            .Include(r => r.Reporter)];
    }

    public async Task<List<ReportAbandonment>> GetAllReports()
    {
        await Task.CompletedTask;

        return [.. context.ReportAbandonments
            .Include(r => r.Animals)
            .Include(r => r.Images)
            .Include(r => r.Reporter)];
    }

    public async Task<ReportAbandonment?> GetByIdAsync(ReportAbandonmentId reportAbandonmentId)
    {
        await Task.CompletedTask;

        return context.ReportAbandonments.FirstOrDefault(r => r.Id == reportAbandonmentId);
    }

    public void Update(ReportAbandonment reportAbandonment)
    {
        context.ReportAbandonments.Update(reportAbandonment);
    }
}