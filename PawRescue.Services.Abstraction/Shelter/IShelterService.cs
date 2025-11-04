using PawRescue.Domain.Dtos.Shelter;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Shelter;

public interface IShelterService
{
    Task<Result> CreateAsync(CreateShelterDTO createDto);
    Task<Result<GridShelterDTO>> UpdateAsync(UpdateShelterDTO updateDto);
    Task<Result<IEnumerable<GridShelterDTO>>> GetAllAsync()
    Task<Result<GridShelterDTO>> GetByIdAsync(int id);
    Task<Result> DeleteAsync(int id);
    
}
