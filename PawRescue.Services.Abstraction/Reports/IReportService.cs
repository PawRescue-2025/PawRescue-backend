using PawRescue.Domain.Dtos.Report;
using PawRescue.Domain.Shared;

namespace PawRescue.Services.Abstraction.Reports;

public interface IReportService
{
    Task<Result> CreateAsync(CreateReportDTO createDto);
    Task<Result> DeleteAsync(int id);
    Task<Result<GridReportDTO>> GetByIdAsync(int id);
}
