namespace DrinkDrink;
using SkiaSharp.Views.Maui.Controls.Hosting;
public static class MauiProgram
{
	

	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseSkiaSharp(true)
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				fonts.AddFont("MrsSaintDelafield-Regular.ttf", "MrsSaintDelafield");
			});

		builder.Services.AddSingleton<DrinkIOService>();
		builder.Services.AddSingleton<TodayDrinkViewModel>();
        builder.Services.AddTransient<DrinkDetailsViewModel>();
        builder.Services.AddSingleton<MainPage>();

		builder.Services.AddSingleton<HistoryPage>();
		builder.Services.AddTransient<DetailsPage>();
		

		return builder.Build();
	}
}
