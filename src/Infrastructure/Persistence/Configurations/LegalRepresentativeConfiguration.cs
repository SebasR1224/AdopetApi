using Domain.Foundations.Entities;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class LegalRepresentativeConfiguration : IEntityTypeConfiguration<LegalRepresentative>
{
    public void Configure(EntityTypeBuilder<LegalRepresentative> builder)
    {
        builder.ToTable("LegalRepresentatives");

        builder.HasKey(lr => lr.Id);

        builder.Property(lr => lr.Id)
            .HasConversion(
                id => id.Value,
                value => LegalRepresentativeId.Create(value));

        builder.Property(lr => lr.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(lr => lr.LastName)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(lr => lr.PersonalId)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(lr => lr.Email)
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(lr => lr.PhoneNumber)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(lr => lr.Address)
            .HasMaxLength(200)
            .IsRequired();
    }
}