using Application.Abandonments.Commands.CreateReport;
using Application.Abandonments.Queries.GetAllReports;
using Application.Abandonments.Queries.GetReportsByFoundationId;
using Contracts.Abandonment;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.API.Controllers;

[Route("/api/reports-abandonment")]
public class ReportsAbandonmentController(IMapper mapper, ISender mediator) : ApiController
{
    [AllowAnonymous]
    [HttpPost]
    public async Task<IActionResult> ReportAbandonment(CreateReportAbandonmentRequest request)
    {
        var command = mapper.Map<CreateReportAbandonmentCommand>(request);

        var createReportAbandonmentResult = await mediator.Send(command);

        return createReportAbandonmentResult.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReports()
    {
        var reportsAbandonmentResult = await mediator.Send(new GetAllReportsAbandonmentQuery());

        return reportsAbandonmentResult.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }

    [HttpGet("{foundationId}/foundation")]
    public async Task<IActionResult> GetReportsByFoundation(Guid foundationId)
    {
        var query = new GetReportsAbandonmentByFoundationIdQuery(foundationId);
        var reportsAbandonmentResult = await mediator.Send(query);

        return reportsAbandonmentResult.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}