using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Point;
using PawRescue.Domain.Dtos.Post;
using PawRescue.Domain.Dtos.Resource;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Resources;
using System.Drawing;

namespace PawRescue.Services.Resources;

public class ResourceService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IResourceService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result> CreateAsync(CreateResourceDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var resourceEntity = mapper.Map<Resource>(createDto);

        repository.Add(resourceEntity);

        await uow.CommitAsync();

        return Result.Success();
    }

    public async Task<Result<GridResourceDTO>> UpdateDescriptionAsync(DescriptionResourceDTO resourceDTO)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var existingResource = await repository.GetByIdAsync(resourceDTO.Id);

        if (existingResource == null)
        {
            var error = new Error("System.NotFound", "There is no resource with this id.");
            return Result<GridResourceDTO>.Failure(error);
        }

        mapper.Map(resourceDTO, existingResource);

        repository.Update(existingResource);

        await uow.CommitAsync();

        return Result<GridResourceDTO>.Success(mapper.Map<GridResourceDTO>(existingResource));
    }

    public async Task<Result<GridResourceDTO>> ToggleIsPresentAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var existingResource = await repository.GetByIdAsync(id);

        if (existingResource == null)
        {
            var error = new Error("System.NotFound", "There is no resource with this id.");
            return Result<GridResourceDTO>.Failure(error);
        }

        existingResource.IsPresent = !existingResource.IsPresent;

        repository.Update(existingResource);

        await uow.CommitAsync();

        return Result<GridResourceDTO>.Success(mapper.Map<GridResourceDTO>(existingResource));
    }

    public async Task<Result<IEnumerable<GridResourceDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var resources = await repository.GetAllAsync();

        return Result<IEnumerable<GridResourceDTO>>.Success(mapper.Map<IEnumerable<GridResourceDTO>>(resources));
    }

    public async Task<Result<IEnumerable<GridResourceDTO>>> GetAllByShelterIdAsync(int shelterId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var resources = await repository.GetAllByShelterIdAsync(shelterId);

        return Result<IEnumerable<GridResourceDTO>>.Success(mapper.Map<IEnumerable<GridResourceDTO>>(resources));
    }

    public async Task<Result<GridResourceDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var resource = await repository.GetByIdAsync(id);

        if (resource == null)
        {
            var error = new Error("System.NotFound", "There is no resource with this id.");
            return Result<GridResourceDTO>.Failure(error);
        }

        return Result<GridResourceDTO>.Success(mapper.Map<GridResourceDTO>(resource));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IResourceRepository>();

        var resource = await repository.GetByIdAsync(id);

        if (resource == null)
        {
            var error = new Error("System.NotFound", "There is no resource with this id.");
            return Result.Failure(error);
        }

        repository.Remove(resource);
        await uow.CommitAsync();

        return Result.Success();
    }
}
