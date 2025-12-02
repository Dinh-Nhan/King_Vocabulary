using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Module
{
    public int Id { get; set; }

    public string ModuleName { get; set; } = null!;

    public string? Description { get; set; }

    public int FolderId { get; set; }

    public virtual Folder Folder { get; set; } = null!;

    public virtual ICollection<Vocabulary> Vocabularies { get; set; } = new List<Vocabulary>();
}
