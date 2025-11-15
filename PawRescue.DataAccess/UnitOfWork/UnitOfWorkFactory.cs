using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.DataAccess.Contexts;

namespace PawRescue.DataAccess.UnitOfWork;

public class UnitOfWorkFactory(IServiceProvider serviceProvider, IConfiguration configuration) : IUnitOfWorkFactory
{
    private readonly IServiceProvider serviceProvider = serviceProvider;
    private readonly IConfiguration configuration = configuration;

    public IUnitOfWork CreateUnitOfWork()
    {
        var context = CreateDbContext();
        var unitOfWork = new UnitOfWork(context, serviceProvider);

        return unitOfWork;
    }

    private PawRescueContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<PawRescueContext>()
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .Options;

        return new PawRescueContext(options);
    }
}
