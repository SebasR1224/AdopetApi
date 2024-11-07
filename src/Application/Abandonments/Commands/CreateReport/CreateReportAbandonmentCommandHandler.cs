using Application.Common.Interfaces.Persistence;
using Domain.Abandonments;
using Domain.Abandonments.Enums;
using Domain.Common.Errors;
using Domain.Common.ValueObjects;
using Domain.Reporters.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Commands.CreateReport;

public sealed class CreateReportAbandonmentCommandHandler(
    IReportAbandonmentRepository abandonmentRepository
) : IRequestHandler<CreateReportAbandonmentCommand, ErrorOr<ReportAbandonment>>
{
    public async Task<ErrorOr<ReportAbandonment>> Handle(CreateReportAbandonmentCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;

        //Validations
        if (Location.Create(
            request.Location.Latitude,
            request.Location.Longitude,
            request.Location.Address,
            request.Location.City,
            request.Location.PostalCode
        ) is not Location location)
        {
            return Errors.ReportAbandonment.LocationWithBadFormat;
        }

        if (ConvertToAbandonmentStatus(request.AbandonmentStatus) is not AbandonmentStatus abandonmentStatus)
        {
            return Errors.ReportAbandonment.InvalidAbandonmentStatus;
        }

        //Create Report Abandonment
        var reportAbandonment = ReportAbandonment.Create(
            request.Title,
            request.Description,
            request.Images,
            location,
            request.AbandonmentDateTime,
            abandonmentStatus,
            ReporterId.Create(request.ReporterId));

        //Persistent Report
        abandonmentRepository.Add(reportAbandonment);

        //return Report Abandonment

        return reportAbandonment;
    }

    public static AbandonmentStatus? ConvertToAbandonmentStatus(string status)
    {
        if (Enum.TryParse<AbandonmentStatus>(status, true, out var result))
        {
            return result;
        }
        return null;
    }
}
