using Domain.PasswordRecovery;
using Domain.PasswordRecovery.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class PasswordRecoveryTokenConfiguration : IEntityTypeConfiguration<PasswordRecoveryToken>
{
    public void Configure(EntityTypeBuilder<PasswordRecoveryToken> builder)
    {
        builder.ToTable("PasswordRecoveryTokens");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .HasConversion(
                id => id.Value,
                value => PasswordRecoveryTokenId.Create(value));

        builder.Property(x => x.Token)
            .IsRequired()
            .HasMaxLength(255);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(x => x.ExpirationDate)
            .IsRequired();

        builder.Property(x => x.IsUsed)
            .IsRequired();
    }
}