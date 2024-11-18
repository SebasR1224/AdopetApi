using Application.Common.Interfaces.Persistence;
using Domain.Foundations;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class FoundationRepository(ApplicationDbContext context) : IFoundationRepository
{
    public async Task AddAsync(Foundation foundation)
    {
        context.Foundations.Add(foundation);
        await context.SaveChangesAsync();
    }
    public async Task<List<Foundation>> GetAllAsync() => await context.Foundations.ToListAsync();

    public async Task<Foundation?> GetByIdAsync(FoundationId id) => await context.Foundations.SingleOrDefaultAsync(f => f.Id == id);

    public async Task<List<Foundation>> GetByCityNameAsync(string cityName) => await context.Foundations.Where(x => x.Location.City == cityName).ToListAsync();
}