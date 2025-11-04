using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.DataAccess.Repositories;
using PawRescue.DataAccess.UnitOfWork;
using PawRescue.Domain.MappingProfiles;
using PawRescue.Services.Abstraction.Animal;
using PawRescue.Services.Abstraction.Identity;
using PawRescue.Services.Abstraction.Shelter;
using PawRescue.Services.Abstraction.Verifications;
using PawRescue.Services.Animals;
using PawRescue.Services.Identity;
using PawRescue.Services.Shelters;
using PawRescue.Services.Verifications;

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
        services.AddTransient<IAnimalService, AnimalService>();
        services.AddTransient<IShelterService, ShelterService>();
        services.AddTransient<IVerificationService, VerificationService>();
    }

    private static void RegisterDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

        services.AddTransient<IAnimalRepository, AnimalRepository>();
        services.AddTransient<IShelterRepository, ShelterRepository>();
        services.AddTransient<IVerificationRepository, VerificationRepository>();
    }

    private static void RegisterExternalConfigs(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IdentityMappingProfile).Assembly);
    }
}
