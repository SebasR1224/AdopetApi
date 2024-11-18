namespace Application.Abandonments.Commands.CreateReport.Validators;

using FluentValidation;

public class ReporterCommandValidator : AbstractValidator<ReporterCommand>
{
    public ReporterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
        RuleFor(x => x.PhoneNumber).NotEmpty();
        RuleFor(x => x.IsAnonymous).NotEmpty();
    }
}