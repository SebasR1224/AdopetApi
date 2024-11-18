using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class Foundation
    {
        public static Error LocationWithBadFormat => Error.Validation("Foundation.Location", "Location has not valid format.");
        public static Error FoundationNotFound => Error.NotFound(
            "Foundation.FoundationNotFound",
            "Foundation not found. Please check the ID and try again."
        );
    }
}