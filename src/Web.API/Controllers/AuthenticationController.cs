using Application.Authentication.Commands.Register;
using Application.Authentication.Queries.Login;
using Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/api/auth")]
[AllowAnonymous]
public class Authentication(ISender mediator, IMapper mapper) : ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterRequest request)
    {
        var command = mapper.Map<RegisterCommand>(request);
        var authenticationResult = await mediator.Send(command);

        return authenticationResult.Match(
            auth => Ok(mapper.Map<AuthenticationResponse>(auth)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = mapper.Map<LoginQuery>(request);
        var authenticationResult = await mediator.Send(query);

        return authenticationResult.Match(
            auth => Ok(mapper.Map<AuthenticationResponse>(auth)),
            errors => Problem(errors)
        );
    }
}