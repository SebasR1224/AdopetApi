using Application.Authentication.Common;
using Contracts.Authentication;
using Mapster;

namespace Web.API.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Id, src => src.User.Id.Value)
            .Map(dest => dest.FoundationId, src => src.User.FoundationId.Value)
            .Map(dest => dest, src => src.User);
    }
}