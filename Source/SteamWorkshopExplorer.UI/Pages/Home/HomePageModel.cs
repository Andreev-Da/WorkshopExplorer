using System;
using System.Threading;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SteamWorkshopExplorer.Pages.Bitmap;
using SteamWorkshopExplorer.Shared.Routing;
using SteamWorkshopExplorer.Widgets.Search;

namespace SteamWorkshopExplorer.Pages.HomePage;

public partial class HomePageModel(IRouter<PageViewModel> router, SearchWidgetModel searchWidget) : PageViewModel
{
    [ObservableProperty] private SearchWidgetModel _searchWidget = searchWidget;

    [RelayCommand]
    private void Swap()
    {
        router.Push<BitmapTestPageModel>();
    }

    [RelayCommand]
    private async Task TestSynchronizationContext()
    {
        int threadId = Environment.CurrentManagedThreadId;
        SynchronizationContext? context1 = SynchronizationContext.Current;
        await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
        
        int nextThreadId = Environment.CurrentManagedThreadId; 
        SynchronizationContext? context2 = SynchronizationContext.Current;
        SynchronizationContext.SetSynchronizationContext(context1);
        await Task.Delay(TimeSpan.FromSeconds(2));
        
        int threadId3 = Environment.CurrentManagedThreadId;
        SynchronizationContext? context3 = SynchronizationContext.Current;

        
        Console.WriteLine($"ThreadId: {threadId}, nextThreadId: {nextThreadId}");
    }
}