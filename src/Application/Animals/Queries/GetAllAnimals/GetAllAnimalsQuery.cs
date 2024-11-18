using Domain.Animals;
using ErrorOr;
using MediatR;

namespace Application.Animals.Queries.GetAllAnimals;

public record GetAllAnimalsQuery : IRequest<ErrorOr<List<Animal>>>;