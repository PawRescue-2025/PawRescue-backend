using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IReportRepository : IRepository<Report, int>
{
    Task<Report?> GetByPostIdAsync(int postId);
}
