using PawRescue.Domain.Dtos.Animal;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Animal;

public interface IAnimalService
{
    Task<Result> CreateAsync(CreateAnimalDTO createDto);
    Task<Result<GridAnimalDTO>> UpdateAsync(UpdateAnimalDTO updateDto);
    Task<Result<IEnumerable<GridAnimalDTO>>> GetAllAsync();
    Task<Result<GridAnimalDTO>> GetByIdAsync(int id);
    Task<Result<IEnumerable<GridAnimalDTO>>> GetByShelterIdAsync(int shelterId);
    Task<Result> DeleteAsync(int id);
}
