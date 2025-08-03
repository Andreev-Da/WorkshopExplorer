using System;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using SteamWorkshopExplorer.Pages;
using SteamWorkshopExplorer.Pages.Bitmap;
using SteamWorkshopExplorer.Pages.HomePage;
using SteamWorkshopExplorer.Shared;

namespace SteamWorkshopExplorer.Application;

public class PageViewLocator : IDataTemplate
{
    public bool Match(object? data)
    {
        return data is PageViewModel;
    }
    
    public Control? Build(object? param)
    {
        // TODO source gen 
        switch (param)
        {
            case HomePageModel vm:
                return new HomePageView();
            case BitmapTestPageModel vm:
                return new BitmapTestPage();
            default:
                return new TextBlock { Text = $"Page Not Found: {param?.GetType()?.Name ?? "null"} "};
        }
    }
}