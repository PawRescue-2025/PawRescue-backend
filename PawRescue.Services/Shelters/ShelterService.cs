using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Shelter;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Shelter;

namespace PawRescue.Services.Shelters;

public class ShelterService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IShelterService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridShelterDTO>> CreateAsync(CreateShelterDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var shelterEntity = mapper.Map<Shelter>(createDto);

        repository.Add(shelterEntity);

        await uow.CommitAsync();

        return Result<GridShelterDTO>.Success(mapper.Map<GridShelterDTO>(shelterEntity));
    }

    public async Task<Result<GridShelterDTO>> UpdateAsync(UpdateShelterDTO updateDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var existingShelter = await repository.GetByIdAsync(updateDto.Id);

        if (existingShelter == null)
        {
            var error = new Error("System.NotFound", "There is no shelter with this id.");
            return Result<GridShelterDTO>.Failure(error);
        }

        mapper.Map(updateDto, existingShelter);

        repository.Update(existingShelter);

        await uow.CommitAsync();

        return Result<GridShelterDTO>.Success(mapper.Map<GridShelterDTO>(existingShelter));
    }

    public async Task<Result<IEnumerable<GridShelterDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var shelters = await repository.GetAllAsync();

        return Result<IEnumerable<GridShelterDTO>>.Success(mapper.Map<IEnumerable<GridShelterDTO>>(shelters));
    }

    public async Task<Result<GridShelterDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var shelter = await repository.GetByIdAsync(id);

        if (shelter == null)
        {
            var error = new Error("System.NotFound", "There is no shelter with this id.");
            return Result<GridShelterDTO>.Failure(error);
        }

        return Result<GridShelterDTO>.Success(mapper.Map<GridShelterDTO>(shelter));
    }

    public async Task<Result<GridShelterDTO>> GetByOwnerIdAsync(string ownerId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var shelter = await repository.GetByOwnerIdAsync(ownerId);

        if (shelter == null)
        {
            var error = new Error("System.NotFound", "There is no shelter with this owner id.");
            return Result<GridShelterDTO>.Failure(error);
        }

        return Result<GridShelterDTO>.Success(mapper.Map<GridShelterDTO>(shelter));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var shelter = await repository.GetByIdAsync(id);

        if (shelter == null)
        {
            var error = new Error("System.NotFound", "There is no shelter with this id.");
            return Result.Failure(error);
        }
            
        repository.Remove(shelter);
        await uow.CommitAsync();

        return Result.Success();
    }
}
