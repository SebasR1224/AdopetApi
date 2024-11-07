using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Animals.ValueObjects;
using Domain.Common.ValueObjects;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;
using Domain.Reporters.ValueObjects;

namespace Domain.Abandonments;

public sealed class ReportAbandonment : AggregateRoot<ReportAbandonmentId>
{
    private readonly List<AnimalId> _animalsIds = [];
    public string Title { get; private set; }
    public string Description { get; private set; }
    public List<string> Images { get; private set; } = [];
    public ReportStatus Status { get; private set; }
    public Location Location { get; private set; }
    public DateTime AbandonmentDateTime { get; private set; }
    public TimeSpan AbandonmentDuration => DateTime.UtcNow - AbandonmentDateTime;
    public AbandonmentStatus AbandonmentStatus { get; private set; }
    public DateTime ReportDateTime { get; private set; }
    public DateTime? RescueDateTime { get; private set; }
    public TimeSpan? ResponseTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdateDateTime { get; private set; }
    public ReporterId ReporterId { get; private set; }
    public FoundationId? FoundationId { get; private set; }
    public IReadOnlyList<AnimalId> AnimalIds => _animalsIds.AsReadOnly();

    private ReportAbandonment(
        ReportAbandonmentId reportAbandonmentId,
        string title,
        string description,
        List<string> images,
        ReportStatus status,
        Location location,
        DateTime abandonmentDateTime,
        AbandonmentStatus abandonmentStatus,
        ReporterId reporterId
        ) : base(reportAbandonmentId)
    {
        Title = title;
        Description = description;
        Images = images;
        Status = status;
        Location = location;
        AbandonmentDateTime = abandonmentDateTime;
        AbandonmentStatus = abandonmentStatus;
        ReporterId = reporterId;
    }

    public static ReportAbandonment Create(
        string title,
        string description,
        List<string> images,
        Location location,
        DateTime abandonmentDateTime,
        AbandonmentStatus abandonmentStatus,
        ReporterId reporterId
    )
    {
        return new ReportAbandonment(
            ReportAbandonmentId.CreateUnique(),
            title,
            description,
            images,
            ReportStatus.Reported,
            location,
            abandonmentDateTime,
            abandonmentStatus,
            reporterId
        );
    }

    public void SetRescueDate(DateTime rescueDateTime)
    {
        RescueDateTime = rescueDateTime;
        UpdateDateTime = DateTime.UtcNow;

        if (rescueDateTime > ReportDateTime)
        {
            ResponseTime = rescueDateTime - ReportDateTime;
        }

        Status = ReportStatus.Attending;
    }

}
