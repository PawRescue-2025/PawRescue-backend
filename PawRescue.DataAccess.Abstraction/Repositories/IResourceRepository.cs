using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IResourceRepository : IRepository<Resource, int>
{
    Task<IEnumerable<Resource>> GetAllByShelterIdAsync(int shelterId);
}
