using Application.Abandonments.Commands.CreateReport;
using Application.Abandonments.Commands.UpdateReportStatus;
using Contracts.Abandonment;
using Domain.Abandonments;
using Domain.Abandonments.Entities;
using Domain.Animals;
using Mapster;

namespace Web.API.Common.Mapping;

public class ReportAbandonmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateReportAbandonmentRequest request, string reporterId), CreateReportAbandonmentCommand>()
            .Map(dest => dest, src => src.request);

        config.NewConfig<ReportAbandonment, ReportAbandonmentResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Address, src => src.Location.ToString())
            .Map(dest => dest.FoundationId, src => src.FoundationId!.Value);

        config.NewConfig<Animal, AnimalResponse>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Specie, src => src.Specie.Name);

        config.NewConfig<Reporter, ReporterResponse>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
