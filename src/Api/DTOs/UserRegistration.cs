using Application.UserUsecases;

namespace Api.DTOs;

public class UserRegistration()
{
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public CreateUserParam ToCreateUserParam(string role)
    {
        return new CreateUserParam(Email, Password, role, FullName, Phone);
    }
}