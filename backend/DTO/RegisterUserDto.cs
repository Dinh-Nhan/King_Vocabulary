using System.ComponentModel.DataAnnotations;

namespace backend.DTO;

public class RegisterUserDto
{
    [Required]
    public string Username { get; set; } = null!;

    [Required]
    public string HashPassword { get; set; } = null!;

    [Required]
    public string DisplayName { get; set; } = null!;

    [Required]
    public string Email { get; set; } = null!;
}
