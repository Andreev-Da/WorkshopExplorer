using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WorkshopExplorer.Pages.Bitmap;
using WorkshopExplorer.Shared.Routing;
using WorkshopExplorer.Widgets.Search;

namespace WorkshopExplorer.Pages.Home;

public partial class HomePageModel(IRouter<PageViewModel> router, SearchWidgetModel searchWidget) : PageViewModel
{
    [ObservableProperty] private SearchWidgetModel _searchWidget = searchWidget;

    [ObservableProperty] private string _text;

    [RelayCommand]
    private void Swap()
    {
        router.Push<BitmapTestPageModel>();
    }
    
    [RelayCommand]
    private async Task TestSynchronizationContext()
    {
        Text = "Рудддщ";
        // int threadId = Environment.CurrentManagedThreadId;
        // SynchronizationContext? context1 = SynchronizationContext.Current;
        // await Task.Delay(TimeSpan.FromSeconds(2)).ConfigureAwait(false);
        //
        // int nextThreadId = Environment.CurrentManagedThreadId; 
        // SynchronizationContext? context2 = SynchronizationContext.Current;
        // SynchronizationContext.SetSynchronizationContext(context1);
        // await Task.Delay(TimeSpan.FromSeconds(2));
        //
        // int threadId3 = Environment.CurrentManagedThreadId;
        // SynchronizationContext? context3 = SynchronizationContext.Current;
        //
        //
        // Console.WriteLine($"ThreadId: {threadId}, nextThreadId: {nextThreadId}");
    }
}