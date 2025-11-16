using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Point;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Points;

namespace PawRescue.Services.Points;

public class PointService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IPointService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridPointDTO>> CreateAsync(CreatePointDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        if (createDto.Points <= 0 || createDto.Points > 10)
            return Result<GridPointDTO>.Failure(new Error("InvalidPoints", "Points must be between 1 and 10."));

        var pointEntity = mapper.Map<Point>(createDto);

        repository.Add(pointEntity);

        await uow.CommitAsync();

        return Result<GridPointDTO>.Success(mapper.Map<GridPointDTO>(pointEntity));
    }

    public async Task<Result<IEnumerable<GridPointDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        var points = await repository.GetAllAsync();

        return Result<IEnumerable<GridPointDTO>>.Success(mapper.Map<IEnumerable<GridPointDTO>>(points));
    }

    public async Task<Result<IEnumerable<GridPointDTO>>> GetAllByRecipientIdAsync(string recipientId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        var points = await repository.GetByRecipientIdAsync(recipientId);

        return Result<IEnumerable<GridPointDTO>>.Success(mapper.Map<IEnumerable<GridPointDTO>>(points));
    }

    public async Task<Result<IEnumerable<GridPointDTO>>> GetAllByReviewerIdAsync(string reviewerId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        var points = await repository.GetByReviewerIdAsync(reviewerId);

        return Result<IEnumerable<GridPointDTO>>.Success(mapper.Map<IEnumerable<GridPointDTO>>(points));
    }

    public async Task<Result<GridPointDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        var point = await repository.GetByIdAsync(id);

        if (point == null)
        {
            var error = new Error("System.NotFound", "There is no point with this id.");
            return Result<GridPointDTO>.Failure(error);
        }

        return Result<GridPointDTO>.Success(mapper.Map<GridPointDTO>(point));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        var point = await repository.GetByIdAsync(id);

        if (point == null)
        {
            var error = new Error("System.NotFound", "There is no point with this id.");
            return Result.Failure(error);
        }

        repository.Remove(point);
        await uow.CommitAsync();

        return Result.Success();
    }
}
