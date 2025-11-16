using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Post;
using PawRescue.Domain.Dtos.UsefulLink;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.UsefulLinks;

namespace PawRescue.Services.UsefulLinks;

public class UsefulLinkService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IUsefulLinkService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridUsefulLinkDTO>> CreateAsync(CreateUsefulLinkDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IUsefulLinkRepository>();

        var linkEntity = mapper.Map<UsefulLink>(createDto);

        repository.Add(linkEntity);

        await uow.CommitAsync();

        return Result<GridUsefulLinkDTO>.Success(mapper.Map<GridUsefulLinkDTO>(linkEntity));
    }

    public async Task<Result<GridUsefulLinkDTO>> UpdateAsync(UpdateUsefulLinkDTO updateDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IUsefulLinkRepository>();

        var existingLink = await repository.GetByIdAsync(updateDto.Id);

        if (existingLink == null)
        {
            var error = new Error("System.NotFound", "There is no link with this id.");
            return Result<GridUsefulLinkDTO>.Failure(error);
        }

        mapper.Map(updateDto, existingLink);

        repository.Update(existingLink);

        await uow.CommitAsync();

        return Result<GridUsefulLinkDTO>.Success(mapper.Map<GridUsefulLinkDTO>(existingLink));
    }

    public async Task<Result<IEnumerable<GridUsefulLinkDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IUsefulLinkRepository>();

        var posts = await repository.GetAllAsync();

        return Result<IEnumerable<GridUsefulLinkDTO>>.Success(mapper.Map<IEnumerable<GridUsefulLinkDTO>>(posts));
    }

    public async Task<Result<GridUsefulLinkDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IUsefulLinkRepository>();

        var link = await repository.GetByIdAsync(id);

        if (link == null)
        {
            var error = new Error("System.NotFound", "There is no useful link with this id.");
            return Result<GridUsefulLinkDTO>.Failure(error);
        }

        return Result<GridUsefulLinkDTO>.Success(mapper.Map<GridUsefulLinkDTO>(link));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IUsefulLinkRepository>();

        var link = await repository.GetByIdAsync(id);

        if (link == null)
        {
            var error = new Error("System.NotFound", "There is no useful link with this id.");
            return Result.Failure(error);
        }

        repository.Remove(link);
        await uow.CommitAsync();

        return Result.Success();
    }
}
