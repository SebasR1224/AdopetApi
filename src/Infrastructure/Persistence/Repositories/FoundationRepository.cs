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
    public async Task<List<Foundation>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _foundations;
    }
    public async Task<Foundation?> GetByIdAsync(FoundationId id)
    {
        await Task.CompletedTask;
        return _foundations.FirstOrDefault(x => x.Id == id);
    }

    public async Task<List<Foundation>> GetByCityNameAsync(string cityName)
    {
        await Task.CompletedTask;
        return _foundations.Where(x => x.Location.City == cityName).ToList();
    }
}