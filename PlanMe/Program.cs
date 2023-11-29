using Avalonia;
using Avalonia.ReactiveUI;
using System;
using Avalonia.Logging;
using PlanMe.Repository;
using PlanMe.Repository.Sqlite;

namespace PlanMe;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        RepositoryFactory.RegisterModule(new SqliteRepositoryModule());
        BuildAvaloniaApp()
            .StartWithClassicDesktopLifetime(args);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace(LogEventLevel.Error)
            // TODO NLog
            .UseReactiveUI();
}