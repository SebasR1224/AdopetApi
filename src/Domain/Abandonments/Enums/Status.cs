namespace Domain.Abandonments.Enums;

public enum ReportStatus
{
    Reported,
    PendingApproval,
    Approved,
    InProgress,
    Attending,
    Completed,
    Rejected
}

public enum AbandonmentStatus
{
    Critical,
    High,
    Medium,
    Low,
    NonCritical
}