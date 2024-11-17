namespace Application.Abandonments.Commands.CreateReport.Validators;

using FluentValidation;

public class AnimalCommandValidator : AbstractValidator<AnimalCommand>
{
    public AnimalCommandValidator()
    {
        RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        RuleFor(x => x.CoatColor).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Specie).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Gender).NotEmpty().Must(x => x == "MALE" || x == "FEMALE");
    }
}