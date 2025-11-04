using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Verification;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Verifications;

namespace PawRescue.Services.Verifications;

public class VerificationService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IVerificationService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result> CreateAsync(CreateVerificationDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var verificationEntity = mapper.Map<Verification>(createDto);

        repository.Add(verificationEntity);

        await uow.CommitAsync();

        return Result.Success();
    }

    public async Task<Result<GridVerificationDTO>> UpdateAsync(UpdateVerificationDTO updateDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var existingVerification = await repository.GetByIdAsync(updateDto.Id);

        if (existingVerification == null)
        {
            var error = new Error("System.NotFound", "There is no verification with this id.");
            return Result<GridVerificationDTO>.Failure(error);
        }

        mapper.Map(updateDto, existingVerification);

        repository.Update(existingVerification);

        await uow.CommitAsync();

        return Result<GridVerificationDTO>.Success(mapper.Map<GridVerificationDTO>(existingVerification));
    }

    public async Task<Result<GridVerificationDTO>> UpdateAsync(StatusVerificationDTO statusVerificationDTO)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();
        var existingVerification = await repository.GetByIdAsync(statusVerificationDTO.Id);

        if (existingVerification == null)
        {
            var error = new Error("System.NotFound", "There is no verification with this id.");
            return Result<GridVerificationDTO>.Failure(error);
        }

        mapper.Map(statusVerificationDTO, existingVerification);

        repository.Update(existingVerification);

        await uow.CommitAsync();

        return Result<GridVerificationDTO>.Success(mapper.Map<GridVerificationDTO>(existingVerification));
    }

    public async Task<Result<IEnumerable<GridVerificationDTO>>> GetAllAsync()
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var verifications = await repository.GetAllAsync();

        return Result<IEnumerable<GridVerificationDTO>>.Success(mapper.Map<IEnumerable<GridVerificationDTO>>(verifications));
    }

    public async Task<Result<GridVerificationDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var verification = await repository.GetByIdAsync(id);

        if (verification == null)
        {
            var error = new Error("System.NotFound", "There is no verification with this id.");
            return Result<GridVerificationDTO>.Failure(error);
        }

        return Result<GridVerificationDTO>.Success(mapper.Map<GridVerificationDTO>(verification));
    }

    public async Task<Result<GridVerificationDTO>> GetByUserIdAsync(string userId)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var verification = await repository.GetByUserIdAsync(userId);

        if (verification == null)
        {
            var error = new Error("System.NotFound", "There is no verification with this user id.");
            return Result<GridVerificationDTO>.Failure(error);
        }

        return Result<GridVerificationDTO>.Success(mapper.Map<GridVerificationDTO>(verification));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var verification = await repository.GetByIdAsync(id);

        if (verification == null)
        {
            var error = new Error("System.NotFound", "There is no verification with this id.");
            return Result.Failure(error);
        }

        repository.Remove(verification);
        await uow.CommitAsync();

        return Result.Success();
    }
}
