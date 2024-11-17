using Application.Foundations.Commands.CreateFoundation;
using Application.Foundations.Queries.GetAllFoundations;
using Application.Foundations.Queries.GetFoundationById;
using Contracts.Foundation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/api/foundations")]
public class FoundationsController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllFoundations()
    {
        var foundationsResult = await mediator.Send(new GetAllFoundationsQuery());
        return foundationsResult.Match(
            foundations => Ok(mapper.Map<List<FoundationResponse>>(foundations)),
            errors => Problem(errors)
        );
    }


    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateFoundation(CreateFoundationRequest request)
    {
        var command = mapper.Map<CreateFoundationCommand>(request);

        var createFoundationResult = await mediator.Send(command);

        return createFoundationResult.Match(
            response => Ok(mapper.Map<FoundationResponse>(response)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetFoundationById(Guid id)
    {
        var foundationResult = await mediator.Send(new GetFoundationByIdQuery(id));
        return foundationResult.Match(
            response => Ok(mapper.Map<FoundationResponse>(response)),
            errors => Problem(errors)
        );
    }
}
