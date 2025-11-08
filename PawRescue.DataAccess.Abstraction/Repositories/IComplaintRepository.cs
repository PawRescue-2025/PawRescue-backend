using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IComplaintRepository : IRepository<Complaint, int>
{
}
