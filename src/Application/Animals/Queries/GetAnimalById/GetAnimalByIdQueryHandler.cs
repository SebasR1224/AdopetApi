using Application.Common.Interfaces.Persistence;
using Domain.Animals;
using Domain.Animals.ValueObjects;
using Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace Application.Animals.Queries.GetAnimalById;

public class GetAnimalByIdQueryHandler(IAnimalRepository animalRepository) : IRequestHandler<GetAnimalByIdQuery, ErrorOr<Animal>>
{
    public async Task<ErrorOr<Animal>> Handle(GetAnimalByIdQuery request, CancellationToken cancellationToken)
    {
        var animal = await animalRepository.GetByIdAsync(AnimalId.Create(request.id));
        if (animal is null)
            return Errors.Animal.AnimalNotFound;
        return animal;
    }
}

