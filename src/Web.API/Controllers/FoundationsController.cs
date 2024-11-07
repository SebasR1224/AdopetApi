using Application.Foundations.Commands.CreateFoundation;
using Contracts.Foundation;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/api/foundations")]
public class FoundationsController(IMapper mapper, ISender mediator) : ApiController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> CreateFoundation(CreateFoundationRequest request)
    {
        var command = mapper.Map<CreateFoundationCommand>(request);

        var createFoundationResult = await mediator.Send(command);

        return createFoundationResult.Match(
            response => Ok(response),
            errors => Problem(errors)
        );
    }
}