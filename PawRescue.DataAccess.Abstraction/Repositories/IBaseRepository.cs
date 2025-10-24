using Microsoft.EntityFrameworkCore;

namespace PawRescue.DataAccess.Abstraction.Repositories;

public interface IBaseRepository
{
    void SetContext(DbContext context);
}
