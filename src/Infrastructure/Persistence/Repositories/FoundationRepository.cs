using Application.Common.Interfaces.Persistence;
using Domain.Foundations;
using Domain.Foundations.ValueObjects;

namespace Infrastructure.Persistence.Repositories;

public class FoundationRepository : IFoundationRepository
{
    private static readonly List<Foundation> _foundations = [];
    public void Add(Foundation foundation)
    {
        _foundations.Add(foundation);
    }

    public async Task<Foundation?> GetByIdAsync(FoundationId id)
    {
        await Task.CompletedTask;
        return _foundations.FirstOrDefault(x => x.Id == id);
    }
}