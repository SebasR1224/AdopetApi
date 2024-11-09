using Domain.Files.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DomainFile = Domain.Files.File;

namespace Infrastructure.Persistence.Configurations;


public class ImageConfiguration : IEntityTypeConfiguration<DomainFile>
{
    public void Configure(EntityTypeBuilder<DomainFile> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => FileId.Create(value));

        builder.Property(x => x.Url)
            .HasMaxLength(2048)
            .IsRequired();

        builder.Property(x => x.FileableType)
            .HasMaxLength(255)
            .IsRequired();

        builder.Property(x => x.FileableId)
            .HasMaxLength(255)
            .IsRequired();

        builder.HasIndex(x => new { x.FileableType, x.FileableId });
    }
}