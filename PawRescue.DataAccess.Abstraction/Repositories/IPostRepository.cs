using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IPostRepository : IRepository<Post, int>
{
    Task<IEnumerable<Post>> GetAllActiveAsync();
    Task<IEnumerable<Post>> GetAllByUserIdAsync(string userId);
}
