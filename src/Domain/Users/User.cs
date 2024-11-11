using Domain.Foundations.ValueObjects;
using Domain.Primitives;
using Domain.Users.Events;

namespace Domain.Users;

public sealed class User : AggregateRoot<UserId>
{
    private readonly int _emailVerificationTokenExpiryHours = 24;
    public string Name { get; private set; }
    public string LastName { get; private set; }
    public string? ProfilePicture { get; private set; }
    public string FullName => $"{Name} {LastName}";
    public string PersonalId { get; private set; }
    public DateOnly BirthDate { get; private set; }
    public string PhoneNumber { get; private set; }
    public string Address { get; private set; }
    public string Email { get; private set; }
    public string Username { get; private set; }
    public string Password { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsEmailVerified { get; private set; }
    public string EmailVerificationToken { get; private set; }
    public DateTime EmailVerificationTokenExpiry { get; private set; }
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
        string emailVerificationToken,
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
        EmailVerificationToken = emailVerificationToken;
        EmailVerificationTokenExpiry = DateTime.UtcNow.AddHours(_emailVerificationTokenExpiryHours);
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
        var user = new User(
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
            Guid.NewGuid().ToString(),
            foundationId
        );

        user.AddDomainEvent(new EmailVerificationTokenGeneratedEvent(
            user.Id,
            user.Email,
            user.EmailVerificationToken));

        return user;
    }

    public void AddProfilePicture(string url)
    {
        ProfilePicture = url;
        UpdatedDateTime = DateTime.UtcNow;
    }

#pragma warning disable CS8618
    private User() { }
#pragma warning restore CS8618
}