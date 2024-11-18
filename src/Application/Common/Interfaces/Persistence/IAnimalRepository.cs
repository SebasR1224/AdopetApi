using Domain.Animals;
using Domain.Animals.ValueObjects;

namespace Application.Common.Interfaces.Persistence;

public interface IAnimalRepository
{
    Task<List<Animal>> GetAllAsync();
    Task<Animal?> GetByIdAsync(AnimalId id);
}