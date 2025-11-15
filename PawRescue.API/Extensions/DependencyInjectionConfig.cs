using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.DataAccess.Repositories;
using PawRescue.DataAccess.UnitOfWork;
using PawRescue.Domain.MappingProfiles;
using PawRescue.Services.Abstraction.Animal;
using PawRescue.Services.Abstraction.Comments;
using PawRescue.Services.Abstraction.Complaints;
using PawRescue.Services.Abstraction.Identity;
using PawRescue.Services.Abstraction.Points;
using PawRescue.Services.Abstraction.Posts;
using PawRescue.Services.Abstraction.Reports;
using PawRescue.Services.Abstraction.Resources;
using PawRescue.Services.Abstraction.Shelter;
using PawRescue.Services.Abstraction.UsefulLinks;
using PawRescue.Services.Abstraction.Users;
using PawRescue.Services.Abstraction.Verifications;
using PawRescue.Services.Animals;
using PawRescue.Services.Comments;
using PawRescue.Services.Complaints;
using PawRescue.Services.Identity;
using PawRescue.Services.Points;
using PawRescue.Services.Posts;
using PawRescue.Services.Reports;
using PawRescue.Services.Resources;
using PawRescue.Services.Shelters;
using PawRescue.Services.UsefulLinks;
using PawRescue.Services.Users;
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
        services.AddTransient<IPostService, PostService>();
        services.AddTransient<ICommentService, CommentService>();
        services.AddTransient<IReportService, ReportService>();
        services.AddTransient<IComplaintService, ComplaintService>();
        services.AddTransient<IUsefulLinkService, UsefulLinkService>();
        services.AddTransient<IResourceService, ResourceService>();
        services.AddTransient<IPointService, PointService>();
        services.AddTransient<IUserProfileService, UserProfileService>();
    }

    private static void RegisterDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory>();

        services.AddTransient<IAnimalRepository, AnimalRepository>();
        services.AddTransient<IShelterRepository, ShelterRepository>();
        services.AddTransient<IVerificationRepository, VerificationRepository>();
        services.AddTransient<IPostRepository, PostRepository>();
        services.AddTransient<ICommentRepository, CommentRepository>();
        services.AddTransient<IReportRepository, ReportRepository>();
        services.AddTransient<IComplaintRepository, ComplaintRepository>();
        services.AddTransient<IUsefulLinkRepository, UsefulLinkRepository>();
        services.AddTransient<IResourceRepository, ResourceRepository>();
        services.AddTransient<IPointRepository, PointRepository>();
    }

    private static void RegisterExternalConfigs(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(IdentityMappingProfile).Assembly);
    }
}
