using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Foundations;
using Domain.Foundations.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Foundations.Queries.GetFoundationById;

public class GetFoundationByIdQueryHandler(IFoundationRepository foundationRepository) : IRequestHandler<GetFoundationByIdQuery, ErrorOr<Foundation>>
{
    public async Task<ErrorOr<Foundation>> Handle(GetFoundationByIdQuery request, CancellationToken cancellationToken)
    {
        var foundation = await foundationRepository.GetByIdAsync(FoundationId.Create(request.Id));
        if (foundation is null)
            return Errors.Foundation.FoundationNotFound;

        return foundation;
    }
}