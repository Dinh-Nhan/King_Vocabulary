using backend.DTO;
using backend.Models;

namespace backend.Repositorys.Interfacfes;

public interface IAuthRepository
{
    Task<User> RegisterUser(RegisterUserDto user);
}