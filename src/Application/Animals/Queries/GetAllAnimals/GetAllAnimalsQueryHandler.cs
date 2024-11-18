using Application.Common.Interfaces.Persistence;
using Domain.Animals;
using ErrorOr;
using MediatR;

namespace Application.Animals.Queries.GetAllAnimals;

public class GetAllAnimalsQueryHandler(IAnimalRepository animalRepository) : IRequestHandler<GetAllAnimalsQuery, ErrorOr<List<Animal>>>
{
    public async Task<ErrorOr<List<Animal>>> Handle(GetAllAnimalsQuery request, CancellationToken cancellationToken)
    {
        return await animalRepository.GetAllAsync();
    }
}