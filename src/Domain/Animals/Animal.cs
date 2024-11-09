using Domain.Animals.Entities;
using Domain.Animals.Enums;
using Domain.Animals.ValueObjects;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Animals;

public sealed class Animal : AggregateRoot<AnimalId>
{
    public string Name { get; }
    public string Description { get; }
    public string Image { get; }
    public int? Age { get; }
    public string CoatColor { get; }
    public decimal? Weight { get; }
    public Specie Specie { get; }
    public Breed? Breed { get; }
    public AnimalStatus Status { get; }
    public AnimalGender Gender { get; }
    public FoundationId? FoundationId { get; }
    public DateTime CreateDateTime { get; }
    public DateTime UpdateDateTime { get; }

    private Animal(
        AnimalId animalId,
        string name,
        string description,
        string image,
        int? age,
        string coatColor,
        decimal? weight,
        Specie specie,
        Breed? breed,
        AnimalStatus status,
        AnimalGender gender)
       : base(animalId)
    {
        Name = name;
        Description = description;
        Image = image;
        Age = age;
        CoatColor = coatColor;
        Weight = weight;
        Specie = specie;
        Breed = breed;
        Status = status;
        Gender = gender;
    }

    public static Animal Create(
        string name,
        string description,
        string image,
        int? age,
        string coatColor,
        decimal? weight,
        string specie,
        string? breed,
        AnimalGender gender
    )
    {
        return new Animal(
            AnimalId.CreateUnique(),
            name,
            description,
            image,
            age,
            coatColor,
            weight,
            Specie.Create(specie),
            Breed.Create(breed),
            AnimalStatus.Abandoned,
            gender
        );
    }

#pragma warning disable CS8618
    private Animal() { }
#pragma warning restore CS8618

}