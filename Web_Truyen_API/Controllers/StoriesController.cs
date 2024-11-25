using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace YourNamespace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StoriesController : ControllerBase
	{
		private readonly IStoryRepository _storyService;
		public StoriesController(IStoryRepository storyService)
        {
			_storyService = storyService;

		}

        // GET /api/stories - Lấy danh sách truyện.
        [HttpGet]
		public async Task<IActionResult> GetStories(int page , int pageSize)
		{
			var stories = await _storyService.GetStories(page, pageSize);
			return Ok(stories);
		}

		//// GET /api/stories/{id} - Lấy thông tin chi tiết truyện.
		//[HttpGet("{id}")]
		//public IActionResult<Story> GetStory(int id)
		//{
		//	var story = stories.FirstOrDefault(s => s.Id == id);
		//	if (story == null)
		//	{
		//		return NotFound();
		//	}
		//	return Ok(story);
		//}

		//// POST /api/stories - Thêm truyện mới.
		//[HttpPost]
		//public IActionResult<Story> CreateStory([FromBody] Story newStory)
		//{
		//	newStory.Id = stories.Max(s => s.Id) + 1;
		//	stories.Add(newStory);
		//	return CreatedAtAction(nameof(GetStory), new { id = newStory.Id }, newStory);
		//}

		//// PUT /api/stories/{id} - Cập nhật thông tin truyện.
		//[HttpPut("{id}")]
		//public IActionResult UpdateStory(int id, [FromBody] Story updatedStory)
		//{
		//	var story = stories.FirstOrDefault(s => s.Id == id);
		//	if (story == null)
		//	{
		//		return NotFound();
		//	}
		//	story.Title = updatedStory.Title;
		//	story.Content = updatedStory.Content;
		//	return NoContent();
		//}

		//// DELETE /api/stories/{id} - Xóa truyện.
		//[HttpDelete("{id}")]
		//public IActionResult DeleteStory(int id)
		//{
		//	var story = stories.FirstOrDefault(s => s.Id == id);
		//	if (story == null)
		//	{
		//		return NotFound();
		//	}
		//	stories.Remove(story);
		//	return NoContent();
		//}
	}

}
