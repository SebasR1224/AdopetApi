using ErrorOr;

namespace Domain.Common.Errors;

public partial class Errors
{
    public static class ReportAbandonment
    {
        public static Error LocationWithBadFormat => Error.Validation("ReportAbandonment.Location", "Location has not valid format.");
        public static Error InvalidAbandonmentStatus => Error.Validation("ReportAbandonment.AbandonmentStatus", "AbandonmentStatus has not valid.");
    }
}