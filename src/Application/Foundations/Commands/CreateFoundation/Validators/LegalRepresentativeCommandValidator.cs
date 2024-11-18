namespace Application.Foundations.Commands.CreateFoundation.Validators;

using FluentValidation;

public class LegalRepresentativeCommandValidator : AbstractValidator<LegalRepresentativeCommand>
{
    public LegalRepresentativeCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PersonalId).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.Address).NotEmpty().MaximumLength(200);
    }
}