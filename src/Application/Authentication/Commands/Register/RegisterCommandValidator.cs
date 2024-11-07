using FluentValidation;

namespace Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Name).NotEmpty().MaximumLength(50);

        RuleFor(r => r.LastName)
            .NotEmpty()
            .MaximumLength(50)
            .WithName("Last Name");

        RuleFor(r => r.PersonalId).NotEmpty().MaximumLength(20);

        // RuleFor(r => r.BirthDate).NotEmpty().MaximumLength(20); //todo

        RuleFor(r => r.PhoneNumber).NotEmpty().MaximumLength(20);

        RuleFor(r => r.Address).NotEmpty().MaximumLength(255);

        RuleFor(r => r.Email)
            .NotEmpty()
            .EmailAddress()
            .MaximumLength(255);

        RuleFor(r => r.Username).NotEmpty().MaximumLength(30);

        RuleFor(r => r.Password).NotEmpty().MaximumLength(30);
    }
}