using DSLCS.Services.Contracts;
using DSLCS.Services.Implentations;
using Microsoft.Extensions.DependencyInjection;

namespace DSLCS.Services;

public static class DependencyInjection
{
	public static void AddServices(this IServiceCollection services)
	{
		services
			.AddScoped<IVideoService, VideoService>();
	}
}
