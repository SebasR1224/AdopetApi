using Application.Common.Interfaces.Persistence;
using Domain.Animals;
using Domain.Animals.ValueObjects;

namespace Infrastructure.Persistence.Repositories;

public class AnimalRepository() : IAnimalRepository
{
    private static readonly List<Animal> _animals = [];
    public async Task<List<Animal>> GetAllAsync()
    {
        await Task.CompletedTask;
        return _animals;
    }

    public async Task<Animal?> GetByIdAsync(AnimalId id)
    {
        await Task.CompletedTask;
        return _animals.FirstOrDefault(x => x.Id == id);
    }
}