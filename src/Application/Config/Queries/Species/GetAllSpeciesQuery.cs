namespace Application.Config.Queries.Species;

public record GetAllSpeciesQuery : IRequest<ErrorOr<List<Specie>>>;