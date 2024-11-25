using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs
{
	public class StoryDTO
	{
		public int Id { get; set; }

		public string Title { get; set; } = null!;

		public string Author { get; set; } = null!;

		public string? Description { get; set; }

		public string? Status { get; set; }

		public string? CoverImage { get; set; }

		public DateTime? CreatedAt { get; set; }

		public DateTime? UpdatedAt { get; set; }

		
	}
}
