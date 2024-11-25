using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Rating
{
	public int Id { get; set; } // Primary key
	public int UserId { get; set; }

    public int StoryId { get; set; }

    public int? Rating1 { get; set; }

    public DateTime? CreatedAt { get; set; }

    public virtual Story Story { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
