using Avalonia;
using Avalonia.ReactiveUI;
using System;
using Avalonia.Logging;
using NLog;
using NLog.Config;
using NLog.Targets;
using PlanMe.Repository;
using PlanMe.Repository.Sqlite;
using Logger = NLog.Logger;

namespace PlanMe;

class Program
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        // 初始化 NLog
        InitializeNLog();

        // 捕获全局异常
        AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
        
        RepositoryFactory.RegisterModule(new SqliteRepositoryModule());
        try
        {
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }
        catch (Exception ex)
        {
            _logger.Fatal(ex, "应用程序遇到致命错误");
        }
    }
    
    private static void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        if (e.ExceptionObject is Exception ex)
        {
            _logger.Error(ex, "捕获到全局未处理异常");
        }
        else
        {
            _logger.Error("捕获到非异常对象的全局未处理异常");
        }
    }

    private static void InitializeNLog()
    {
        var config = new LoggingConfiguration();
        var logfile = new FileTarget("logfile") { FileName = @"Log\PlanMe${date:format=yyyy-MM-dd}.log" };
        config.AddRule(LogLevel.Debug, LogLevel.Fatal, logfile);
        LogManager.Configuration = config;
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .LogToTrace(LogEventLevel.Error)
            .UseReactiveUI();
}