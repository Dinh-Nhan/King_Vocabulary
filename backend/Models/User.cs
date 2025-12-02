namespace backend.Models;

public partial class User
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string HashPassword { get; set; } = null!;

    public string? DisplayName { get; set; }

    public string Email { get; set; } = null!;

    public string? AvatarUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public virtual ICollection<Folder> Folders { get; set; } = new List<Folder>();
}
