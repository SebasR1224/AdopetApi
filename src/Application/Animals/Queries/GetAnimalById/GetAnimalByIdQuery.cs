using Domain.Animals;
using ErrorOr;
using MediatR;

namespace Application.Animals.Queries.GetAnimalById;

public record GetAnimalByIdQuery(Guid id) : IRequest<ErrorOr<Animal>>;