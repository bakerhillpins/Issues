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
                   })
            .Issue10294();

        return builder.Build();
    }

    public static MauiAppBuilder RegisterServices(
        this MauiAppBuilder builder, Action<IServiceCollection> register)
    {
        register?.Invoke(builder.Services);

        return builder;
    }

    public static MauiAppBuilder Issue10294(this MauiAppBuilder builder)
    {
        Routing.RegisterRoute(nameof(Issue10294View), typeof(Issue10294View));

        return builder
               .RegisterServices(
                   services =>
                   {
                       services.AddTransient<Issue10294View>()
                               .AddTransient<Issue10294ViewModel>();
                   });
    }
}
