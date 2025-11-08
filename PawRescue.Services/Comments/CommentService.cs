using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Comment;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Comments;

namespace PawRescue.Services.Comments;

public class CommentService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : ICommentService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result> CreateAsync(CreateCommentDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<ICommentRepository>();

        var postEntity = mapper.Map<Comment>(createDto);

        repository.Add(postEntity);

        await uow.CommitAsync();

        return Result.Success();
    }

    public async Task<Result<GridCommentDTO>> UpdateAsync(StatusCommentDTO statusCommentDTO)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<ICommentRepository>();
        var existingComment = await repository.GetByIdAsync(statusCommentDTO.Id);

        if (existingComment == null)
        {
            var error = new Error("System.NotFound", "There is no comment with this id.");
            return Result<GridCommentDTO>.Failure(error);
        }

        mapper.Map(statusCommentDTO, existingComment);

        repository.Update(existingComment);

        await uow.CommitAsync();

        return Result<GridCommentDTO>.Success(mapper.Map<GridCommentDTO>(existingComment));
    }

    public async Task<Result<IEnumerable<GridCommentDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<ICommentRepository>();

        var comments = await repository.GetAllActiveAsync();

        return Result<IEnumerable<GridCommentDTO>>.Success(mapper.Map<IEnumerable<GridCommentDTO>>(comments));
    }

    public async Task<Result<IEnumerable<GridCommentDTO>>> GetAllByPostIdAsync(int postId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<ICommentRepository>();

        var comments = await repository.GetAllByPostIdAsync(postId);

        return Result<IEnumerable<GridCommentDTO>>.Success(mapper.Map<IEnumerable<GridCommentDTO>>(comments));
    }

    public async Task<Result<GridCommentDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<ICommentRepository>();

        var comment = await repository.GetByIdAsync(id);

        if (comment == null)
        {
            var error = new Error("System.NotFound", "There is no comment with this id.");
            return Result<GridCommentDTO>.Failure(error);
        }

        return Result<GridCommentDTO>.Success(mapper.Map<GridCommentDTO>(comment));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<ICommentRepository>();

        var comment = await repository.GetByIdAsync(id);

        if (comment == null)
        {
            var error = new Error("System.NotFound", "There is no comment with this id.");
            return Result.Failure(error);
        }

        comment.Status = Domain.Enum.EntityStatus.Deleted;
        comment.DeletionDate = DateTime.Now;

        repository.Update(comment);
        await uow.CommitAsync();

        return Result.Success();
    }
}
