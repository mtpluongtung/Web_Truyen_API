using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class View
{
    public int StoryId { get; set; }

    public int ChapterId { get; set; }

    public int? ViewCount { get; set; }

    public virtual Chapter Chapter { get; set; } = null!;

    public virtual Story Story { get; set; } = null!;
}
