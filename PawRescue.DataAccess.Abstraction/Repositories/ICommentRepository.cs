using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface ICommentRepository : IRepository<Comment, int>
{
    Task<IEnumerable<Comment>> GetAllActiveAsync();
    Task<IEnumerable<Comment>> GetAllByPostIdAsync(int postId);
}
