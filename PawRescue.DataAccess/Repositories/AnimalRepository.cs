using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class AnimalRepository : Repository<Animal, int>, IAnimalRepository
{
}
