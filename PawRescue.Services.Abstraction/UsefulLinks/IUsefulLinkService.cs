using PawRescue.Domain.Dtos.UsefulLink;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.UsefulLinks;

public interface IUsefulLinkService
{
    Task<Result> CreateAsync(CreateUsefulLinkDTO createDto);
    Task<Result> DeleteAsync(int id);
    Task<Result<IEnumerable<GridUsefulLinkDTO>>> GetAllAsync();
    Task<Result<GridUsefulLinkDTO>> GetByIdAsync(int id);
    Task<Result<GridUsefulLinkDTO>> UpdateAsync(UpdateUsefulLinkDTO updateDto);
}
