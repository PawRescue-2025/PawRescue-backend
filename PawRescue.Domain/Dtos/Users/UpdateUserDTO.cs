namespace PawRescue.Domain.Dtos.Users;

public class UpdateUserDTO
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public string? Photo { get; set; }
    public string? Description { get; set; }
    public string PhoneNumber { get; set; }
}
