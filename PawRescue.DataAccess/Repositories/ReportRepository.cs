using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class ReportRepository : Repository<Report, int>, IReportRepository
{
    public async Task<Report?> GetByPostIdAsync(int postId)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.PostId == postId);
    }
}
