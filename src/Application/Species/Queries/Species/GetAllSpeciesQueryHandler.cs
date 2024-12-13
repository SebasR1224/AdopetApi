using Application.Common.Interfaces.Persistence;
using Application.Species.Queries.Species;
using Domain.Animals.Entities;
using ErrorOr;
using MediatR;

namespace Application.Config.Queries.Species;

public class GetAllSpeciesQueryHandler(ISpecieRepository specieRepository) : IRequestHandler<GetAllSpeciesQuery, ErrorOr<List<Specie>>>
{
    public async Task<ErrorOr<List<Specie>>> Handle(GetAllSpeciesQuery request, CancellationToken cancellationToken)
    {
        return await specieRepository.GetAllAsync();
    }
}