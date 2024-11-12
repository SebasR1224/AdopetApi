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
        public static Error EmailAlreadyVerified => Error.Conflict(
            code: "Auth.EmailAlreadyVerified",
            description: "Email already verified"
        );
        public static Error InvalidToken => Error.Validation(
            code: "Auth.InvalidToken",
            description: "Invalid token"
        );
    }
}