using backend.DTO;
using backend.Models;
using backend.Repositorys.Interfacfes;
using backend.Services.Interfaces;

namespace backend.Services.Implementations;

public class AuthService : IAuthService
{
    private readonly IAuthRepository authRepository;

    public AuthService(IAuthRepository authRepository)
    {
        this.authRepository = authRepository;
    }

    public async Task<User> RegisterUser(RegisterUserDto user)
    {
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.HashPassword);
        var username = user.Username.Trim();
        var displayname = user.DisplayName.Trim();
        var email = user.Email.Trim();
        var newUserDto = new RegisterUserDto
        {
            Username = username,
            HashPassword = hashPassword,
            DisplayName = displayname,
            Email = email,
        };

        return await authRepository.RegisterUser(newUserDto);
    }
}