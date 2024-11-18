using Application.Common.Commands;
using Contracts.Abandonment;
using Contracts.Common;
using Domain.Abandonments;
using Domain.Abandonments.Entities;
using Domain.Animals;
using Mapster;

namespace Web.API.Common.Mapping;

public class ReportAbandonmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LocationRequest, LocationCommand>()
            .Map(dest => dest.Latitude, src => src.Latitude)
            .Map(dest => dest.Longitude, src => src.Longitude);

        config.NewConfig<ReportAbandonment, ReportAbandonmentResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Address, src => src.Location.ToString())
            .Map(dest => dest.FoundationId, src => src.FoundationId!.Value)
            .Map(dest => dest.Images, src => src.Images.Select(image => image.Url).ToList());

        config.NewConfig<Animal, AnimalReportAbandonmentResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Images, src => src.Images.Select(image => image.Url).ToList());

        config.NewConfig<Reporter, ReporterResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
