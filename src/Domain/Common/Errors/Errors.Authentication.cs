using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class Authentication
    {
        public static Error InvalidCredentias => Error.Validation(
            code: "Auth.InvalidCredentials",
            description: "Invalid Credentials"
        );
    }
}