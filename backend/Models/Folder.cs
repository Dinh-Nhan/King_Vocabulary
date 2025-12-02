using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Folder
{
    public int Id { get; set; }

    public string FolderName { get; set; } = null!;

    public int UserId { get; set; }

    public virtual ICollection<Module> Modules { get; set; } = new List<Module>();

    public virtual User User { get; set; } = null!;
}
