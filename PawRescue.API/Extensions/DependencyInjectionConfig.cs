using PawRescue.Domain.MappingProfiles;
using PawRescue.Services.Abstraction.Identity;
using PawRescue.Services.Identity;

namespace PawRescue.API.Extensions;

public static class DependencyInjectionConfig
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();

        services.AddAutoMapper(typeof(IdentityMappingProfile).Assembly);
    } 
}
