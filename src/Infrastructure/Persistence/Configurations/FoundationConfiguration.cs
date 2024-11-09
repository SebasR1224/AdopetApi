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
        builder.ToTable("Foundations");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FoundationId.Create(value));

        builder.Property(f => f.Name)
            .HasMaxLength(100);

        builder.Property(f => f.Logo)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.Property(f => f.Description)
            .HasColumnType("text");

        builder.Property(f => f.Nit)
            .HasMaxLength(20);

        builder.OwnsOne(r => r.Location, locationBuilder =>
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
            .HasColumnType("text");

        builder.Property(f => f.Vision)
            .HasColumnType("text");

        builder.OwnsOne(f => f.AverageRating);

        builder.Property(a => a.Status)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (FoundationStatus)Enum.Parse(typeof(FoundationStatus), v));

        // Índices
        builder.HasIndex(f => f.Name).IsUnique();
        builder.HasIndex(f => f.Email).IsUnique();
        builder.HasIndex(f => f.Nit).IsUnique();
    }
}