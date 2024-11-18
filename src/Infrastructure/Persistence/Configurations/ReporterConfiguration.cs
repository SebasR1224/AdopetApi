using Domain.Abandonments.Entities;
using Domain.Abandonments.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;
public class ReporterConfiguration : IEntityTypeConfiguration<Reporter>
{
    public void Configure(EntityTypeBuilder<Reporter> builder)
    {
        builder.ToTable("Reporters");

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ReporterId.Create(value));

        builder.Property(r => r.Name)
            .HasMaxLength(100);

        builder.Property(r => r.LastName)
            .HasMaxLength(100);

        builder.Property(r => r.Email)
            .HasMaxLength(100);

        builder.Property(r => r.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(r => r.IsAnonymous);

        builder.Property(r => r.IsActive);

        builder.Ignore(r => r.FullName);

        builder.Property(r => r.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(r => r.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}