using Domain.Animals.Entities;
using Domain.Animals.Enums;
using Domain.Animals.ValueObjects;
using Domain.Foundations.ValueObjects;
using Domain.Primitives;

namespace Domain.Animals;

public sealed class Animal : AggregateRoot<AnimalId>
{
    private readonly List<AnimalImage> _images = [];
    public string Name { get; private set; }
    public string Description { get; private set; }
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

    public IReadOnlyCollection<AnimalImage> Images => _images.AsReadOnly();

    private Animal(
        AnimalId animalId,
        string name,
        string description,
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
        Age = age;
        CoatColor = coatColor;
        Weight = weight;
        Specie = specie;
        Breed = breed;
        Status = status;
        Gender = gender;
    }

    public static Animal Create(
        string? name,
        string description,
        string? image,
        int? age,
        string coatColor,
        decimal? weight,
        string specie,
        string? breed,
        AnimalGender gender
    )
    {

        var animal = new Animal(
            AnimalId.CreateUnique(),
            name ?? $"{specie} {coatColor}",
            description,
            age,
            coatColor,
            weight,
            specie,
            breed,
            AnimalStatus.Abandoned,
            gender
        );

        if (image is not null) animal.AddImage(image);

        return animal;
    }

    public void AddImage(string url)
    {
        _images.Add(AnimalImage.Create(url));
    }


#pragma warning disable CS8618
    private Animal() { }
#pragma warning restore CS8618

}