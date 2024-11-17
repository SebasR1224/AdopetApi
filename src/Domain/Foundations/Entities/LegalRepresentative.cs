using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Foundations.Entities;

public class LegalRepresentative : Entity<LegalRepresentativeId>
{
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{Name} {LastName}";
    public string PersonalId { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private LegalRepresentative(
        LegalRepresentativeId legalRepresentativeId,
        string name,
        string lastName,
        string personalId,
        string email,
        string phoneNumber,
        string address
    ) : base(legalRepresentativeId)
    {
        Name = name;
        LastName = lastName;
        PersonalId = personalId;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
    }

    public static LegalRepresentative Create(
        string name,
        string lastName,
        string personalId,
        string email,
        string phoneNumber,
        string address
    )
    {
        return new LegalRepresentative(
            LegalRepresentativeId.CreateUnique(),
            name,
            lastName,
            personalId,
            email,
            phoneNumber,
            address
        );
    }
#pragma warning disable CS8618
    private LegalRepresentative() { }
#pragma warning restore CS8618
}
