using Domain.Abandonments;
using Domain.Abandonments.Enums;
using Domain.Abandonments.ValueObjects;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class ReportAbandonmentConfiguration : IEntityTypeConfiguration<ReportAbandonment>
{
    public void Configure(EntityTypeBuilder<ReportAbandonment> builder)
    {
        ConfigureReportAbandonment(builder);
    }

    private static void ConfigureReportAbandonment(EntityTypeBuilder<ReportAbandonment> builder)
    {
        builder.ToTable("ReportAbandonments");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ReportAbandonmentId.Create(value));

        builder.Property(r => r.Title)
            .HasMaxLength(100);

        builder.Property(r => r.Description)
            .HasColumnType("text");

        builder.Property(a => a.Status)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (ReportStatus)Enum.Parse(typeof(ReportStatus), v));

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

        builder.Ignore(r => r.AbandonmentDuration);

        builder.Property(a => a.AbandonmentStatus)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (AbandonmentStatus)Enum.Parse(typeof(AbandonmentStatus), v));

        builder.Property(r => r.ResponseTime)
            .IsRequired(false);

        builder.Property(r => r.FoundationId)
            .HasConversion(
                id => id!.Value,
                value => FoundationId.Create(value)
            ).IsRequired(false);
    }
}
