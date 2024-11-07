using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class User
    {
        public static Error DuplicateUsername => Error.Conflict(
            code: "User.DuplicateUsername",
            description: "Already username exists."
        );

        public static Error FoundationNotFound => Error.NotFound(
            "User.FoundationNotFound",
            "Foundation not found. Please check the ID and try again."
        );
    }
}