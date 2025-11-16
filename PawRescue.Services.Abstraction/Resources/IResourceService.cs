using PawRescue.Domain.Dtos.Resource;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Resources;

public interface IResourceService
{
    Task<Result<GridResourceDTO>> CreateAsync(CreateResourceDTO createDto);
    Task<Result> DeleteAsync(int id);
    Task<Result<IEnumerable<GridResourceDTO>>> GetAllAsync();
    Task<Result<IEnumerable<GridResourceDTO>>> GetAllByShelterIdAsync(int shelterId);
    Task<Result<GridResourceDTO>> GetByIdAsync(int id);
    Task<Result<GridResourceDTO>> ToggleIsPresentAsync(int id);
    Task<Result<GridResourceDTO>> UpdateDescriptionAsync(DescriptionResourceDTO resourceDTO);
}
