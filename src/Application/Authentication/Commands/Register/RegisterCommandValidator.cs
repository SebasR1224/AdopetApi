using FluentValidation;

namespace Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        RuleFor(x => x.LastName).NotEmpty().MaximumLength(100);
        RuleFor(x => x.PersonalId).NotEmpty().MaximumLength(20);

        RuleFor(x => x.BirthDate)
            .NotEmpty()
            .Must(BeValidAge).WithMessage("You must be of legal age");

        RuleFor(x => x.PhoneNumber).NotEmpty();

        RuleFor(x => x.Address).NotEmpty().MaximumLength(200);

        RuleFor(x => x.Email).NotEmpty().EmailAddress();

        RuleFor(x => x.Username)
            .NotEmpty()
            .MinimumLength(3)
            .MaximumLength(50)
            .Matches("^[a-zA-Z0-9._-]+$").WithMessage("The username can only contain letters, numbers, dots, hyphens, and underscores");

        RuleFor(x => x.Password)
            .NotEmpty()
            .MinimumLength(8)
            .Matches("[A-Z]").WithMessage("The password must contain at least one uppercase letter")
            .Matches("[a-z]").WithMessage("The password must contain at least one lowercase letter")
            .Matches("[0-9]").WithMessage("The password must contain at least one number")
            .Matches("[^a-zA-Z0-9]").WithMessage("The password must contain at least one special character");

    }

    private bool BeValidAge(DateOnly birthDate)
    {
        var today = DateOnly.FromDateTime(DateTime.UtcNow);
        var age = today.Year - birthDate.Year;

        if (birthDate > today.AddYears(-age))
            age--;

        return age >= 18;
    }
}