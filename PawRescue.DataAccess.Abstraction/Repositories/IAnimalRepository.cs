using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IAnimalRepository : IRepository<Animal, int>
{
}
