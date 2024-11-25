using Data;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Models.DTOs;
using Repositories.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Implementations
{
	public class StoryRepository : IStoryRepository
	{
		private readonly DocTruyenContext _context;
        public StoryRepository(DocTruyenContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<StoryDTO>> GetStories(int page , int pageSize)
		{
			// Tính toán số lượng bản ghi cần bỏ qua
			int skip = (page - 1) * pageSize;

			// Lấy dữ liệu từ cơ sở dữ liệu với phân trang
			var result = await _context.Stories
				.OrderBy(s => s.Title) // Sắp xếp theo thuộc tính (có thể thay đổi)
				.Skip(skip)
				.Take(pageSize).ToListAsync();

			return result.Adapt<IEnumerable<StoryDTO>>();
		}
	}
}
