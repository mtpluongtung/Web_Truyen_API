using Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
	public interface IStoryRepository
	{
		Task<IEnumerable<StoryDTO>> GetStories(int page, int pageSize);
	}
}
