using Microsoft.Extensions.Logging;
using Model;
using StubLib;
using ViewModel;
using Mvue.ViewModel;
using Mvue.Pages;
using CommunityToolkit.Maui;

namespace Mvue;

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
			});
		builder.Services.AddSingleton<IDataManager, StubData>().AddSingleton<ChampionMgrVM>();
		builder.Services.AddTransient<ChampionsView>();
		builder.Services.AddTransient<ChampionsViewModel>();
		builder.Services.AddTransient<ChampionDetailViewModel>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

