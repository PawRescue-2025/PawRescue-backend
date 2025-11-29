using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IShelterRepository : IRepository<Shelter, int>
{
    Task<Shelter?> GetByOwnerIdAsync(string ownerId);
}
