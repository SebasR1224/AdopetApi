namespace Application.Foundations.Commands.CreateFoundation.Validators;

using Application.Common.Commands.Validators;
using FluentValidation;

public class CreateFoundationCommandValidator : AbstractValidator<CreateFoundationCommand>
{
    public CreateFoundationCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LegalName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Description).NotEmpty().MaximumLength(1000);
        RuleFor(x => x.Nit).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.Website).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Mission).MaximumLength(1000);
        RuleFor(x => x.Vission).MaximumLength(1000);
        RuleFor(x => x.LegalRepresentatives).NotEmpty();

        RuleFor(x => x.Location).SetValidator(new LocationCommandValidator());

        RuleForEach(x => x.LegalRepresentatives)
            .SetValidator(new LegalRepresentativeCommandValidator());
    }
}