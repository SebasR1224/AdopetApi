using Domain.Foundations;
using ErrorOr;
using MediatR;

namespace Application.Foundations.Queries.GetFoundationById;

public record GetFoundationByIdQuery(Guid Id) : IRequest<ErrorOr<Foundation>>;