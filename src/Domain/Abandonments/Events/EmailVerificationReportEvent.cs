using Domain.Abandonments.ValueObjects;
using Domain.Primitives;

namespace Domain.Abandonments.Events;

public record EmailVerificationReportEvent(
    ReportAbandonmentId ReportAbandonmentId,
    string Email,
    string Name
) : IDomainEvent;