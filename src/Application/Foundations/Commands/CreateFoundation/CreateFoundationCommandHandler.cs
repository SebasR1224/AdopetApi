using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using Domain.Common.ValueObjects;
using Domain.Foundations;
using Domain.Foundations.Entities;
using ErrorOr;
using MediatR;

namespace Application.Foundations.Commands.CreateFoundation;

public class CreateFoundationCommandHandler(IFoundationRepository foundationRepository) : IRequestHandler<CreateFoundationCommand, ErrorOr<Foundation>>
{
    public async Task<ErrorOr<Foundation>> Handle(CreateFoundationCommand request, CancellationToken cancellationToken)
    {
        //Validations
        if (Location.Create(
            request.Location.Latitude,
            request.Location.Longitude,
            request.Location.Address,
            request.Location.City,
            request.Location.PostalCode
        ) is not Location location)
        {
            return Errors.Foundation.LocationWithBadFormat;
        }

        //Create Foundation
        var foundation = Foundation.Create(
            name: request.Name,
            legalName: request.LegalName,
            description: request.Description,
            nit: request.Nit,
            location: location,
            email: request.Email,
            website: request.Website,
            phoneNumber: request.PhoneNumber,
            mission: request.Mission,
            vission: request.Vission,
            legalRepresentatives: request.LegalRepresentatives.ConvertAll(lr => LegalRepresentative.Create(
                lr.Name,
                lr.LastName,
                lr.PersonalId,
                lr.Email,
                lr.PhoneNumber,
                lr.Address
            ))
        );

        if (request.Logo is not null)
            foundation.AddLogo(request.Logo);

        //Persistence Foundation
        await foundationRepository.AddAsync(foundation);

        //Return Foundation
        return foundation;
    }
}
