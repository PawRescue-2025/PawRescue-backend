using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Post;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Posts;

namespace PawRescue.Services.Posts;

public class PostService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IPostService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridPostDTO>> CreateAsync(CreatePostDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();

        var postEntity = mapper.Map<Post>(createDto);

        repository.Add(postEntity);

        await uow.CommitAsync();

        return Result<GridPostDTO>.Success(mapper.Map<GridPostDTO>(postEntity));
    }

    public async Task<Result<GridPostDTO>> UpdateAsync(UpdatePostDTO updateDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();

        var existingPost = await repository.GetByIdAsync(updateDto.Id);

        if (existingPost == null)
        {
            var error = new Error("System.NotFound", "There is no post with this id.");
            return Result<GridPostDTO>.Failure(error);
        }

        mapper.Map(updateDto, existingPost);

        repository.Update(existingPost);

        await uow.CommitAsync();

        return Result<GridPostDTO>.Success(mapper.Map<GridPostDTO>(existingPost));
    }

    public async Task<Result<GridPostDTO>> UpdateAsync(StatusPostDTO statusPostDTO)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();
        var existingPost = await repository.GetByIdAsync(statusPostDTO.Id);

        if (existingPost == null)
        {
            var error = new Error("System.NotFound", "There is no post with this id.");
            return Result<GridPostDTO>.Failure(error);
        }

        mapper.Map(statusPostDTO, existingPost);

        repository.Update(existingPost);

        await uow.CommitAsync();

        return Result<GridPostDTO>.Success(mapper.Map<GridPostDTO>(existingPost));
    }

    public async Task<Result<GridPostDTO>> SetHelpRequestAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();
        var existingPost = await repository.GetByIdAsync(id);

        existingPost.IsHelpRequestCompleted = !existingPost.IsHelpRequestCompleted;

        repository.Update(existingPost);

        await uow.CommitAsync();

        return Result<GridPostDTO>.Success(mapper.Map<GridPostDTO>(existingPost));
    }

    public async Task<Result<IEnumerable<GridPostDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();

        var posts = await repository.GetAllActiveAsync();

        return Result<IEnumerable<GridPostDTO>>.Success(mapper.Map<IEnumerable<GridPostDTO>>(posts));
    }

    public async Task<Result<IEnumerable<GridPostDTO>>> GetAllByUserIdAsync(string userId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();

        var posts = await repository.GetAllByUserIdAsync(userId);

        return Result<IEnumerable<GridPostDTO>>.Success(mapper.Map<IEnumerable<GridPostDTO>>(posts));
    }

    public async Task<Result<GridPostDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();

        var post = await repository.GetByIdAsync(id);

        if (post == null)
        {
            var error = new Error("System.NotFound", "There is no post with this id.");
            return Result<GridPostDTO>.Failure(error);
        }

        return Result<GridPostDTO>.Success(mapper.Map<GridPostDTO>(post));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPostRepository>();

        var post = await repository.GetByIdAsync(id);

        if (post == null)
        {
            var error = new Error("System.NotFound", "There is no post with this id.");
            return Result.Failure(error);
        }

        post.Status = Domain.Enum.EntityStatus.Deleted;
        post.DeletionDate = DateTime.Now;

        repository.Update(post);
        await uow.CommitAsync();

        return Result.Success();
    }
}
