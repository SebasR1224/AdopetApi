using Domain.Common.ValueObjects;
using Domain.Foundations.Entities;
using Domain.Foundations.Enums;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Foundations;

public sealed class Foundation : AggregateRoot<FoundationId>
{
    private readonly List<LegalRepresentative> _legalRepresentatives = [];
    public string Name { get; private set; }
    public string? Logo { get; private set; }
    public string Description { get; set; }
    public string Nit { get; private set; }
    public Location Location { get; private set; }
    public string Email { get; private set; }
    public string Website { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Mission { get; private set; }
    public string Vision { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public FoundationStatus Status { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }
    public IReadOnlyList<LegalRepresentative> LegalRepresentatives => _legalRepresentatives.AsReadOnly();

    private Foundation(
        FoundationId foundationId,
        string name,
        string? logo,
        string description,
        string nit,
        Location location,
        string email,
        string website,
        string phoneNumber,
        string mission,
        string vision,
        AverageRating averageRating,
        FoundationStatus status,
        List<LegalRepresentative> legalRepresentatives

    ) : base(foundationId)
    {
        Name = name;
        Logo = logo;
        Description = description;
        Nit = nit;
        Location = location;
        Email = email;
        Website = website;
        PhoneNumber = phoneNumber;
        Mission = mission;
        Vision = vision;
        AverageRating = averageRating;
        Status = status;
        _legalRepresentatives = legalRepresentatives;
    }
    public static Foundation Create(
        string name,
        string? logo,
        string description,
        string nit,
        Location location,
        string email,
        string website,
        string phoneNumber,
        string mission,
        string vision,
        List<LegalRepresentative> legalRepresentatives
    )
    {
        return new Foundation(
            FoundationId.CreateUnique(),
            name,
            logo,
            description,
            nit,
            location,
            email,
            website,
            phoneNumber,
            mission,
            vision,
            AverageRating.CreateNew(),
            FoundationStatus.PendingRegistration,
            legalRepresentatives
        );
    }


#pragma warning disable CS8618
    private Foundation() { }
#pragma warning restore CS8618
}