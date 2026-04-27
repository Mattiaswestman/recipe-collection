using Microsoft.Extensions.Logging;
using RecipeCollection.Views;
using RecipeCollection.ViewModels;
using RecipeCollection.Services;

namespace RecipeCollection
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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<CategoryPage>();
            builder.Services.AddTransient<CategoryPageViewModel>();
            builder.Services.AddTransient<RecipePage>();
            builder.Services.AddTransient<RecipePageViewModel>();
            builder.Services.AddScoped(s =>
            {
                string databasePath = Path.Combine(FileSystem.AppDataDirectory, "Database.db");
                System.Diagnostics.Debug.WriteLine($"Database path: {databasePath}");
                return new RecipeCollectionDbContext(databasePath);
            });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<RecipeCollectionDbContext>();
                db.Database.EnsureCreated();
            }

            return app;
        }
    }
}
