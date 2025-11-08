using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class UsefulLinkRepository : Repository<UsefulLink, int>, IUsefulLinkRepository
{
}
