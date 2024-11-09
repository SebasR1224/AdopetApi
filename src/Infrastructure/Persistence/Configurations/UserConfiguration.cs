using Domain.Foundations;
using Domain.Foundations.ValueObjects;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(u => u.Id);

        builder.Property(x => x.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => UserId.Create(value));

        builder.Property(u => u.Name)
            .HasMaxLength(100);

        builder.Property(u => u.LastName)
            .HasMaxLength(100);

        builder.Property(u => u.PersonalId)
            .HasMaxLength(20);

        builder.Property(u => u.BirthDate)
            .HasColumnType("date");

        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(u => u.Address)
            .HasMaxLength(200);

        builder.Property(u => u.Email)
            .HasMaxLength(100);

        builder.Property(u => u.Username)
            .HasMaxLength(50);

        builder.Property(u => u.Password)
            .HasMaxLength(255);

        builder.Property(u => u.IsActive)
            .HasDefaultValue(true);

        builder.HasOne<Foundation>()
           .WithMany()
           .HasForeignKey(a => a.FoundationId)
           .IsRequired(false)
           .OnDelete(DeleteBehavior.NoAction);

        builder.Property(r => r.FoundationId)
            .HasConversion(
                id => id!.Value,
                value => FoundationId.Create(value)
            ).IsRequired(false);

        builder.Property(x => x.CreatedDateTime)
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(x => x.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.HasIndex(u => u.Username).IsUnique();
        builder.HasIndex(u => u.Email).IsUnique();
        builder.HasIndex(u => u.PersonalId).IsUnique();
    }
}