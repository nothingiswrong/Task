using Avalonia;
using Avalonia.ReactiveUI;
using System;
using Task1;

namespace AvaloniaApplication1;

class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args)
    {
        BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);
        for (int i = 0; i < 1000; i++) new TaskMaster().N3(new int[] {1,1,1,1,2,4,5}, 1);
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}