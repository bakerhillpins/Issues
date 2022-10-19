using MauiBugz.ViewModels;
using MauiBugz.Views;

namespace MauiBugz;

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
            })
            .RegisterServices(
                   services =>
                   {
                       services.AddTransient<MainPage>();
                       services.AddTransient<MainPageViewModel>();
                   });

		return builder.Build();
	}

    public static MauiAppBuilder RegisterServices(
        this MauiAppBuilder builder, Action<IServiceCollection> register)
    {
        register?.Invoke(builder.Services);

        return builder;
    }

    public static MauiAppBuilder Issue<TView,TViewModel>( this MauiAppBuilder builder )
        where TView : VisualElement
        where TViewModel : ViewModelBase
    {
        Routing.RegisterRoute( typeof(TView).Name, typeof(TView) );

        return builder
            .RegisterServices(
                services =>
                {
                    services.AddTransient<TView>()
                            .AddTransient<TViewModel>();
                } );
    }
}
