using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class ShelterRepository : Repository<Shelter, int>, IShelterRepository
{
    public Task<Shelter?> GetByOwnerIdAsync(string ownerId)
    {
        return DbSet.FirstOrDefaultAsync(x => x.OwnerId == ownerId);
    }
}
