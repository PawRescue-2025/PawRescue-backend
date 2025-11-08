using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Repositories;

public class PointRepository : Repository<Point, int>, IPointRepository
{
}
