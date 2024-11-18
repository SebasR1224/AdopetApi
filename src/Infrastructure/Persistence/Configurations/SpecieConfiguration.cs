using Domain.Animals.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public sealed class SpecieConfiguration : IEntityTypeConfiguration<Specie>
{
    public void Configure(EntityTypeBuilder<Specie> builder)
    {
        builder.ToTable("Species");
        builder.HasKey(specie => specie.Id);

        builder.Property(specie => specie.Id)
        .ValueGeneratedOnAdd();

        builder.Property(specie => specie.Value)
            .HasMaxLength(100)
            .IsRequired();

        builder.OwnsMany(specie => specie.Breeds, bb =>
        {
            bb.ToTable("Breeds");

            bb.Property<int>("Id")
                .ValueGeneratedOnAdd();
            bb.HasKey("Id");

            bb.WithOwner().HasForeignKey("SpecieId");
            bb.Property(breed => breed.Value)
                .HasMaxLength(100)
                .IsRequired();
        });
    }

}
