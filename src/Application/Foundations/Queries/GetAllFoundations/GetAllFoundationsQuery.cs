using Domain.Foundations;
using ErrorOr;
using MediatR;

namespace Application.Foundations.Queries.GetAllFoundations;

public record GetAllFoundationsQuery : IRequest<ErrorOr<List<Foundation>>>;