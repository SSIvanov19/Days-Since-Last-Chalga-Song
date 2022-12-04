using Microsoft.Extensions.Logging;
using DSLCS.Services;
using CommunityToolkit.Maui;
using DSLCS.App.Pages;

namespace DSLCS.App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("Inter.ttf", "Inter");
			});


		builder.Services
			.AddServices();

		builder.Services
			.AddSingleton<MainPage>()
			.AddSingleton<StatsPage>()
			.AddSingleton<SettingsPage>();
		

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
