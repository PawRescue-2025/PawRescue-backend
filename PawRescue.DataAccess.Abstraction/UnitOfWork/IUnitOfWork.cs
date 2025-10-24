using PawRescue.DataAccess.Abstraction.Repositories;

namespace PawRescue.DataAccess.Abstraction.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync();
    T GetRepository<T>() where T : class, IBaseRepository;
}
