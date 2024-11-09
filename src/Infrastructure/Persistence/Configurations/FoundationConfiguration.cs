using Domain.Foundations;
using Domain.Foundations.Enums;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class FoundationConfiguration : IEntityTypeConfiguration<Foundation>
{

    public void Configure(EntityTypeBuilder<Foundation> builder)
    {
        ConfigureFoundation(builder);
        ConfigureLegalRepresentative(builder);
    }

    private static void ConfigureFoundation(EntityTypeBuilder<Foundation> builder)
    {
        builder.ToTable("Foundations");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FoundationId.Create(value));

        builder.Property(f => f.Name)
            .HasMaxLength(100);

        builder.Property(f => f.LegalName)
            .HasMaxLength(100);

        builder.Property(f => f.Logo)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(f => f.Description)
            .HasColumnType("text");

        builder.Property(f => f.Nit)
            .HasMaxLength(20);

        builder.OwnsOne(f => f.Location, locationBuilder =>
        {
            locationBuilder.Property(l => l.Latitude).HasColumnType("double precision");
            locationBuilder.Property(l => l.Longitude).HasColumnType("double precision");
            locationBuilder.Property(l => l.Address).HasMaxLength(255);
            locationBuilder.Property(l => l.City).HasMaxLength(100);
            locationBuilder.Property(l => l.PostalCode)
                .HasMaxLength(10)
                .IsRequired(false);
        });

        builder.Property(f => f.Email)
            .HasMaxLength(100);

        builder.Property(f => f.Website)
            .HasMaxLength(255);

        builder.Property(f => f.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(f => f.Mission)
            .HasColumnType("text")
            .IsRequired(false);

        builder.Property(f => f.Vission)
            .HasColumnType("text")
            .IsRequired(false);

        builder.OwnsOne(f => f.AverageRating);

        builder.Property(f => f.Status)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (FoundationStatus)Enum.Parse(typeof(FoundationStatus), v));

        builder.Property(f => f.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(f => f.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        // Índices
        builder.HasIndex(f => f.LegalName).IsUnique();
        builder.HasIndex(f => f.Email).IsUnique();
        builder.HasIndex(f => f.Nit).IsUnique();
    }

    public void ConfigureLegalRepresentative(EntityTypeBuilder<Foundation> builder)
    {
        builder.OwnsMany(f => f.LegalRepresentatives, lb =>
        {
            lb.ToTable("LegalRepresentatives");
            lb.WithOwner().HasForeignKey("FoundationId");


            lb.HasKey(lr => lr.Id);

            lb.Property(lr => lr.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => LegalRepresentativeId.Create(value));

            lb.Property(lr => lr.Name)
                .HasMaxLength(100)
                .IsRequired();

            lb.Property(lr => lr.LastName)
                .HasMaxLength(100)
                .IsRequired();

            lb.Property(lr => lr.PersonalId)
                .HasMaxLength(20)
                .IsRequired();

            lb.Property(lr => lr.Email)
                .HasMaxLength(100)
                .IsRequired();

            lb.Property(lr => lr.PhoneNumber)
                .HasMaxLength(20)
                .IsRequired();

            lb.Property(lr => lr.Address)
                .HasMaxLength(200)
                .IsRequired();

            lb.Property(lr => lr.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

            lb.Property(lr => lr.UpdatedDateTime)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        });
    }
}