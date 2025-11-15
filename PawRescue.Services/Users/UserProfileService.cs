using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Entities.Identity;
using PawRescue.Domain.Enum;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Users;

namespace PawRescue.Services.Users;

public class UserProfileService(UserManager<AppUser> userManager, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IUserProfileService
{
    private readonly UserManager<AppUser> userManager = userManager;
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridUserDTO>> GetByIdAsync(string id)
    {
        var user = await userManager.FindByIdAsync(id);

        if (user == null)
        {
            var error = new Error("User.NotFound", $"User with ID {id} was not found.");
            return Result<GridUserDTO>.Failure(error);
        }

        return Result<GridUserDTO>.Success(mapper.Map<GridUserDTO>(user));
    }

    public async Task<Result<int>> GetUserPointsAsync(string id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IPointRepository>();

        var points = await repository.GetByRecipientIdAsync(id);

        return Result<int>.Success(points.Sum(x => x.Points));
    }

    public async Task<Result<VerificationStatus>> GetVerificationStatusAsync(string id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IVerificationRepository>();

        var verification = await repository.GetByUserIdAsync(id);

        if (verification == null)
            return Result<VerificationStatus>.Success(VerificationStatus.NotVerified);

        return Result<VerificationStatus>.Success(verification.Status);
    }

    public async Task<Result<GridUserDTO>> UpdateAsync(UpdateUserDTO updateDto)
    {
        var user = await userManager.FindByIdAsync(updateDto.Id);

        if (user == null)
        {
            var error = new Error("User.NotFound", $"User with ID {updateDto.Id} was not found.");
            return Result<GridUserDTO>.Failure(error);
        }

        mapper.Map(updateDto, user);

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            var error = new Error("User.UpdateFailed", "Failed to update user profile.");
            return Result<GridUserDTO>.Failure(error);
        }

        return Result<GridUserDTO>.Success(mapper.Map<GridUserDTO>(user));
    }

    public async Task<Result<GridUserDTO>> UpdateStatusAsync(StatusUserDTO statusDto)
    {
        var user = await userManager.FindByIdAsync(statusDto.Id);
        
        if (user == null)
        {
            var error = new Error("User.NotFound", $"User with ID {statusDto.Id} was not found.");
            return Result<GridUserDTO>.Failure(error);
        }

        user.Status = statusDto.Status;

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            var error = new Error("User.UpdateFailed", "Failed to update user status.");
            return Result<GridUserDTO>.Failure(error);
        }

        return Result<GridUserDTO>.Success(mapper.Map<GridUserDTO>(user));
    }
}
