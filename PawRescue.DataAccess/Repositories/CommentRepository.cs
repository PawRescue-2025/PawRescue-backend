using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class CommentRepository : Repository<Comment, int>, ICommentRepository
{
    public async Task<IEnumerable<Comment>> GetAllActiveAsync()
    {
        return await DbSet
                        .Where(c => c.Status == Domain.Enum.EntityStatus.Active)
                        .ToListAsync();
    }

    public async Task<IEnumerable<Comment>> GetAllByPostIdAsync(int postId)
    {
        return await DbSet
                        .Where(c => c.PostId == postId && c.Status == Domain.Enum.EntityStatus.Active)
                        .ToListAsync();
    }
}
