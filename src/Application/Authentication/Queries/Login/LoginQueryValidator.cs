using FluentValidation;

namespace Application.Authentication.Queries.Login;

public class LoginQueryValidator : AbstractValidator<LoginQuery>
{
    public LoginQueryValidator()
    {
        RuleFor(r => r.Username).NotEmpty();
        RuleFor(r => r.Password).NotEmpty();
    }
}