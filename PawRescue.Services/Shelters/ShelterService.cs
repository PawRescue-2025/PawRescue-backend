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

    public async Task<Result> CreateAsync(CreateShelterDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IShelterRepository>();

        var shelterEntity = mapper.Map<Shelter>(createDto);

        repository.Add(shelterEntity);

        await uow.CommitAsync();

        return Result.Success();
    }
}
