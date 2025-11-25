using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class PostRepository : Repository<Post, int>, IPostRepository
{
    public async Task<IEnumerable<Post>> GetAllActiveAsync()
    {
        return await DbSet
                        .Where(p => p.Status == Domain.Enum.EntityStatus.Active)
                        .OrderByDescending(p => p.CreationDate)
                        .ToListAsync();
    }

    public async Task<IEnumerable<Post>> GetAllByUserIdAsync(string userId)
    {
        return await DbSet.Where(p => p.UserId == userId && p.Status == Domain.Enum.EntityStatus.Active).OrderByDescending(p => p.CreationDate)
                        .ToListAsync();
    }
}
