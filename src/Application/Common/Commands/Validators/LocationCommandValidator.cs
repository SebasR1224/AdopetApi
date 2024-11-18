namespace Application.Common.Commands.Validators;

using Application.Common.Commands;
using FluentValidation;

public class LocationCommandValidator : AbstractValidator<LocationCommand>
{
    public LocationCommandValidator()
    {
        RuleFor(x => x.Latitude)
            .GreaterThanOrEqualTo(-90)
            .LessThanOrEqualTo(90);

        RuleFor(x => x.Longitude)
            .GreaterThanOrEqualTo(-180)
            .LessThanOrEqualTo(180);

        RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
        RuleFor(x => x.City).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PostalCode).NotEmpty().MaximumLength(10);
    }
}