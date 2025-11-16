using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Complaint;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Complaints;

namespace PawRescue.Services.Complaints;

public class ComplaintService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IComplaintService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridComplaintDTO>> CreateAsync(CreateComplaintDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IComplaintRepository>();

        var complaintEntity = mapper.Map<Complaint>(createDto);

        repository.Add(complaintEntity);

        await uow.CommitAsync();

        return Result<GridComplaintDTO>.Success(mapper.Map<GridComplaintDTO>(complaintEntity));
    }

    public async Task<Result<GridComplaintDTO>> UpdateAsync(StatusComplaintDTO statusComplaintDTO)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IComplaintRepository>();
        var existingComplaint = await repository.GetByIdAsync(statusComplaintDTO.Id);

        if (existingComplaint == null)
        {
            var error = new Error("System.NotFound", "There is no complaint with this id.");
            return Result<GridComplaintDTO>.Failure(error);
        }

        mapper.Map(statusComplaintDTO, existingComplaint);

        repository.Update(existingComplaint);

        await uow.CommitAsync();

        return Result<GridComplaintDTO>.Success(mapper.Map<GridComplaintDTO>(existingComplaint));
    }

    public async Task<Result<IEnumerable<GridComplaintDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IComplaintRepository>();

        var complaints = await repository.GetAllAsync();

        return Result<IEnumerable<GridComplaintDTO>>.Success(mapper.Map<IEnumerable<GridComplaintDTO>>(complaints));
    }

    public async Task<Result<GridComplaintDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IComplaintRepository>();

        var complaint = await repository.GetByIdAsync(id);

        if (complaint == null)
        {
            var error = new Error("System.NotFound", "There is no complaint with this id.");
            return Result<GridComplaintDTO>.Failure(error);
        }

        return Result<GridComplaintDTO>.Success(mapper.Map<GridComplaintDTO>(complaint));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IComplaintRepository>();

        var complaint = await repository.GetByIdAsync(id);

        if (complaint == null)
        {
            var error = new Error("System.NotFound", "There is no complaint with this id.");
            return Result.Failure(error);
        }

        repository.Remove(complaint);
        await uow.CommitAsync();

        return Result.Success();
    }
}
