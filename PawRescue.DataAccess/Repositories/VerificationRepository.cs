using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class VerificationRepository : Repository<Verification, int>, IVerificationRepository
{
    public async Task<Verification?> GetByUserIdAsync(string userId)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.UserId == userId);
    }
}
