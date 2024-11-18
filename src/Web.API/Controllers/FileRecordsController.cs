using Application.FileRecords.Commands.UploadFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/api/files")]
public class FileRecordsController(ISender mediator) : ApiController
{
    [AllowAnonymous]
    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        var command = new UploadFileCommand(file.OpenReadStream(), file.FileName);
        var result = await mediator.Send(command);
        return result.Match(
            result => Ok(new { Url = result }),
            errors => Problem(errors)
        );
    }
}