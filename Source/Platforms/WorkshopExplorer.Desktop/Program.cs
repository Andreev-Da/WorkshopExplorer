using System;
using Avalonia;
using HotAvalonia;

namespace WorkshopExplorer;

sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        bool overlayPopups = true;
        return AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .With(new Win32PlatformOptions { OverlayPopups = overlayPopups })
            .With(new X11PlatformOptions { OverlayPopups = overlayPopups })
            .With(new AvaloniaNativePlatformOptions { OverlayPopups = overlayPopups })
            .WithInterFont()
            .LogToTrace();
    }
}