using AutoMapper;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Services.Abstraction.Verifications;

namespace PawRescue.Services.Verifications;

public class VerificationService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IVerificationService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async 
}
