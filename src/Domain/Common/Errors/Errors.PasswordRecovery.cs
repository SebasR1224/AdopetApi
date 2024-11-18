using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class PasswordRecovery
    {
        public static Error InvalidToken = Error.Validation("PasswordRecovery.Token", "The token is invalid.");
    }
}