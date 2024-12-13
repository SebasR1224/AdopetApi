using Application.Config.Queries.Species;
using Contracts.Species;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/species")]
[AllowAnonymous]
public class SpeciesController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllSpecies()
    {
        var speciesResult = await mediator.Send(new GetAllSpeciesQuery());
        return speciesResult.Match(
            species => Ok(mapper.Map<List<SpeciesResponse>>(species)),
            errors => Problem(errors)
        );
    }
}
