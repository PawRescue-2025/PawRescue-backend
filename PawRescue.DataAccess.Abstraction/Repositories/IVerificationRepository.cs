using PawRescue.Domain.Entities;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IVerificationRepository : IRepository<Verification, int>
{
    Task<Verification?> GetByUserIdAsync(string userId);
}
