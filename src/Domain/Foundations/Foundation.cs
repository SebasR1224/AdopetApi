using Domain.Common.ValueObjects;
using Domain.Foundations.Entities;
using Domain.Foundations.Enums;
using Domain.Foundations.ValueObjects;
using Domain.Images;
using Domain.Primitives;

namespace Domain.Foundations;

public sealed class Foundation : AggregateRoot<FoundationId>
{
    private readonly List<LegalRepresentative> _legalRepresentatives = [];
    public string Name { get; private set; }
    public string LegalName { get; private set; }
    public Image? Logo { get; private set; }
    public string Description { get; set; }
    public string Nit { get; private set; }
    public Location Location { get; private set; }
    public string Email { get; private set; }
    public string Website { get; private set; }
    public string PhoneNumber { get; private set; }
    public string? Mission { get; private set; }
    public string? Vission { get; private set; }
    public AverageRating AverageRating { get; private set; }
    public FoundationStatus Status { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public IReadOnlyList<LegalRepresentative> LegalRepresentatives => _legalRepresentatives.AsReadOnly();

    private Foundation(
        FoundationId foundationId,
        string name,
        string legalName,
        string description,
        string nit,
        Location location,
        string email,
        string website,
        string phoneNumber,
        string? mission,
        string? vission,
        AverageRating averageRating,
        FoundationStatus status,
        bool isActive,
        List<LegalRepresentative> legalRepresentatives

    ) : base(foundationId)
    {
        Name = name;
        LegalName = legalName;
        Description = description;
        Nit = nit;
        Location = location;
        Email = email;
        Website = website;
        PhoneNumber = phoneNumber;
        Mission = mission;
        Vission = vission;
        AverageRating = averageRating;
        Status = status;
        IsActive = isActive;
        _legalRepresentatives = legalRepresentatives;
    }
    public static Foundation Create(
        string name,
        string legalName,
        string description,
        string nit,
        Location location,
        string email,
        string website,
        string phoneNumber,
        string? mission,
        string? vission,
        List<LegalRepresentative> legalRepresentatives
    )
    {
        return new Foundation(
            FoundationId.CreateUnique(),
            name,
            legalName,
            description,
            nit,
            location,
            email,
            website,
            phoneNumber,
            mission,
            vission,
            AverageRating.CreateNew(),
            FoundationStatus.PendingRegistration,
            true,
            legalRepresentatives
        );
    }

    public void AddLogo(string url)
    {
        Logo = Image.Create(
            url,
            nameof(Foundation),
            Id.Value
        );
        UpdatedDateTime = DateTime.UtcNow;
    }


#pragma warning disable CS8618
    private Foundation() { }
#pragma warning restore CS8618
}