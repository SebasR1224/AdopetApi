using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentials => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid Credentials"
        );
        public static Error EmailNotVerified => Error.Validation(
            code: "Auth.EmailNotVerified",
            description: "Email not verified"
        );
    }
}