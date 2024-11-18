using Application.PasswordRecovery.Commands.RequestReset;
using Application.PasswordRecovery.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("api/password-recovery")]
[AllowAnonymous]
public class PasswordRecoveryController(ISender mediator) : ApiController
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

    [HttpPost("reset")]
    public async Task<IActionResult> Reset(ResetPasswordCommand command)
    {

        var result = await mediator.Send(command);

        return result.Match(
            _ => NoContent(),
            errors => Problem(errors)
        );
    }
}