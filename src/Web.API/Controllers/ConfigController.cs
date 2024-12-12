namespace Web.API.Controllers;

[ApiController]
[Route("api/config")]
public class ConfigController(IMapper mapper, ISender mediator) : ApiController
{
    [HttpGet("species")]
    public async Task<IActionResult> GetAllSpecies()
    {
        var speciesResult = await mediator.Send(new GetAllSpeciesQuery());
        return speciesResult.Match(
            species => Ok(mapper.Map<List<SpeciesResponse>>(species)),
            errors => Problem(errors)
        );
    }
}
