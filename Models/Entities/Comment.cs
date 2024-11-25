using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Comment
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? StoryId { get; set; }

    public int? ChapterId { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual Chapter? Chapter { get; set; }

    public virtual Story? Story { get; set; }

    public virtual User? User { get; set; }
}
