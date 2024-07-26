using JMM_MauiApp_Tut.Services;
using JMM_MauiApp_Tut.View;
using JMM_MauiApp_Tut.ViewModel;
using Microsoft.Extensions.Logging;

namespace JMM_MauiApp_Tut;

public static class MauiProgramExtensions
{
	public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
	{
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);
		builder.Services.AddSingleton<IGeolocation>(Geolocation.Default);
		builder.Services.AddSingleton<IMap>(Map.Default);

		builder.Services.AddSingleton<MonkeysViewModel>();
		builder.Services.AddTransient<MonkeyDetailsViewModel>();
		builder.Services.AddSingleton<MonkeyService>();
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder;
	}
}
