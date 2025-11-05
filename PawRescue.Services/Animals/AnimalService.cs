using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Animal;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Animal;

namespace PawRescue.Services.Animals;

public class AnimalService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IAnimalService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result> CreateAsync(CreateAnimalDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IAnimalRepository>();

        var animalEntity = mapper.Map<Animal>(createDto);

        repository.Add(animalEntity);

        await uow.CommitAsync();

        return Result.Success();
    }

    public async Task<Result<GridAnimalDTO>> UpdateAsync(UpdateAnimalDTO updateDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IAnimalRepository>();

        var existingAnimal = await repository.GetByIdAsync(updateDto.Id);

        if (existingAnimal == null)
        {
            var error = new Error("System.NotFound", "There is no animal with this id.");
            return Result<GridAnimalDTO>.Failure(error);
        }

        mapper.Map(updateDto, existingAnimal);

        repository.Update(existingAnimal);

        await uow.CommitAsync();

        return Result<GridAnimalDTO>.Success(mapper.Map<GridAnimalDTO>(existingAnimal));
    }

    public async Task<Result<IEnumerable<GridAnimalDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IAnimalRepository>();

        var animals = await repository.GetAllAsync();

        return Result<IEnumerable<GridAnimalDTO>>.Success(mapper.Map<IEnumerable<GridAnimalDTO>>(animals));
    }

    public async Task<Result<GridAnimalDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IAnimalRepository>();

        var animal = await repository.GetByIdAsync(id);

        if (animal == null)
        {
            var error = new Error("System.NotFound", "There is no animal with this id.");
            return Result<GridAnimalDTO>.Failure(error);
        }

        return Result<GridAnimalDTO>.Success(mapper.Map<GridAnimalDTO>(animal));
    }

    public async Task<Result<IEnumerable<GridAnimalDTO>>> GetByShelterIdAsync(int shelterId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IAnimalRepository>();

        var animals = await repository.GetByShelterIdAsync(shelterId);

        return Result<IEnumerable<GridAnimalDTO>>.Success(mapper.Map<IEnumerable<GridAnimalDTO>>(animals));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IAnimalRepository>();

        var animal = await repository.GetByIdAsync(id);

        if (animal == null)
        {
            var error = new Error("System.NotFound", "There is no animal with this id.");
            return Result.Failure(error);
        }

        repository.Remove(animal);
        await uow.CommitAsync();

        return Result.Success();
    }
}
