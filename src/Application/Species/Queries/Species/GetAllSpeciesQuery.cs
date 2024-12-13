using Domain.Animals.Entities;
using ErrorOr;
using MediatR;

namespace Application.Species.Queries.Species;

public record GetAllSpeciesQuery : IRequest<ErrorOr<List<Specie>>>;