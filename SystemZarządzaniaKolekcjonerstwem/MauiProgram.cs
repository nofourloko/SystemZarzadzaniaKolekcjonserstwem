﻿using Microsoft.Extensions.Logging;

namespace SystemZarządzaniaKolekcjonerstwem;

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
				fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons");
				fonts.AddFont("Ojuju-Regular.ttf", "MainFont");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif
        return builder.Build();
	}


}

