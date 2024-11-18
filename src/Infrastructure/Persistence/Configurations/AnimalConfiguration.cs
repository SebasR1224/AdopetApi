using Domain.Animals;
using Domain.Animals.Entities;
using Domain.Animals.Enums;
using Domain.Animals.ValueObjects;
using Domain.Foundations;
using Domain.Foundations.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class AnimalConfiguration : IEntityTypeConfiguration<Animal>
{
    public void Configure(EntityTypeBuilder<Animal> builder)
    {
        ConfigureAnimal(builder);
        ConfigureAnimalImage(builder);
    }

    private static void ConfigureAnimal(EntityTypeBuilder<Animal> builder)
    {
        builder.ToTable("Animals");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AnimalId.Create(value));

        builder.Property(a => a.Name)
                .HasMaxLength(100);

        builder.Property(a => a.Description)
                .HasColumnType("text");

        builder.Property(a => a.Age)
                .HasColumnType("integer")
                .IsRequired(false);

        builder.Property(a => a.CoatColor)
                .HasMaxLength(100);

        builder.Property(a => a.Weight)
                .HasColumnType("decimal(10, 2)")
                .IsRequired(false);

        builder.Property(a => a.Specie)
            .HasMaxLength(100);

        builder.Property(a => a.Breed)
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(a => a.Status)
           .HasMaxLength(50)
           .HasConversion(
               v => v.ToString(),
               v => (AnimalStatus)Enum.Parse(typeof(AnimalStatus), v));


        builder.Property(a => a.Gender)
            .HasMaxLength(50)
            .HasConversion(
                v => v.ToString(),
                v => (AnimalGender)Enum.Parse(typeof(AnimalGender), v))
                .HasMaxLength(10);

        builder.Property(a => a.FoundationId)
            .HasConversion(
                id => id!.Value,
                value => FoundationId.Create(value)
            ).IsRequired(false);

        builder.HasOne<Foundation>()
            .WithMany()
            .HasForeignKey(a => a.FoundationId)
            .IsRequired(false)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(a => a.CreatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Property(a => a.UpdatedDateTime)
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        builder.Metadata.FindNavigation(nameof(Animal.Images))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);

        builder.Metadata.FindNavigation(nameof(Animal.Images))!
            .SetPropertyAccessMode(PropertyAccessMode.Field);
    }

    private static void ConfigureAnimalImage(EntityTypeBuilder<Animal> builder)
    {
        builder.OwnsMany(a => a.Images, ib =>
        {
            ib.ToTable("AnimalImages");

            ib.HasKey(i => i.Id);

            ib.WithOwner()
                .HasForeignKey("AnimalId");

            ib.Property(i => i.Id)
                .ValueGeneratedNever()
                .HasConversion(
                    id => id.Value,
                    value => AnimalImageId.Create(value));

            ib.Property(i => i.Url)
                .HasMaxLength(2048);
        });
    }
}