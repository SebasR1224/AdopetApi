using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Users;

public sealed class User : AggregateRoot<UserId>
{
    public string Name { get; }
    public string LastName { get; }
    public string FullName => $"{Name} {LastName}";
    public string PersonalId { get; }
    public DateOnly BirthDate { get; }
    public string PhoneNumber { get; }
    public string Address { get; }
    public string Email { get; }
    public string Username { get; }
    public string Password { get; }
    public bool Active { get; }
    public DateTime CreatedDateTime { get; }
    public DateTime UpdatedDateTime { get; }

    public FoundationId? FoundationId { get; }

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
        bool active,
        FoundationId? foundationId,
        DateTime createdDateTime,
        DateTime updatedDateTime
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
        Active = active;
        FoundationId = foundationId;
        CreatedDateTime = createdDateTime;
        UpdatedDateTime = updatedDateTime;
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
            foundationId,
            DateTime.UtcNow,
            DateTime.UtcNow
        );
    }


#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618
}