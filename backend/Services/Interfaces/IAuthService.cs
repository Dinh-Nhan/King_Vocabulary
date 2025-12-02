using backend.DTO;
using backend.Models;

namespace backend.Services.Interfaces;

public interface IAuthService
{
    Task<User> RegisterUser(RegisterUserDto user);
}