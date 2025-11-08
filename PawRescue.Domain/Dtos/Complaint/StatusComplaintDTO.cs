using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Complaint;

public class StatusComplaintDTO
{
    public int Id { get; set; }

    public ComplaintStatus Status { get; set; }
}
