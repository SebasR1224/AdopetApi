using Application.Animals.Queries.GetAllAnimals;
using Application.Animals.Queries.GetAnimalById;
using Contracts.Animals;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/api/animals")]
public class AnimalsController(ISender mediator, IMapper mapper) : ApiController
{
    [HttpGet]
    public async Task<IActionResult> GetAllAnimals()
    {
        var animalsResult = await mediator.Send(new GetAllAnimalsQuery());
        return animalsResult.Match(
            animals => Ok(mapper.Map<List<AnimalResponse>>(animals)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimalById(Guid id)
    {
        var animalResult = await mediator.Send(new GetAnimalByIdQuery(id));
        return animalResult.Match(
            animal => Ok(mapper.Map<AnimalResponse>(animal)),
            errors => Problem(errors)
        );
    }
}