using Application.PasswordRecovery.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/password-recovery")]
[AllowAnonymous]
public class PasswordRecoveryController(
    ISender mediator
) : ApiController
{
    [HttpPost("request-reset")]
    public async Task<IActionResult> RequestReset(RequestResetPasswordCommand command)
    {
        var result = await mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
}