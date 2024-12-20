using Application.Common.Interfaces.Persistence;
using Domain.Animals;
using Domain.Animals.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class AnimalRepository(ApplicationDbContext context) : IAnimalRepository
{
    public async Task<List<Animal>> GetAllAsync()
        => await context.Animals.Include(a => a.Images).ToListAsync();

    public async Task<Animal?> GetByIdAsync(AnimalId id)
        => await context.Animals.Include(a => a.Images).SingleOrDefaultAsync(a => a.Id == id);
}