using backend.Repositorys.Interfacfes;
using backend.DTO;
using backend.Models;
using backend.Services;

namespace backend.Repositorys.Implementations;

public class AuthRepository : IAuthRepository
{
    private readonly KingVocabularyContext context;

    public AuthRepository(KingVocabularyContext context)
    {
        this.context = context;
    }

    public async Task<User> RegisterUser(RegisterUserDto user)
    {
        var newUser = new User
        {
            Username = user.Username,
            Email = user.Email,
            HashPassword = user.HashPassword,
            DisplayName = user.DisplayName,
        };

        context.Users.Add(newUser);
        await context.SaveChangesAsync();

        return newUser;
    }
}