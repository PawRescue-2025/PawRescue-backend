using PawRescue.Domain.Dtos.Comment;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Comments;

public interface ICommentService
{
    Task<Result> CreateAsync(CreateCommentDTO createDto);
    Task<Result<GridCommentDTO>> UpdateAsync(StatusCommentDTO statusCommentDTO);
    Task<Result<IEnumerable<GridCommentDTO>>> GetAllAsync();
    Task<Result<IEnumerable<GridCommentDTO>>> GetAllByPostIdAsync(int postId);
    Task<Result<GridCommentDTO>> GetByIdAsync(int id);
    Task<Result> DeleteAsync(int id);
}
