using Domain.Foundations;
using Domain.Foundations.ValueObjects;

namespace Application.Common.Interfaces.Persistence;

public interface IFoundationRepository
{
    Task AddAsync(Foundation foundation);
    Task<List<Foundation>> GetAllAsync();
    Task<Foundation?> GetByIdAsync(FoundationId id);
    Task<List<Foundation>> GetByCityNameAsync(string cityName);
}