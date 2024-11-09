using Domain.Animals.Enums;
using Domain.Animals.ValueObjects;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Animals;

public sealed class Animal : AggregateRoot<AnimalId>
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Image { get; private set; }
    public int? Age { get; private set; }
    public string CoatColor { get; private set; }
    public decimal? Weight { get; private set; }
    public string Specie { get; private set; }
    public string? Breed { get; private set; }
    public AnimalStatus Status { get; private set; }
    public AnimalGender Gender { get; private set; }
    public FoundationId? FoundationId { get; private set; }
    public DateTime CreatedDateTime { get; private set; }
    public DateTime UpdatedDateTime { get; private set; }

    private Animal(
        AnimalId animalId,
        string name,
        string description,
        string image,
        int? age,
        string coatColor,
        decimal? weight,
        string specie,
        string? breed,
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
            specie,
            breed,
            AnimalStatus.Abandoned,
            gender
        );
    }

#pragma warning disable CS8618
    private Animal() { }
#pragma warning restore CS8618

}