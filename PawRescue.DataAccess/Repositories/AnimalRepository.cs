using Microsoft.EntityFrameworkCore;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class AnimalRepository : Repository<Animal, int>, IAnimalRepository
{
    public async Task<IEnumerable<Animal>> GetByShelterIdAsync(int shelterId)
    {
        return await DbSet.Where(a => a.ShelterId == shelterId).ToListAsync();
    }
}
