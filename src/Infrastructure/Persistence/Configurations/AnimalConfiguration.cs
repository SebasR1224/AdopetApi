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
        builder.ToTable("Animals");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => AnimalId.Create(value));

        builder.Property(a => a.Name)
                .HasMaxLength(100);

        builder.Property(a => a.Description)
                .HasColumnType("text");

        builder.Property(a => a.Image)
                .HasMaxLength(255);

        builder.Property(a => a.Age)
                .HasColumnType("integer")
                .IsRequired(false);

        builder.Property(a => a.CoatColor)
                .HasMaxLength(100);

        builder.Property(a => a.Weight)
                .HasColumnType("decimal(10, 2)")
                .IsRequired(false);

        builder.Property(a => a.Specie)
            .HasConversion(
                specie => specie.Name,
                value => Specie.Create(value)
            )
            .HasMaxLength(100)
            .IsRequired(false);

        builder.Property(a => a.Breed)
            .HasConversion(
                breed => breed!.Name,
                value => Breed.Create(value)
            )
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
                v => (AnimalGender)Enum.Parse(typeof(AnimalGender), v));

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
    }
}