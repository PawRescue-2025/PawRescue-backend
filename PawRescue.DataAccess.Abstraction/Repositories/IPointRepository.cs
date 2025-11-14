using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IPointRepository : IRepository<Point, int>
{
    Task<IEnumerable<Point>> GetByRecipientIdAsync(string recipientId);
    Task<IEnumerable<Point>> GetByReviewerIdAsync(string reviewerId);
}
