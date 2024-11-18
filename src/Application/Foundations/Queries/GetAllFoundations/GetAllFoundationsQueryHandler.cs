using Application.Common.Interfaces.Persistence;
using Domain.Foundations;
using ErrorOr;
using MediatR;

namespace Application.Foundations.Queries.GetAllFoundations;

public class GetAllFoundationsQueryHandler(IFoundationRepository foundationRepository) : IRequestHandler<GetAllFoundationsQuery, ErrorOr<List<Foundation>>>
{
    public async Task<ErrorOr<List<Foundation>>> Handle(GetAllFoundationsQuery request, CancellationToken cancellationToken)
    {
        return await foundationRepository.GetAllAsync();
    }
}