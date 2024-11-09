using Domain.Images;
using Domain.Images.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Persistence.Configurations;


public class ImageConfiguration : IEntityTypeConfiguration<Image>
{
    public void Configure(EntityTypeBuilder<Image> builder)
    {
        builder.ToTable("Images");

        builder.HasKey(f => f.Id);

        builder.Property(f => f.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ImageId.Create(value));

        builder.Property(f => f.Url)
            .HasMaxLength(2048);

        builder.Property(f => f.ImageableType)
            .HasMaxLength(255);

        builder.Property(f => f.ImageableId)
            .HasMaxLength(255);

        builder.HasIndex(f => new { f.ImageableType, f.ImageableId });

        builder.Property(f => f.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(f => f.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
}