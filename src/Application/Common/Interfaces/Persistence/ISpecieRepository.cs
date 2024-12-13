using Domain.Animals.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface ISpecieRepository
{
    Task<List<Specie>> GetAllAsync();
}
