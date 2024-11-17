namespace Application.Abandonments.Commands.CreateReport.Validators;

using Application.Common.Commands.Validators;
using FluentValidation;

public class CreateReportAbandonmentCommandValidator : AbstractValidator<CreateReportAbandonmentCommand>
{
    public CreateReportAbandonmentCommandValidator()
    {
        RuleFor(r => r.Title).NotEmpty().MaximumLength(100);
        RuleFor(r => r.Description).NotEmpty().MaximumLength(1000);
        RuleFor(r => r.Images).NotEmpty();
        RuleFor(r => r.AbandonmentDateTime).NotEmpty();
        RuleFor(r => r.Reporter).NotEmpty();
        RuleFor(r => r.Location).NotEmpty();
        RuleFor(r => r.Animals).NotEmpty();
        RuleFor(r => r.AbandonmentStatus).NotEmpty().MaximumLength(50);

        RuleForEach(x => x.Animals).SetValidator(new AnimalCommandValidator());
        RuleFor(x => x.Reporter).SetValidator(new ReporterCommandValidator());
        RuleFor(x => x.Location).SetValidator(new LocationCommandValidator());
    }
}