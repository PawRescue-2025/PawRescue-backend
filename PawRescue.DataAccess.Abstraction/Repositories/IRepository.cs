using System.Linq.Expressions;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IRepository<TEntity, in TKey> : IBaseRepository
{
    TEntity GetById(TKey id);

    Task<TEntity> GetByIdAsync(TKey id);

    ICollection<TEntity> GetAll();

    Task<ICollection<TEntity>> GetAllAsync();

    ICollection<TEntity> Find(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        IEnumerable<Expression<Func<TEntity, object>>> includes = null);

    Task<ICollection<TEntity>> FindAsync(
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        IEnumerable<Expression<Func<TEntity, object>>> includes = null);

    ICollection<TResult> FindAndMap<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        IEnumerable<Expression<Func<TEntity, object>>> includes = null);

    Task<ICollection<TResult>> FindAndMapAsync<TResult>(
        Expression<Func<TEntity, TResult>> selector,
        Expression<Func<TEntity, bool>> filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        IEnumerable<Expression<Func<TEntity, object>>> includes = null);

    Task<TResult> FindByKeyAndMapAsync<TResult>(
        Expression<Func<TEntity, bool>> keyFilter,
        Expression<Func<TEntity, TResult>> selector,
        IEnumerable<Expression<Func<TEntity, object>>> includes = null);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter = null);

    void Add(TEntity entity);

    void AddRange(IEnumerable<TEntity> entities);

    void Update(TEntity entity);

    void Remove(TEntity entity);

    void RemoveRange(IEnumerable<TEntity> entities);
}
