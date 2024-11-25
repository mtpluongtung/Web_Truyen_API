using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Chapter
{
    public int Id { get; set; }

    public int? StoryId { get; set; }

    public int ChapterNumber { get; set; }

    public string? Title { get; set; }

    public string Content { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();

    public virtual Story? Story { get; set; }

    public virtual ICollection<View> Views { get; set; } = new List<View>();
}
