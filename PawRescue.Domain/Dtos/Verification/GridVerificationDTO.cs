using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Verification;

public class GridVerificationDTO
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Documents { get; set; }
    public VerificationStatus Status { get; set; }
}
