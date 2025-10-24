using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class ShelterRepository : Repository<Shelter, int>, IShelterRepository
{
}
