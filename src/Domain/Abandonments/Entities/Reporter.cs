using Domain.Abandonments.ValueObjects;
using Domain.Primitives;

namespace Domain.Abandonments.Entities;

public sealed class Reporter : Entity<ReporterId>
{
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{Name} {LastName}";
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public bool IsAnonymous { get; private set; }
    public bool IsActive { get; private set; }

    private Reporter(
        ReporterId reporterId,
        string name,
        string lastName,
        string email,
        string phoneNumber,
        bool isAnonymous,
        bool isActive
    ) : base(reporterId)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        PhoneNumber = phoneNumber;
        IsAnonymous = isAnonymous;
        IsActive = isActive;
    }

    public static Reporter Create(
        string name,
        string lastName,
        string email,
        string phoneNumber,
        bool isAnonymous
    )
    {
        return new Reporter(
            ReporterId.CreateUnique(),
            name,
            lastName,
            email,
            phoneNumber,
            isAnonymous,
            true
        );
    }

    public void Deactivate()
    {
        IsActive = false;
    }

#pragma warning disable CS8618
    private Reporter() { }
#pragma warning restore CS8618

}
