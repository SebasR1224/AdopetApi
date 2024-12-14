using Domain.Abandonments.Entities;
using Domain.Abandonments.Enums;
using Domain.Abandonments.Events;
using Domain.Abandonments.ValueObjects;
using Domain.Animals;
using Domain.Common.ValueObjects;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;
namespace Domain.Abandonments;

public sealed class ReportAbandonment : AggregateRoot<ReportAbandonmentId>
{
    private readonly List<ReportAbandonmentImage> _images = [];
    private readonly List<Animal> _animals = [];
    public string Title { get; private set; }
    public string Description { get; private set; }
    public ReportStatus Status { get; private set; }
    public Location Location { get; private set; }
    public DateTime AbandonmentDateTime { get; private set; }
    public TimeSpan AbandonmentDuration => DateTime.UtcNow - AbandonmentDateTime;
    public AbandonmentStatus AbandonmentStatus { get; private set; }
    public Reporter Reporter { get; private set; }
    public DateTime ReportDateTime { get; private set; }
    public DateTime? RescueDateTime { get; private set; }
    public TimeSpan? ResponseTime { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public FoundationId? FoundationId { get; private set; }

    public IReadOnlyList<Animal> Animals => _animals.AsReadOnly();

    public IReadOnlyCollection<ReportAbandonmentImage> Images => _images.AsReadOnly();

    private ReportAbandonment(
        ReportAbandonmentId reportAbandonmentId,
        string title,
        string description,
        ReportStatus status,
        Location location,
        DateTime abandonmentDateTime,
        AbandonmentStatus abandonmentStatus,
        Reporter reporter,
        List<Animal> animals,
        List<ReportAbandonmentImage> images
    ) : base(reportAbandonmentId)
    {
        Title = title;
        Description = description;
        Status = status;
        Location = location;
        AbandonmentDateTime = abandonmentDateTime;
        AbandonmentStatus = abandonmentStatus;
        Reporter = reporter;
        _animals = animals;
        _images = images;
    }

    public static ReportAbandonment Create(
        string title,
        string description,
        Location location,
        DateTime? abandonmentDateTime,
        AbandonmentStatus abandonmentStatus,
        Reporter reporter,
        List<Animal> animals,
        List<ReportAbandonmentImage> images
    )
    {
        var status = reporter.IsAnonymous
            ? ReportStatus.Reported
            : ReportStatus.PendingApproval;

        var report = new ReportAbandonment(
            ReportAbandonmentId.CreateUnique(),
            title,
            description,
            status,
            location,
            abandonmentDateTime ?? DateTime.UtcNow,
            abandonmentStatus,
            reporter,
            animals,
            images
        );

        report.AddDomainEvent(new EmailVerificationReportEvent(report.Id, report.Reporter.Email, report.Reporter.Name));

        return report;
    }

    public void SetRescueDate(DateTime rescueDateTime)
    {
        RescueDateTime = rescueDateTime;
        UpdatedDateTime = DateTime.UtcNow;

        if (rescueDateTime > ReportDateTime)
        {
            ResponseTime = rescueDateTime - ReportDateTime;
        }

        Status = ReportStatus.Attending;
    }


    public void SetFoundation(FoundationId foundationId)
    {
        FoundationId = foundationId;
    }

    public void UpdateStatus(ReportStatus status)
    {
        Status = status;
    }

    public void AddImage(string url)
    {
        _images.Add(ReportAbandonmentImage.Create(url));
    }

#pragma warning disable CS8618
    private ReportAbandonment() { }
#pragma warning restore CS8618

}
