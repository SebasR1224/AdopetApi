using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Users;

public sealed class User : AggregateRoot<UserId>
{
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string FullName => $"{Name} {LastName}";
    public string PersonalId { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    public FoundationId? FoundationId { get; private set; }

    private User(
        UserId id,
        string name,
        string lastName,
        string personalId,
        DateOnly birthDate,
        string phoneNumber,
        string address,
        string email,
        string username,
        string password,
        bool isActive,
        FoundationId? foundationId
    ) : base(id)
    {
        Name = name;
        LastName = lastName;
        PersonalId = personalId;
        BirthDate = birthDate;
        PhoneNumber = phoneNumber;
        Address = address;
        Email = email;
        Username = username;
        Password = password;
        IsActive = isActive;
        FoundationId = foundationId;
    }

    public static User Create(
        string name,
        string lastName,
        string personalId,
        DateOnly birthDate,
        string phoneNumber,
        string address,
        string email,
        string username,
        string password,
        FoundationId? foundationId
    )
    {
        return new User(
            UserId.CreateUnique(),
            name,
            lastName,
            personalId,
            birthDate,
            phoneNumber,
            address,
            email,
            username,
            password,
            true,
            foundationId
        );
    }


#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618
}