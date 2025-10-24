using Microsoft.Extensions.DependencyInjection;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.DataAccess.Contexts;

namespace PawRescue.DataAccess.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly PawRescueContext context;
    private readonly IServiceProvider serviceProvider;
    private readonly Dictionary<string, object> repositories;

    public UnitOfWork(PawRescueContext context, IServiceProvider serviceProvider)
    {
        this.context = context;
        this.serviceProvider = serviceProvider;
        this.repositories = new Dictionary<string, object>();
    }

    public void Commit()
    {
        context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await context.SaveChangesAsync();
    }

    public void Dispose()
    {
        context.Dispose();
        repositories.Clear();
    }

    T IUnitOfWork.GetRepository<T>()
    {
        var typeName = typeof(T).Name;

        if (!repositories.ContainsKey(typeName))
        {
            T instance = serviceProvider.GetService<T>();
            instance.SetContext(this.context);
            this.repositories.Add(typeName, instance);
        }
        
        return (T)repositories[typeName];
    }
}
