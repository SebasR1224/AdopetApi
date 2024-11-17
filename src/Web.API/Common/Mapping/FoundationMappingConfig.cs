namespace Web.API.Common.Mapping;

using Domain.Foundations;
using Contracts.Foundation;
using Mapster;
using Domain.Foundations.Entities;

public class FoundationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Foundation, FoundationResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Address, src => src.Location.ToString())
            .Map(dest => dest.AverageRating, src => src.AverageRating.NumRatings > 0 ? src.AverageRating.Value : 0);

        config.NewConfig<LegalRepresentative, LegalRepresentativeResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
