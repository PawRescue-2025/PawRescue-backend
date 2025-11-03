using PawRescue.Domain.Dtos.Shelter;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Shelter;

public interface IShelterService
{
    Task<Result> CreateAsync(CreateShelterDTO createDto);
}
