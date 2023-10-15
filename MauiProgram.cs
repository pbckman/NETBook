using Adressbook.Mvvm.ViewModels;
using Adressbook.Mvvm.Views;
using Adressbook.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Adressbook
{
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
            
            builder.Services.AddSingleton<ContactService>();
            builder.Services.AddSingleton<FileService>();

            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<MainPage>();

            builder.Services.AddTransient<DetailViewModel>();
            builder.Services.AddTransient<DetailPage>();

            builder.Services.AddTransient<EditViewModel>();
            builder.Services.AddTransient<EditPage>();

            builder.Services.AddTransient<AddViewModel>();
            builder.Services.AddTransient<AddPage>();



            return builder.Build();
        }
    }
}