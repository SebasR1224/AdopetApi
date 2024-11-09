using Domain.Files.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainFile = Domain.Files.File;

namespace Infrastructure.Persistence.Configurations;


public class ImageConfiguration : IEntityTypeConfiguration<DomainFile>
{
    public void Configure(EntityTypeBuilder<DomainFile> builder)
    {
        builder.ToTable("Files");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FileId.Create(value));

        builder.Property(f => f.Url)
            .HasMaxLength(2048);

        builder.Property(f => f.FileableType)
            .HasMaxLength(255);

        builder.Property(f => f.FileableId)
            .HasMaxLength(255);

        builder.HasIndex(f => new { f.FileableType, f.FileableId });

        builder.Property(f => f.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(f => f.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}