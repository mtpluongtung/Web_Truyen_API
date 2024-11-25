using Microsoft.EntityFrameworkCore.Migrations;
using Repositories.Implementations;
using Repositories.Interfaces;

namespace Web_Truyen_API.Configurations
{
	public static  class Register
	{ 
		public static void AddRepositorys(this IServiceCollection services)
		{
			services.AddScoped<IStoryRepository, StoryRepository>();
		}
	}
}
