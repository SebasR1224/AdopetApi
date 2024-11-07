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
    public int Age { get; }
    public string CoatColor { get; }
    public float Weight { get; }
    public SpecieId SpecieId { get; }
    public BreedId BreedId { get; }
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
        int age,
        string coatColor,
        float weight,
        SpecieId specieId,
        BreedId breedId,
        AnimalStatus status,
        AnimalGender gender,
        FoundationId? foundationId,
        DateTime createdDateTime,
        DateTime updatedDateTime)
       : base(animalId)
    {
        Name = name;
        Description = description;
        Image = image;
        Age = age;
        CoatColor = coatColor;
        Weight = weight;
        SpecieId = specieId;
        BreedId = breedId;
        Status = status;
        Gender = gender;
        FoundationId = foundationId;
        CreateDateTime = createdDateTime;
        UpdateDateTime = updatedDateTime;
    }

    public static Animal Create(
        string name,
        string description,
        string image,
        int age,
        string coatColor,
        float weight,
        SpecieId specieId,
        BreedId breedId,
        AnimalGender gender,
        FoundationId? foundationId
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
            specieId,
            breedId,
            AnimalStatus.Abandoned,
            gender,
            foundationId,
            DateTime.UtcNow,
            DateTime.UtcNow);
    }
}