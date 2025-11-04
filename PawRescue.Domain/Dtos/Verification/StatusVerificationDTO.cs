using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Verification;

public class StatusVerificationDTO
{
    public int Id { get; set; }
    public VerificationStatus Status { get; set; }
}
