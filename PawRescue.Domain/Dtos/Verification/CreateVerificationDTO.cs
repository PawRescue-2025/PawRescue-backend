using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Verification;

public class CreateVerificationDTO
{
    public string UserId { get; set; }
    public VerificationStatus Status { get; set; } = VerificationStatus.Pending;
    public List<string> Documents { get; set; }
}
