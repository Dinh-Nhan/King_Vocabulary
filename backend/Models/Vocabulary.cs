using System;
using System.Collections.Generic;

namespace backend.Models;

public partial class Vocabulary
{
    public int Id { get; set; }

    public string Terminology { get; set; } = null!;

    public string Definition { get; set; } = null!;

    public int ModuleId { get; set; }

    public virtual Module Module { get; set; } = null!;
}
