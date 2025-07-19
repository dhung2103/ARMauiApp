using ARMauiApp.Converters;
using ARMauiApp.Pages;
using ARMauiApp.Services;
using ARMauiApp.ViewModels;
using ARMauiApp.Configuration;
using CommunityToolkit.Maui;
using UraniumUI;

namespace ARMauiApp;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseUraniumUI()
            .UseUraniumUIMaterial()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddMaterialSymbolsFonts();
            });

        // Register Services
        builder.Services.AddSingleton<AuthService>();
        builder.Services.AddSingleton<ProductService>();
        builder.Services.AddSingleton<CategoryService>();
        builder.Services.AddSingleton<ApiHealthService>();

        // Register Converters
        builder.Services.AddSingleton<CountToBoolConverter>();
        builder.Services.AddSingleton<InvertedBoolConverter>();
        builder.Services.AddSingleton<BoolToActiveStatusConverter>();
        builder.Services.AddSingleton<BoolToStatusColorConverter>();

        // Register ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<ProductListViewModel>();
        builder.Services.AddTransient<ProductDetailViewModel>();

        // Register Pages
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<ProductListPage>();
        builder.Services.AddTransient<ProductDetailPage>();
        builder.Services.AddTransient<AccountPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
