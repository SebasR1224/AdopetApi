using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class Foundation
    {
        public static Error LocationWithBadFormat => Error.Validation("Foundation.Location", "Location has not valid format.");
    }
}