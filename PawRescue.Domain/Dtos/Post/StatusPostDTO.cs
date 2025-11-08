using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Post;

public class StatusPostDTO
{
    public int Id { get; set; }
    public EntityStatus Status { get; set; }
}
