using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class PointRepository : Repository<Point, int>, IPointRepository
{
    public async Task<IEnumerable<Point>> GetByRecipientIdAsync(string recipientId)
    {
        return await DbSet.Where(x => x.RecipientId == recipientId).ToListAsync();
    }

    public async Task<IEnumerable<Point>> GetByReviewerIdAsync(string reviewerId)
    {
        return await DbSet.Where(x => x.ReviewerId == reviewerId).ToListAsync();
    }
}
