﻿namespace DrinkDrink;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
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
