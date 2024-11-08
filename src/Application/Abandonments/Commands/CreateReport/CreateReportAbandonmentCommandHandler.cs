using Application.Common.Helpers;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Abandonments;
using Domain.Abandonments.Entities;
using Domain.Abandonments.Enums;
using Domain.Animals;
using Domain.Animals.Entities;
using Domain.Animals.Enums;
using Domain.Common.Errors;
using Domain.Common.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Abandonments.Commands.CreateReport;

public sealed class CreateReportAbandonmentCommandHandler(
    IReportAbandonmentRepository abandonmentRepository,
    IFoundationRepository foundationRepository,
    ILocationService locationService
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
            Reporter.Create(
                request.Reporter.Name,
                request.Reporter.LastName,
                request.Reporter.Email,
                request.Reporter.PhoneNumber,
                request.Reporter.IsAnonymous
            ),
            request.Animals.Select(animal => Animal.Create(
                animal.Name,
                animal.Description,
                animal.Image,
                animal.Age,
                animal.CoatColor,
                animal.Weight,
                animal.Specie,
                animal.Breed,
                EnumHelper.ConvertToEnum<AnimalGender>(animal.Gender) ?? AnimalGender.Unknown,
                null
            )).ToList()
        );

        //Persistent Report
        var foundations = await foundationRepository.GetByCityNameAsync(location.City);
        var nearestFoundation = locationService.FindNearestFoundation(reportAbandonment, foundations);

        if (nearestFoundation is not null)
        {
            reportAbandonment.SetFoundation(nearestFoundation.Id);
        }

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
