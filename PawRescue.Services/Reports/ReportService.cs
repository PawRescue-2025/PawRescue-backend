using AutoMapper;
using PawRescue.DataAccess.Abstraction.Repositories;
using PawRescue.DataAccess.Abstraction.UnitOfWork;
using PawRescue.Domain.Dtos.Report;
using PawRescue.Domain.Entities;
using PawRescue.Domain.Shared;
using PawRescue.Services.Abstraction.Reports;

namespace PawRescue.Services.Reports;

public class ReportService(IUnitOfWorkFactory unitOfWorkFactory, IMapper mapper) : IReportService
{
    private readonly IUnitOfWorkFactory unitOfWorkFactory = unitOfWorkFactory;
    private readonly IMapper mapper = mapper;

    public async Task<Result<GridReportDTO>> CreateAsync(CreateReportDTO createDto)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IReportRepository>();

        var reportEntity = mapper.Map<Report>(createDto);

        repository.Add(reportEntity);

        await uow.CommitAsync();

        return Result<GridReportDTO>.Success(mapper.Map<GridReportDTO>(reportEntity));
    }

    public async Task<Result<GridReportDTO>> GetByIdAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IReportRepository>();

        var report = await repository.GetByIdAsync(id);

        if (report == null)
        {
            var error = new Error("System.NotFound", "There is no report with this id.");
            return Result<GridReportDTO>.Failure(error);
        }

        return Result<GridReportDTO>.Success(mapper.Map<GridReportDTO>(report));
    }

    public async Task<Result> DeleteAsync(int id)
    {
        using var uow = unitOfWorkFactory.CreateUnitOfWork();
        var repository = uow.GetRepository<IReportRepository>();

        var report = await repository.GetByIdAsync(id);

        if (report == null)
        {
            var error = new Error("System.NotFound", "There is no report with this id.");
            return Result.Failure(error);
        }

        repository.Remove(report);
        await uow.CommitAsync();

        return Result.Success();
    }
}
