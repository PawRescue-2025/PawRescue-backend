using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.DataAccess.UnitOfWork;
using PawRescue.Domain.MappingProfiles;
using PawRescue.Services.Abstraction.Identity;
using PawRescue.Services.Identity;

namespace PawRescue.API.Extensions;

public static class DependencyInjectionConfig
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
         RegisterDataAccess(services);

         RegisterServices(services);

         RegisterExternalConfigs(services);
    }

    private static void RegisterServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
    }

    private static void RegisterDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();
    }

    private static void RegisterExternalConfigs(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IdentityMappingProfile).Assembly);
    }
}
