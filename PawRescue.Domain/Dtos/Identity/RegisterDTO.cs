using PawRescue.Domain.Enum;

namespace PawRescue.Domain.Dtos.Identity;

public class RegisterDTO
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string Description { get; set; }
    public string PhoneNumber { get; set; }
    public UserRole Role { get; set; }
}
