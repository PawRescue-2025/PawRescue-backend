using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class ResourceRepository : Repository<Resource, int>, IResourceRepository
{
    public async Task<IEnumerable<Resource>> GetAllByShelterIdAsync(int shelterId)
    {
        return await DbSet.Where(x => x.ShelterId == shelterId).ToListAsync();
    }
}
