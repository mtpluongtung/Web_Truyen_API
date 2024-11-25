using System;
using System.Collections.Generic;

namespace Data.Models;

public partial class Genre
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Story> Stories { get; set; } = new List<Story>();
}
