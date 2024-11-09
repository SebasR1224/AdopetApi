using Domain.Abandonments.Entities;
using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Animals;
using Domain.Common.ValueObjects;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;
using DomainFile = Domain.Files.File;
namespace Domain.Abandonments;

public sealed class ReportAbandonment : AggregateRoot<ReportAbandonmentId>
{
    private readonly List<DomainFile> _images = [];
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
    public DateTime UpdateDateTime { get; private set; }
    public FoundationId? FoundationId { get; private set; }

    public IReadOnlyCollection<Animal> Animals { get; private set; }

    public IReadOnlyCollection<DomainFile> Images => _images.AsReadOnly();

    private ReportAbandonment(
        ReportAbandonmentId reportAbandonmentId,
        string title,
        string description,
        ReportStatus status,
        Location location,
        DateTime abandonmentDateTime,
        AbandonmentStatus abandonmentStatus,
        Reporter reporter,
        IReadOnlyCollection<Animal> animals
    ) : base(reportAbandonmentId)
    {
        Title = title;
        Description = description;
        Status = status;
        Location = location;
        AbandonmentDateTime = abandonmentDateTime;
        AbandonmentStatus = abandonmentStatus;
        Reporter = reporter;
        Animals = animals;
    }

    public static ReportAbandonment Create(
        string title,
        string description,
        Location location,
        DateTime abandonmentDateTime,
        AbandonmentStatus abandonmentStatus,
        Reporter reporter,
        IReadOnlyCollection<Animal> animals
    )
    {
        return new ReportAbandonment(
            ReportAbandonmentId.CreateUnique(),
            title,
            description,
            ReportStatus.Reported,
            location,
            abandonmentDateTime,
            abandonmentStatus,
            reporter,
            animals
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
        var file = DomainFile.Create(
            url,
            nameof(ReportAbandonment),
            Id.Value
        );

        _images.Add(file);
    }

    public void AddImages(List<string> images)
    {
        foreach (var image in images)
        {
            AddImage(image);
        }
    }

#pragma warning disable CS8618
    private ReportAbandonment() { }
#pragma warning restore CS8618

}
