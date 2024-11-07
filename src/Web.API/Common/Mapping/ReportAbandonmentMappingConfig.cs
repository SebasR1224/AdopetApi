using Application.Abandonments.Commands.CreateReport;
using Contracts.Abandonment;
using Mapster;

namespace Web.API.Common.Mapping;

public class ReportAbandonmentMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(CreateReportAbandonmentRequest request, string reporterId), CreateReportAbandonmentCommand>()
            .Map(dest => dest.ReporterId, src => src.reporterId)
            .Map(dest => dest, src => src.request);
    }
}
