using Domain.FileRecords;
using Domain.FileRecords.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class FileRecordConfiguration : IEntityTypeConfiguration<FileRecord>
{
    public void Configure(EntityTypeBuilder<FileRecord> builder)
    {
        builder.ToTable("FileRecords");

        builder.HasKey(fr => fr.Id);

        builder.Property(fr => fr.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FileRecordId.Create(value));

        builder.Property(fr => fr.FileName)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(fr => fr.Url)
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(f => f.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(f => f.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}