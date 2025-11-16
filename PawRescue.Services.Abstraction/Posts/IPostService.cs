using PawRescue.Domain.Dtos.Post;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Posts;

public interface IPostService
{
    Task<Result<GridPostDTO>> CreateAsync(CreatePostDTO createDto);
    Task<Result<GridPostDTO>> UpdateAsync(UpdatePostDTO updateDto);
    Task<Result<GridPostDTO>> UpdateAsync(StatusPostDTO statusPostDTO);
    Task<Result<GridPostDTO>> SetHelpRequestAsync(int id);
    Task<Result<IEnumerable<GridPostDTO>>> GetAllAsync();
    Task<Result<IEnumerable<GridPostDTO>>> GetAllByUserIdAsync(string userId);
    Task<Result<GridPostDTO>> GetByIdAsync(int id);
    Task<Result> DeleteAsync(int id);
}
