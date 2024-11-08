using Application.Abandonments.Commands.CreateReport;
using Application.Abandonments.Commands.UpdateReportStatus;
using Application.Abandonments.Queries.GetAllReports;
using Application.Abandonments.Queries.GetReportsByFoundationId;
using Contracts.Abandonment;
using Domain.Abandonments.Enums;
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
            result => Ok(mapper.Map<ReportAbandonmentResponse>(result)),
            errors => Problem(errors)
        );
    }

    [HttpGet]
    public async Task<IActionResult> GetAllReports()
    {
        var reportsAbandonmentResult = await mediator.Send(new GetAllReportsAbandonmentQuery());

        return reportsAbandonmentResult.Match(
            result => Ok(mapper.Map<List<ReportAbandonmentResponse>>(result)),
            errors => Problem(errors)
        );
    }

    [HttpGet("{foundationId}/foundation")]
    public async Task<IActionResult> GetReportsByFoundation(
        Guid foundationId,
        [FromQuery] ReportStatus? status = null,
        [FromQuery] DateTime? startDate = null,
        [FromQuery] DateTime? endDate = null,
        [FromQuery] AbandonmentStatus? abandonmentStatus = null,
        [FromQuery] Guid? reporterId = null)
    {
        var query = new GetReportsAbandonmentByFoundationIdQuery(
            foundationId,
            status,
            startDate,
            endDate,
            abandonmentStatus,
            reporterId);

        var reportsAbandonmentResult = await mediator.Send(query);

        return reportsAbandonmentResult.Match(
            result => Ok(mapper.Map<List<ReportAbandonmentResponse>>(result)),
            errors => Problem(errors)
        );
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateReportStatus(Guid id, [FromBody] UpdateReportStatusRequest request)
    {
        var command = new UpdateReportStatusCommand(id, request.Status);

        var updateResult = await mediator.Send(command);

        return updateResult.Match(
            result => Ok(result),
            errors => Problem(errors)
        );
    }
}
