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

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ReporterId.Create(value));

        builder.Property(x => x.Name)
            .HasMaxLength(100);

        builder.Property(x => x.LastName)
            .HasMaxLength(100);

        builder.Property(x => x.Email)
            .HasMaxLength(255);

        builder.Property(x => x.PhoneNumber)
            .HasMaxLength(20);

        builder.Property(x => x.IsAnonymous);

        builder.Property(x => x.IsActive);

        builder.Ignore(x => x.FullName);
    }
}