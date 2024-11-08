using Domain.Foundations;
using Domain.Foundations.ValueObjects;

namespace Application.Common.Interfaces.Persistence;

public interface IFoundationRepository
{
    void Add(Foundation foundation);
    Task<List<Foundation>> GetAllAsync();
    Task<Foundation?> GetByIdAsync(FoundationId id);
    Task<List<Foundation>> GetByCityNameAsync(string cityName);
}