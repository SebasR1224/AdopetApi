using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class ReportAbandonmentRepository(ApplicationDbContext context) : IReportAbandonmentRepository
{
    public async Task AddAsync(ReportAbandonment reportAbandonment)
    {
        await context.ReportAbandonments.AddAsync(reportAbandonment);
        await context.SaveChangesAsync();
    }

    public async Task<List<ReportAbandonment>> GetReportsByFoundationIdAsync(FoundationId foundationId)
    {
        return await context.ReportAbandonments.Where(
        r => r.FoundationId! == foundationId &&
        r.Status != ReportStatus.Reported)
            .Include(r => r.Animals)
            .Include(r => r.Images)
            .Include(r => r.Reporter)
            .ToListAsync();
    }

    public async Task<List<ReportAbandonment>> GetAllReports()
    {
        return await context.ReportAbandonments
            .Include(r => r.Animals)
            .Include(r => r.Images)
            .Include(r => r.Reporter)
            .ToListAsync();
    }

    public async Task<ReportAbandonment?> GetByIdAsync(ReportAbandonmentId reportAbandonmentId)
    {
        return await context.ReportAbandonments
            .Include(r => r.Animals)
            .Include(r => r.Images)
            .Include(r => r.Reporter)
            .FirstOrDefaultAsync(r => r.Id == reportAbandonmentId);
    }

    public async Task UpdateAsync(ReportAbandonment reportAbandonment)
    {
        context.ReportAbandonments.Update(reportAbandonment);
        await context.SaveChangesAsync();
    }
}