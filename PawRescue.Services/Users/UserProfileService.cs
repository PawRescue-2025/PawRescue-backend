using AutoMapper;
using Microsoft.AspNetCore.Identity;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Resource;
using PawRescue.Domain.Dtos.Users;
using PawRescue.Domain.Entities.Identity;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Users;

namespace PawRescue.Services.Users;

public class UserProfileService(UserManager<AppUser> userManager, IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IUserProfileService
{
    private readonly UserManager<AppUser> userManager = userManager;
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result> UpdateStatusAsync(StatusUserDTO statusDto)
    {
        var user = await userManager.FindByIdAsync(statusDto.Id);
        
        if (user == null)
        {
            var error = new Error("User.NotFound", $"User with ID {statusDto.Id} was not found.");
            return Result.Failure(error);
        }

        user.Status = statusDto.Status;

        var updateResult = await userManager.UpdateAsync(user);

        if (!updateResult.Succeeded)
        {
            var error = new Error("User.UpdateFailed", "Failed to update user status.");
            return Result.Failure(error);
        }

        return Result.Success();
        //return Result<GridResourceDTO>.Success(mapper.Map<GridResourceDTO>(existingResource));
    }
}
