namespace Web.API.Common.Mapping;

using Mapster;
using Contracts.Animals;
using Domain.Animals;

public class AnimalMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Animal, AnimalResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Images, src => src.Images.Select(i => i.Url));
    }
}
