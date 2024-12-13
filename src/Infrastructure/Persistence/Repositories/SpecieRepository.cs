using Application.Common.Interfaces.Persistence;
using Domain.Animals.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class SpecieRepository(ApplicationDbContext context) : ISpecieRepository
{
    public async Task<List<Specie>> GetAllAsync()
    {
        return await context.Species.ToListAsync();
    }
}